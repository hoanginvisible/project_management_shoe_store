using QuanLyCuaHangBanGiay.Core.Domain.Common;

namespace  QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class SaleDetail : BaseAuditableEntity
    {
        public string? IdSale { get; set; }
        public string? IdProductDetail { get; set; }
        public Double? Price { get; set; }
        public Double? ChangeAmount { get; set; }
    }
}