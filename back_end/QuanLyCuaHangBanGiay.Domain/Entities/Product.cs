using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Domain.Common;
using QuanLyCuaHangBanGiay.Domain.Constants;

namespace QuanLyCuaHangBanGiay.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LENGTH_CODE)]
        public string Code { get; set; }

        [MaxLength(EntityProperties.LENGTH_NAME)]
        public string Name { get; set; }

        [MaxLength(EntityProperties.LENTH_DESCRIPTION)]
        public string Description { get; set; }
    }
}