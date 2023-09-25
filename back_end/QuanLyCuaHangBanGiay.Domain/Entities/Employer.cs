﻿using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Constants;
using Domain.Enums;

namespace Domain.Entities
{
    public class Employer : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LENGTH_CODE)]
        public string Code { get; set; }

        [MaxLength(EntityProperties.LENGTH_NAME_PERSON)]
        public string FullName { get; set; }

        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(EntityProperties.LENGTH_ADDRESS)]
        public string Address { get; set; }

        [MaxLength(EntityProperties.LENGTH_PHONE_NUMBER)]
        public string PhoneNumber { get; set; }

        [MaxLength(EntityProperties.LENGTH_EMAIL)]
        public string Email { get; set; }

        public EmployerStatus Status;
        public EmployerRole Role { get; set; }

        [MaxLength(EntityProperties.LENTH_PASSWORD)]
        public string Password { get; set; }
    }
}