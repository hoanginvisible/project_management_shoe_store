using Data.Interfaces;
using Domain.Entities;
using MediatR;

namespace Service.Handlers.ProductDetails.Command.Handler
{
    public class UpdateProductDetailCommandHandler : IRequestHandler<UpdateProductDetailCommand, bool>
    {
        private readonly IRepository<ProductDetail> _repository;

        public UpdateProductDetailCommandHandler(IRepository<ProductDetail> repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(UpdateProductDetailCommand request, CancellationToken cancellationToken)
        {
            ProductDetail productDetail = new ProductDetail
            {
                Id = request.Id,
                IdProduct = request.IdProduct,
                IdBrand = request.IdBrand,
                IdCategory = request.IdCategory,
                IdColor = request.IdColor,
                IdImage = request.Image,
                IdMaterial = request.IdMaterial,
                IdSize = request.IdSize,
                Price = request.Price,
                Quantity = request.Quantity,
                CreatedDate = new DateTime(),
                LastModifiedDate = new DateTime()
            };
            _repository.Update(productDetail);
            return Task.FromResult(true);
        }
    }
}