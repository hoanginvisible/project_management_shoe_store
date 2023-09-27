using Data.Interfaces;
using Domain.Entities;
using MediatR;

namespace Service.Handlers.ProductDetails.Command
{
    public class CreateProductDetailCommand : IRequest<bool>
    {
        public string idProduct { get; set; }
        public string idBrand { get; set; }
        public string idCategory { get; set; }
        public string idColor { get; set; }
        public string idImage { get; set; }
        public string idMaterial { get; set; }
        public string idSize { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
    }

    public class CreateProductDetailHandler : IRequestHandler<CreateProductDetailCommand, bool>
    {
        private readonly IRepository<ProductDetail> _repository;

        public CreateProductDetailHandler(IRepository<ProductDetail> repository)
        {
            _repository = repository;
        }

        public async Task<Boolean> Handle(CreateProductDetailCommand request,
            CancellationToken cancellationToken)
        {
            ProductDetail productDetail = new ProductDetail
            {
                IdProduct = request.idProduct,
                IdBrand = request.idBrand,
                IdCategory = request.idCategory,
                IdColor = request.idColor,
                IdImage = request.idImage,
                IdMaterial = request.idMaterial,
                IdSize = request.idSize,
                Price = request.Price,
                Quantity = request.Quantity
            };
            _repository.Insert(productDetail);
            return true;
        }
    }
}