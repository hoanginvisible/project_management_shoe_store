using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Constants;

namespace Domain.Entities
{
    public class Image : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LengthCode)]
        public string? Name { get; set; }

        public string? Path { get; set; }
    }
}