using QuanLyCuaHangBanGiay.Core.Domain.Common;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class ProductDetail : BaseAuditableEntity
    {
        public string? IdProduct { get; set; }
        public string? IdBrand { get; set; }
        public string? IdCategory { get; set; }
        public string? IdColor { get; set; }
        public string? IdImage { get; set; }
        public string? IdMaterial { get; set; }
        public string? IdSize { get; set; }
        public Double? Price { get; set; }
        public long? Quantity { get; set; }
    }
}