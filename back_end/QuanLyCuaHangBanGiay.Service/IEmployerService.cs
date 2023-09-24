using Service.Employer.Queries;

namespace Service;

public interface IEmployerService
{
    Task<EmployerDto> GetEmployer(string Email, string Password);
}