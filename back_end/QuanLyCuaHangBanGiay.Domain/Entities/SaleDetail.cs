using Domain.Common;

namespace  Domain.Entities
{
    public class SaleDetail : BaseAuditableEntity
    {
        public Guid IdSale { get; set; }
        public Guid IdProductDetail { get; set; }
        public decimal Price { get; set; }
        public decimal ChangeAmount { get; set; }
    }
}