﻿using Dapper;
using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Employers.Queries
{
    public record GetEmployerQuery : IRequest<EmployerDto>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class GetEmployerQueryHandle : IRequestHandler<GetEmployerQuery, EmployerDto>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetEmployerQueryHandle(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<EmployerDto> Handle(GetEmployerQuery request,
            CancellationToken cancellationToken)
        {
            string query = $@"
                SELECT Email, Password FROM Employers
                WHERE Email = @Email AND Password = @Password";
            var parameters = new DynamicParameters();
            parameters.Add("@Email", request.Email);
            parameters.Add("@Password", request.Password);
            return await _dapperHelper.ExecuteReturnScalar<EmployerDto>(query, parameters);
        }
    }
}