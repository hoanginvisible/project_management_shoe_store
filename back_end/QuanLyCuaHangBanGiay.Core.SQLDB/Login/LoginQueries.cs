namespace QuanLyCuaHangBanGiay.Core.WebAPI.Login
{
    public class LoginQueries
    {
        internal const string LOGIN =
            $@"
            SELECT
                Role
            FROM 
                Employers
            WHERE
                Email = @Email
            AND 
                Password = @Password";
    }
}