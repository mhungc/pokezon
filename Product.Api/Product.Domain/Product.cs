using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.ProductApi.Domain
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("ProductId")]
        public Guid ProductId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("PowerLevel")]
        public int PowerLevel { get; set; }


        public Product()
        {
            ProductId = Guid.NewGuid();
        }

    }
}
