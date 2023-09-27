using Data.Interfaces;
using Domain.Entities;
using MediatR;

namespace Service.Handlers.ProductDetails.Command
{
    public record DeleteProductDetailCommand : IRequest<string>
    {
        public string id;
    }

    public class DeleteProductDetailCommandHandler : IRequestHandler<DeleteProductDetailCommand, string>
    {
        public IRepository<ProductDetail> _repository;

        public DeleteProductDetailCommandHandler(IRepository<ProductDetail> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        {
            var productDetail = await _repository.GetById(request.id);
            if (productDetail == null)
            {
                return null;
            }

            _repository.Delete(productDetail);
            return request.id;
        }

        // public Task<int> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        // {
        //     Domain.Entities.ProductDetail productDetail = _repository.GetById(Guid.Parse(request.id));
        //     _repository.Delete
        //     throw new NotImplementedException();
        // }
    }
}