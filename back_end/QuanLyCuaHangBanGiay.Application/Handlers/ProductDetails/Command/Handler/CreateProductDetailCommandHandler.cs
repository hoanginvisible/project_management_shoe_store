using Data.Interfaces;
using Domain.Entities;
using MediatR;

namespace Service.Handlers.ProductDetails.Command.Handler
{
    public class CreateProductDetailCommandHandler : IRequestHandler<CreateProductDetailCommand, bool>
    {
        private readonly IRepository<ProductDetail> _repository;

        public CreateProductDetailCommandHandler(IRepository<ProductDetail> repository)
        {
            _repository = repository;
        }

        public Task<Boolean> Handle(CreateProductDetailCommand request,
            CancellationToken cancellationToken)
        {
            ProductDetail productDetail = new ProductDetail
            {
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
            _repository.Insert(productDetail);
            return Task.FromResult(true);
        }
    }
}