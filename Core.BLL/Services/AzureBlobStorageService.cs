using Core.BLL.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BLL.Services
{
    public class AzureBlobStorageService
    {
        private readonly string _blobPath;
        private readonly string _connectionString;

        public AzureBlobStorageService(string ConnectionString, string BlobPath)
        {
            _blobPath = BlobPath;
            _connectionString = ConnectionString;
        }

        public async Task<byte[]> DownloadBlobAsByteArray(string blobName, string containerName)
        {
            var blob = await GetBlockBlob(blobName, containerName);
            var array = new byte[blob.StreamWriteSizeInBytes];
            await blob.DownloadToByteArrayAsync(array, 0);
            return array;
        }

        public async Task<Stream> DownloadBlobAsStream(string blobName, string containerName)
        {
            var blob = await GetBlockBlob(blobName, containerName);
            var ms = new MemoryStream();
            await blob.DownloadToStreamAsync(ms);
            ms.Position = 0;
            return ms;
        }

        public async Task<string> DownloadBlobAsString(string blobName, string containerName)
        {
            var blob = await GetBlockBlob(blobName, containerName);
            return await blob.DownloadTextAsync();
        }

        public async Task<CloudBlockBlob> DownloadBlockBlob(string blobName, string containerName)
        {
            var blob = await GetBlockBlob(blobName, containerName);
            await blob.FetchAttributesAsync();
            return blob;
        }

        public CloudBlockBlob DownloadBlob(string containerName, string blobName)
        {
            try
            {
                var container = GetBlobContainer(containerName).Result;
                return container.GetBlockBlobReference(blobName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetSaasToken(string blobName, string containerName)
        {
            return GetSaasToken(blobName, containerName, DateTimeOffset.UtcNow.AddHours(-1), DateTimeOffset.UtcNow.AddHours(2)).Result;
        }

        public Task<string> GetFullSaasTokenAsync(string blobName, string containerName)
        {
            var path = _blobPath;
            return Task.FromResult(path + containerName.ToLower() + "/" + blobName + GetSaasToken(blobName, containerName, DateTimeOffset.UtcNow.AddHours(-1), DateTimeOffset.UtcNow.AddHours(2)).Result);

        }

        public string GetBlobUrl(string blobName, string containerName)
        {
            return $"{_blobPath}{GetContainerName(containerName)}/{blobName}";
        }

        public string GetFullSaasToken(string blobName, string containerName)
        {
            if (string.IsNullOrEmpty(blobName) || string.IsNullOrEmpty(containerName)) return null;
            var path = _blobPath;
            return path + GetContainerName(containerName) + "/" + blobName + GetSaasToken(blobName, containerName, DateTimeOffset.UtcNow.AddHours(-1), DateTimeOffset.UtcNow.AddHours(2)).Result;
        }

        public async Task<string> GetSaasToken(string blobName, string containerName, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            var blob = await DownloadBlockBlob(blobName, containerName);
            await blob.FetchAttributesAsync();
            var r = await blob.ExistsAsync();
            var token = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = startTime,
                SharedAccessExpiryTime = endTime
            });
            return token;
        }

        public async Task UploadByteArray(byte[] bytes, string blobName, string containerName, string contentType, bool isPublic = false)
        {
            await UploadByteArray(bytes, blobName, containerName, contentType, new Dictionary<string, string>(), isPublic);
        }

        public async Task UploadByteArray(byte[] bytes, string blobName, string containerName, string contentType, IReadOnlyDictionary<string, string> metadata, bool isPublic = false)
        {
            var blob = await GetBlockBlob(blobName, containerName, isPublic);
            blob.Properties.ContentType = contentType;
            blob.Properties.CacheControl = "public, max-age=604800";
            if (metadata != null && metadata.Any())
            {
                foreach (var data in metadata)
                {
                    if (blob.Metadata.ContainsKey(data.Key))
                    {
                        blob.Metadata[data.Key] = data.Value;
                    }
                    else
                    {
                        blob.Metadata.Add(data.Key, data.Value);
                    }
                }
            }

            await blob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);
        }

        public async Task UploadStream(Stream stream, string blobName, string containerName, string contentType, bool isPublic = false)
        {
            await UploadStream(stream, blobName, containerName, contentType, new Dictionary<string, string>(), isPublic);
        }

        public async Task UploadStream(Stream stream, string blobName, string containerName, string contentType, IReadOnlyDictionary<string, string> metadata, bool isPublic = false)
        {
            var blob = await GetBlockBlob(blobName, containerName, isPublic);
            stream.Position = 0;
            blob.Properties.ContentType = contentType;
            blob.Properties.CacheControl = "public, max-age=604800";
            if (metadata != null && metadata.Any())
            {
                foreach (var data in metadata)
                {
                    if (blob.Metadata.ContainsKey(data.Key))
                    {
                        blob.Metadata[data.Key] = data.Value;
                    }
                    else
                    {
                        blob.Metadata.Add(data.Key, data.Value);
                    }
                }
            }

            await blob.UploadFromStreamAsync(stream, stream.Length);
        }

        public async Task UploadString(string content, string blobName, string containerName, string contentType, bool isPublic = false)
        {
            await UploadString(content, blobName, containerName, contentType, null, isPublic);
        }

        public async Task UploadString(string content, string blobName, string containerName, string contentType, IReadOnlyDictionary<string, string> metadata, bool isPublic = false)
        {
            var blob = await GetBlockBlob(blobName, containerName, isPublic);
            blob.Properties.ContentType = contentType;
            blob.Properties.CacheControl = "public, max-age=604800";
            if (metadata != null && metadata.Any())
            {
                foreach (var data in metadata)
                {
                    if (blob.Metadata.ContainsKey(data.Key))
                    {
                        blob.Metadata[data.Key] = data.Value;
                    }
                    else
                    {
                        blob.Metadata.Add(data.Key, data.Value);
                    }
                }
            }

            await blob.UploadTextAsync(content);
        }

        private async Task<CloudBlobContainer> GetBlobContainer(string name, bool isPublic = false)
        {
            var account = CloudStorageAccount.Parse(_connectionString);
            var container = account.CreateCloudBlobClient().GetContainerReference(GetContainerName(name));
            await container.CreateIfNotExistsAsync(isPublic ? BlobContainerPublicAccessType.Blob : BlobContainerPublicAccessType.Off, null, null);
            return container;
        }

        private async Task<CloudBlockBlob> GetBlockBlob(string blobName, string containerName, bool isPublic = false)
        {
            var container = await GetBlobContainer(containerName, isPublic);
            return container.GetBlockBlobReference(blobName);
        }

        private static string GetContainerName(string name)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
            var isProd = env.ToLower() == "production";
            return (isProd ? name : $"{env}-{name}").ToLower();
        }
    }
}
