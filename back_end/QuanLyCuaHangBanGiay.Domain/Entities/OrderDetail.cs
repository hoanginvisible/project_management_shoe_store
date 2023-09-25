using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Constants;

namespace Domain.Entities
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