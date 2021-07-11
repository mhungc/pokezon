using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pokezon.ProductApi.Data.DBConfiguration;
using Pokezon.ProductApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.ProductApi.Data.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Product> collection;

        public ProductRepository(IOptions<DataBaseSettings> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var configuration = options.Value;
            var client = new MongoClient(configuration.ConnectionString);

            this.database = client.GetDatabase(configuration.DatabaseName);
            this.collection = database.GetCollection<Product>(configuration.CollectionName);
        }

        public async Task<Product> GetProduct(Guid productId) => await collection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetAll() => await collection.Find(_ => true).ToListAsync();

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                await collection.InsertOneAsync(product);

                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

}
