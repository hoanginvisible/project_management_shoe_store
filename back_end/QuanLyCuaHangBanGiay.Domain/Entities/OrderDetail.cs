using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Constants;

namespace Domain.Entities
{
    public class OrderDetail : BaseAuditableEntity


    {
        public string IdOrder { get; set; }
        public string IdProductDetail { get; set; }

        [MaxLength(EntityProperties.LENGTH_NAME)]
        public string NameProduct { get; set; }

        public Double Sale { get; set; }
        public Double Price { get; set; }
    }
}