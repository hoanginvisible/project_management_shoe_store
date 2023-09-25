using MediatR;
using Service.Handlers.Employer.Queries;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class EmployerService : IEmployerService
    {
        private readonly IMediator _mediator;

        public EmployerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EmployerDto> GetEmployer(string Email, string Password)
        {
            var query = new GetEmployerQuery
            {
                Email = Email,
                Password = Password
            };
            return await _mediator.Send(query);
        }
    }
}