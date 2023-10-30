using Common.Brand.ResponseModels;
using MediatR;

namespace ClassLibrary1.Brand.Query
{
    public class GetAllBrandQuery : IRequest<IEnumerable<BrandModel>>
    {
    }
}