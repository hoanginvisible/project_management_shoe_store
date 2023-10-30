using System.ComponentModel;

namespace QuanLyCuaHangBanGiay.Core.Domain.Enums
{
    public enum EmployerStatus
    {
        [Description("Đang làm việc")] Doing,
        [Description("Đã nghỉ làm")] NotDoning
    }
}