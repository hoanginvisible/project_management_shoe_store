using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
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