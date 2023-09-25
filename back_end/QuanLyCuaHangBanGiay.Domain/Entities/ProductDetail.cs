using Domain.Common;

namespace Domain.Entities
{
    public class ProductDetail : BaseAuditableEntity
    {
        public Guid IdProduct { get; set; }
        public Guid IdBrand { get; set; }
        public Guid IdCategory { get; set; }
        public Guid IdColor { get; set; }
        public Guid IdImage { get; set; }
        public Guid IdMaterial { get; set; }
        public Guid IdSize { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }
    }
}