using MediatR;

namespace Service.Handlers.Employers.Queries
{
    public record GetEmployerByEmailAndPasswordQuery : IRequest<EmployerDto?>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}