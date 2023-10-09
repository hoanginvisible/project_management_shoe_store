using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Constants;

namespace Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LengthCode)]
        public string? Code { get; set; }

        [MaxLength(EntityProperties.LengthName)]
        public string? Name { get; set; }

        [MaxLength(EntityProperties.LenthDescription)]
        public string? Description { get; set; }
    }
}