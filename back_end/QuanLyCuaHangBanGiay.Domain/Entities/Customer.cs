using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Constants;
using Domain.Enums;

namespace Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LENGTH_CODE)]
        public string Code { get; set; }

        [MaxLength(EntityProperties.LENGTH_NAME_PERSON)]
        public string FullName { get; set; }

        [MaxLength(EntityProperties.LENGTH_PHONE_NUMBER)]
        public string PhoneNumber { get; set; }

        [MaxLength(EntityProperties.LENGTH_EMAIL)]
        public string Email { get; set; }

        [MaxLength(EntityProperties.LENGTH_ADDRESS)]
        public string Address { get; set; }

        public CustomerRank Rank { get; set; }
    }
}