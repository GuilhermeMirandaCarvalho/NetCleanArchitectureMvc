using MediatR;
using NetCleanArchitectureMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCleanArchitectureMvc.Application.Products.Commands
{
    public abstract class ProductCommand: IRequest<Product>
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public string CategoryId { get; set; }
    }
}
