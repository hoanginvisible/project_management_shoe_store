using Data.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.ProductDetail.Command
{
    public record DeleteProductDetailCommand : IRequest<string>
    {
        public string id;
    }

    public class DeleteProductDetailCommandHandler : IRequestHandler<DeleteProductDetailCommand, string>
    {
        
        public IRepository<Domain.Entities.ProductDetail> _repository;

        public DeleteProductDetailCommandHandler(IRepository<Domain.Entities.ProductDetail> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.ProductDetail productDetail = await _repository.GetById(Guid.Parse(request.id));
            if(productDetail == null)
            {
                return null;
            }
            _repository.Delete(productDetail);
            return request.id;
        }

        //public Task<int> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        //{
        //    Domain.Entities.ProductDetail productDetail = _repository.GetById(Guid.Parse(request.id));
        //    _repository.Delete
        //    throw new NotImplementedException();
        //}
    }
}