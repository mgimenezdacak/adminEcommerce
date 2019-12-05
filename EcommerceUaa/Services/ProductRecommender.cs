﻿using EcommerceUaa;
using EcommerceUaa.Services;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using ProductRecommender.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UAAEcommerce.Services
{
    public class Recommender
    {
        DataContext db = new EcommerceUaa.DataContext();
        BlobStorageService blobStorage = new BlobStorageService();

        public Recommender()
        {
            
        }

        public async void TrainModel()
        {
            var data = new List<ProductInput>();
            foreach (var order in db.Pedido.ToList())
            {
                var productIds = order.PedidoDetalle.Select(x => x.idProducto).ToList();
                foreach (var productId in productIds)
                {
                    var coPurchasedIds = productIds;
                    data.AddRange(coPurchasedIds.Select(coPurchasedId => new ProductInput { ProductId = (uint)productId, CoPurchasedProductId = (uint)coPurchasedId }));
                }
            }

            var mlContext = new MLContext();

            var trainData = mlContext.Data.LoadFromEnumerable(data);

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "ProductId",
                MatrixRowIndexColumnName = "CoPurchasedProductId",
                LabelColumnName = "Label",
                LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                Alpha = 0.01,
                Lambda = 0.025,
                C = 0.00001
            };

            var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);
            var model = est.Fit(trainData);

            using (var ms = new MemoryStream())
            {
                mlContext.Model.Save(model, trainData.Schema, ms);
                await blobStorage.UploadStream(ms, "recommender-model.ml", "models", "application/octet-stream");
            }
        }

        public async Task<PredictionEngine<ProductInput, ProductScore>> GetEngine()
        {
            var modelStream = await blobStorage.DownloadBlobAsStream("recommender-model.ml", "Models");
            var mlContext = new MLContext();
            var model = mlContext.Model.Load(modelStream, out _);
            var engine = mlContext.Model.CreatePredictionEngine<ProductInput, ProductScore>(model);
            return engine;
        }
    }
}