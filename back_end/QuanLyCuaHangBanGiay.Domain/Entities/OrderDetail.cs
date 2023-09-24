using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Domain.Common;
using QuanLyCuaHangBanGiay.Domain.Constants;

namespace QuanLyCuaHangBanGiay.Domain.Entities
{
    public class OrderDetail : BaseAuditableEntity
    
    
    {
        public Guid IdOrder { get; set; }
        public Guid IdProductDetail { get; set; }

        [MaxLength(EntityProperties.LENGTH_NAME)]
        public string NameProduct { get; set; }

        public decimal Sale { get; set; }
        public decimal Price { get; set; }
    }
}