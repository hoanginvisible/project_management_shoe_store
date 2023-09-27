using Data.Interfaces;
using MediatR;

namespace Application.Handlers.ProductDetail.Command
{
    public class CreateProductDetailCommand : IRequest<Boolean>
    {
        public string idProduct { get; set; }
        public string idBrand { get; set; }
        public string idCategory { get; set; }
        public string idColor { get; set; }
        public string idImage { get; set; }
        public string idMaterial { get; set; }
        public string idSize { get; set; }
        public Double Price { get; set; }
        public long Quantity { get; set; }
    }

    public class CreateProductDetailHandler : IRequestHandler<CreateProductDetailCommand, Boolean>
    {
        private readonly IRepository<Domain.Entities.ProductDetail> _repository;

        public CreateProductDetailHandler(IRepository<Domain.Entities.ProductDetail> repository)
        {
            _repository = repository;
        }

        public async Task<Boolean> Handle(CreateProductDetailCommand request,
            CancellationToken cancellationToken)
        {
            Domain.Entities.ProductDetail productDetail = new Domain.Entities.ProductDetail
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