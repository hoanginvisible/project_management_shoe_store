using System.ComponentModel.DataAnnotations;
using QuanLyCuaHangBanGiay.Domain.Common;
using QuanLyCuaHangBanGiay.Domain.Constants;

namespace QuanLyCuaHangBanGiay.Domain.Entities
{
    public class Image : BaseAuditableEntity
    {
        [MaxLength(EntityProperties.LENGTH_CODE)]
        public string name { get; set; }

        public string Path { get; set; }
    }
}