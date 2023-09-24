using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Domain.Common;
using QuanLyCuaHangBanGiay.Domain.Constants;

namespace QuanLyCuaHangBanGiay.Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        public Guid IdCustomer { get; set; }
        public Guid IdEmployer { get; set; }

        [MaxLength(EntityProperties.LENGTH_CODE)]
        public string Code { get; set; }

        public decimal CustomerPayment { get; set; }
        public decimal BankTransfer { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}