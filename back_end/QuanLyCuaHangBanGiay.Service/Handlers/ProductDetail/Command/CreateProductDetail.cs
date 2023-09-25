using MediatR;

namespace Service.Handlers.ProductDetail.Command
{
    public class CreateProductDetail : IRequest<Boolean>
    {
    }

// public class CreateProductDetailHandler : IRequestHandler<CreateProductDetail, Boolean>
// {
//     private readonly IDapperHelper _dapperHelper;
//     
//     public CreateProductDetailHandler(IDapperHelper dapperHelper)
//     {
//         _dapperHelper = dapperHelper;
//     }
//     public async Task<> 
// }
}