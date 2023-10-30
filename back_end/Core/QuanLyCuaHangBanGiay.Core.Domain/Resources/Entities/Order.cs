using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Core.Domain.Common;
using QuanLyCuaHangBanGiay.Core.Domain.Constants;
using QuanLyCuaHangBanGiay.Core.Domain.Enums;

namespace QuanLyCuaHangBanGiay.Core.Domain.Resources.Entities
{
    public class Order : BaseAuditableEntity
    {
        public string? IdCustomer { get; set; }
        public string? IdEmployer { get; set; }

        [MaxLength(EntityProperties.LengthCode)]
        public string? Code { get; set; }

        public Double? CustomerPayment { get; set; }
        public Double? BankTransfer { get; set; }
        public Double? ChangeAmount { get; set; }
        public Double? TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }
}