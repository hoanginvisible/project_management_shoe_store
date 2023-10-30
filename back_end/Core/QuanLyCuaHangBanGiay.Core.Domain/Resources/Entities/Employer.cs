using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Core.Domain.Common;
using QuanLyCuaHangBanGiay.Core.Domain.Constants;
using QuanLyCuaHangBanGiay.Core.Domain.Enums;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class Employer : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LengthCode)]
        public string? Code { get; set; }

        [MaxLength(EntityProperties.LengthNamePerson)]
        public string? FullName { get; set; }

        public Gender Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(EntityProperties.LengthAddress)]
        public string? Address { get; set; }

        [MaxLength(EntityProperties.LengthPhoneNumber)]
        public string? PhoneNumber { get; set; }

        [MaxLength(EntityProperties.LengthEmail)]
        public string? Email { get; set; }

        public EmployerStatus Status;
        public EmployerRole Role { get; set; }

        [MaxLength(EntityProperties.LenthPassword)]
        public string? Password { get; set; }
    }
}