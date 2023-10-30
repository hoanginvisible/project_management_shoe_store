using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Core.Domain.Common;
using QuanLyCuaHangBanGiay.Core.Domain.Constants;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class Image : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LengthCode)]
        public string? Name { get; set; }

        public string? Path { get; set; }
    }
}