using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCRUDOp.Models
{
    [BsonIgnoreExtraElements]
    public class Sale
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("saleDate")]
        public DateTime SaleDate { get; set; }

        [BsonElement("items")]
        public List<Item> Items { get; set; }

        [BsonElement("storeLocation")]
        public string StoreLocation { get; set; }

        [BsonElement("customer")]
        public Customer Customer { get; set; }

        [BsonElement("couponUsed")]
        public bool CouponUsed { get; set; }

        [BsonElement("purchaseMethod")]
        public string PurchaseMethod { get; set; }

        public Sale()
        {
            List<Item> Items = new List<Item>();
            Customer Customer = new Customer();
        }
    }
}
