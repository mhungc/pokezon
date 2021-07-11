using Pokezon.ProductApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.ProductApi.Data.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(Guid productId);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> CreateProduct(Product product);
    }
}
