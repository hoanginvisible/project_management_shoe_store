using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Constants;
using Domain.Enums;

namespace Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LengthCode)]
        public string? Code { get; set; }

        [MaxLength(EntityProperties.LengthNamePerson)]
        public string? FullName { get; set; }

        [MaxLength(EntityProperties.LengthPhoneNumber)]
        public string? PhoneNumber { get; set; }

        [MaxLength(EntityProperties.LengthEmail)]
        public string? Email { get; set; }

        [MaxLength(EntityProperties.LengthAddress)]
        public string? Address { get; set; }

        public CustomerRank Rank { get; set; }
    }
}