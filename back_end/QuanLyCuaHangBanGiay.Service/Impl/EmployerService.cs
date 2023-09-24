using MediatR;
using Service.Employer.Queries;

namespace Service.Impl;

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