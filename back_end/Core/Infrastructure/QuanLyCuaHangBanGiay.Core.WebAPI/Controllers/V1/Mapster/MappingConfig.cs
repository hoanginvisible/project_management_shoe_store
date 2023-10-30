using Mapster;
using QuanLyCuaHangBanGiay.Core.Domain.Login;
using QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers.V1.Post;

namespace QuanLyCuaHangBanGiay.Core.WebAPIi.Controllers.V1.Mapster
{
    public class MappingConfig
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<LoginRequestModel, LoginParameter>
                .NewConfig()
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Password, src => src.Password);
        }
    }
}