using Service.Handlers.Employer.Queries;

namespace Service.Services.Interfaces
{
    public interface IEmployerService
    {
        Task<EmployerDto> GetEmployer(string Email, string Password);
    }
}