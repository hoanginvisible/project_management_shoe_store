using Data.Interfaces;
using Domain.Entities;
using MediatR;

namespace Service.Handlers.ProductDetails.Command
{
    public record UpdateProductDetailCommand : IRequest<bool>
    {
        public string id { get; set; }
        public string idProduct { get; set; }
        public string idBrand { get; set; }
        public string idCategory { get; set; }
        public string idColor { get; set; }
        public string Image { get; set; }
        public string idMaterial { get; set; }
        public string idSize { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
    }

    public class UpdateProductDetailCommandHandle : IRequestHandler<UpdateProductDetailCommand, bool>
    {
        private readonly IRepository<ProductDetail> _repository;

        public UpdateProductDetailCommandHandle(IRepository<ProductDetail> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductDetailCommand request, CancellationToken cancellationToken)
        {
            ProductDetail productDetail = new ProductDetail
            {
                Id = request.id,
                IdProduct = request.idProduct,
                IdBrand = request.idBrand,
                IdCategory = request.idCategory,
                IdColor = request.idColor,
                IdImage = request.Image,
                IdMaterial = request.idMaterial,
                IdSize = request.idSize,
                Price = request.Price,
                Quantity = request.Quantity,
                CreatedDate = new DateTime(),
                LastModifiedDate = new DateTime()
            };
            _repository.Update(productDetail);
            return true;
        }
    }
}