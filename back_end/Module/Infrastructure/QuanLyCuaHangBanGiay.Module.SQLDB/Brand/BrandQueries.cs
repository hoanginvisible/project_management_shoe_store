namespace QuanLyCuaHangBanGiay.Module.SQLDB.Brand
{
    public class BrandQueries
    {
        internal const string GET_ALL_BRAND =
            $@"
            SELECT
                Id, Code, Name
            FROM 
                Brand";
    }
}

