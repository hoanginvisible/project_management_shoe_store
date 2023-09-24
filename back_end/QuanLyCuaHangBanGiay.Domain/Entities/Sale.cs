using QuanLyCuaHangBanGiay.Domain.Common;
using QuanLyCuaHangBanGiay.Domain.Enums;

namespace QuanLyCuaHangBanGiay.Domain.Entities
{
    public class Sale : BaseAuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public SaleType SaleType { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SaleStatus Status { get; set; }
    }
}