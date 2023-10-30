using Common.Brand.ResponseModels;
using Common.Repositories.Brand.Query;
using Dapper;
using QuanLyCuaHangBanGiay.Core.WebAPI.Dapper;

namespace QuanLyCuaHangBanGiay.Module.SQLDB.Brand.Query
{
    public class BrandQueryRepository : IBrandQueryRepository
    {
        private readonly DapperContext dapperContext;

        public BrandQueryRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        public async Task<IEnumerable<BrandModel>> GetAllBrand()
        {
            var query = BrandQueries.GET_ALL_BRAND;
            using var connection = dapperContext.CreateConnection();
            var result = connection.QueryAsync<BrandModel>(query);
            return await result;
        }
    }
}