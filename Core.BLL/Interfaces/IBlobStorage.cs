using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.BLL.Interfaces
{
    public interface IBlobStorage
    {
        Task UploadStream(Stream stream, string blobName, string containerName, string contentType, bool isPublic = false);
        Task UploadStream(Stream stream, string blobName, string containerName, string contentType, IReadOnlyDictionary<string, string> metadata, bool isPublic = false);
        Task UploadByteArray(byte[] bytes, string blobName, string containerName, string contentType, bool isPublic = false);
        Task UploadByteArray(byte[] bytes, string blobName, string containerName, string contentType, IReadOnlyDictionary<string, string> metadata, bool isPublic = false);
        Task UploadString(string content, string blobName, string containerName, string contentType, bool isPublic = false);
        Task UploadString(string content, string blobName, string containerName, string contentType, IReadOnlyDictionary<string, string> metadata, bool isPublic = false);
        Task<string> DownloadBlobAsString(string blobName, string containerName);
        Task<Stream> DownloadBlobAsStream(string blobName, string containerName);
        Task<byte[]> DownloadBlobAsByteArray(string blobName, string containerName);
        Task<CloudBlockBlob> DownloadBlockBlob(string blobName, string containerName);
        string GetSaasToken(string blobName, string containerName);
        string GetBlobUrl(string blobName, string containerName);
        Task<string> GetFullSaasTokenAsync(string blobName, string containerName);
        CloudBlockBlob DownloadBlob(string containerName, string blobName);
        string GetFullSaasToken(string blobName, string containerName);
        //Task<string> GetPdf(string blobName, string containerName);
        Task<string> GetSaasToken(string blobName, string containerName, DateTimeOffset startTime, DateTimeOffset endTime);
    }
}
