using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Service.Handlers.Orders.Command.Handler
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IRepository<Order> _repository;
        private readonly IDapperHelper _dapperHelper;

        public CreateOrderCommandHandler(IRepository<Order> repository, IDapperHelper dapperHelper)
        {
            _repository = repository;
            _dapperHelper = dapperHelper;
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            string query = $@"
                SELECT SUBSTRING(MAX(Code), 3, LEN(MAX(Code))) AS Code FROM [Order]
            ";
            string result = await _dapperHelper.ExecuteReturnScalar<string>(query);
            string code = "HD" + (Convert.ToInt32(result) + 1);
            Order order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Code = code,
                Status = OrderStatus.PendingPayment,
                CreatedDate = new DateTime(),
                LastModifiedDate = new DateTime()
            };
            await _repository.Insert(order);
            return await Task.FromResult(order.Id);
            // return null;
        }
    }
}