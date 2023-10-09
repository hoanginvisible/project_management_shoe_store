using Data.Interfaces;
using Domain.Entities;
using MediatR;

namespace Service.Handlers.ProductDetails.Command.Handler
{
    public class DeleteProductDetailCommandHandler : IRequestHandler<DeleteProductDetailCommand, string>
    {
        private readonly IRepository<ProductDetail> _repository;

        public DeleteProductDetailCommandHandler(IRepository<ProductDetail> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var productDetail = await _repository.GetById(request.Id);
                if (productDetail != null) _repository.Delete(productDetail);
            }

            return request.Id!;
        }
    }
}