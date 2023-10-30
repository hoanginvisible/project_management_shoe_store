using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Core.Domain.Common;
using QuanLyCuaHangBanGiay.Core.Domain.Constants;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class Material : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LengthCode)]
        public string? Code { get; set; }

        [MaxLength(EntityProperties.LengthName)]
        public string? Name { get; set; }
    }
}