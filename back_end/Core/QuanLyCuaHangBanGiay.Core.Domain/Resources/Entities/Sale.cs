using QuanLyCuaHangBanGiay.Core.Domain.Common;
using QuanLyCuaHangBanGiay.Core.Domain.Enums;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class Sale : BaseAuditableEntity
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public SaleType? SaleType { get; set; }
        public Double? Value { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public SaleStatus? Status { get; set; }
    }
}