using MediatR;
using NetCleanArchitectureMvc.Application.Products.Commands;
using NetCleanArchitectureMvc.Domain.Entities;
using NetCleanArchitectureMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCleanArchitectureMvc.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler: IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price,
                                request.Stock, request.Image, request.Id);

                return await _productRepository.UpdateAsync(product);

            }
        }
    }
}
