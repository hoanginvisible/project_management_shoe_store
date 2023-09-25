using Domain.Entities;
using MediatR;
using Service.Handlers.ProductDetail.Queries;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMediator _mediator;

        public ProductDetailService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDetailDto>> GetAllProductDetail(int page)
        {
            var query = new GetProductDetailsQuery
            {
                PageNumber = page
            };
            return await _mediator.Send(query);
        }

        public Task Insert(IEnumerable<Brand> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}