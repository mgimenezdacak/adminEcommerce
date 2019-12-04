using Microsoft.ML.Data;
using System;


namespace ProductRecommender.DataModel
{
    public class ProductInput
    {
        [KeyType(count : 262111)]
        public uint ProductId { get; set; }
        [KeyType(count : 262111)]
        public uint CoPurchasedProductId { get; set; }

        public float Label { get; set; }
    }
}