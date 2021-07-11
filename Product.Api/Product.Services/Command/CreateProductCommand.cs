using MediatR;
using Pokezon.ProductApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.ProductApi.Services.Command
{
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
