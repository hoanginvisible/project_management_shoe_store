using Common.Brand.ResponseModels;
using Common.Repositories.Brand.Query;
using MediatR;

namespace ClassLibrary1.Brand.Query
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<BrandModel>>
    {
        private readonly IBrandQueryRepository BrandQueryRepository;

        public GetAllBrandQueryHandler(IBrandQueryRepository brandQueryRepository)
        {
            this.BrandQueryRepository = brandQueryRepository;
        }

        public async Task<IEnumerable<BrandModel>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var result = await BrandQueryRepository.GetAllBrand();
            return result;
        }
    }
}