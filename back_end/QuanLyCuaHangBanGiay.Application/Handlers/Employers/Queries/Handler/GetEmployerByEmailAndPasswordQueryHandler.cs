using Dapper;
using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Employers.Queries.Handler
{
    public class
        GetEmployerByEmailAndPasswordQueryHandler : IRequestHandler<GetEmployerByEmailAndPasswordQuery, EmployerDto?>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetEmployerByEmailAndPasswordQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<EmployerDto?> Handle(GetEmployerByEmailAndPasswordQuery request,
            CancellationToken cancellationToken)
        {
            string query = $@"
                SELECT Email, Password, Role FROM Employers
                WHERE Email = @Email AND Password = @Password";
            var parameters = new DynamicParameters();
            parameters.Add("@Email", request.Email);
            parameters.Add("@Password", request.Password);
            return await _dapperHelper.ExecuteReturnScalar<EmployerDto>(query, parameters);
        }
    }
}