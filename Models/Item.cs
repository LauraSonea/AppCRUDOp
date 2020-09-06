using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCRUDOp.Models
{
    public class Item
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("tags")]
        public IList<string> Tags { get; set; }

        [BsonElement("price")]
        public float Price { get; set; }

        [BsonElement("quantity")]

        public int Quantity { get; set; }

        public Item()
        {
            List<string> Tags = new List<string>();
        }
    }
    
}
