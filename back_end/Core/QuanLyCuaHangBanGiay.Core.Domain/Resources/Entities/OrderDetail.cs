using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Core.Domain.Common;
using QuanLyCuaHangBanGiay.Core.Domain.Constants;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class OrderDetail : BaseAuditableEntity
    {
        public string? IdOrder { get; set; }
        public string? IdProductDetail { get; set; }

        [MaxLength(EntityProperties.LengthName)]
        public string? NameProduct { get; set; }

        public Double? Sale { get; set; }
        public Double? Price { get; set; }
        public long? Quantity { get; set; }
    }
}