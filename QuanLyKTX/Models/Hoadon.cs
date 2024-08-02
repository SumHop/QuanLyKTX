using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Hoadon
{
    public int MaHd { get; set; }

    public DateOnly? NgayLapHddvbc { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? TrangThai { get; set; }

    public int? MaPhong { get; set; }

    public int? IdnhanVien { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();

    public virtual Nhanvien? IdnhanVienNavigation { get; set; }
}
