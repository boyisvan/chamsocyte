using System;
using System.Collections.Generic;

namespace htcssk.Models
{
    public partial class Hoadon
    {
        public int IdHoaDon { get; set; }
        public string? IdDichVu { get; set; }
        public string? IdThuoc { get; set; }
        public string? TienThanhToan { get; set; }
        public DateTime? ThoiGian { get; set; }
        public string? IdBenhNhan { get; set; }
    }
}
