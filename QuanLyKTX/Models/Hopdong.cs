using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Hopdong
{
    public int SoHopDong { get; set; }

    public DateOnly? NgayLapHd { get; set; }

    public string? ThoiGianThue { get; set; }

    public int? TienKyQuy { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public int? IdnhanVien { get; set; }

    public int? IdsinhVien { get; set; }

    public virtual Nhanvien? IdnhanVienNavigation { get; set; }

    public virtual Sinhvien? IdsinhVienNavigation { get; set; }

    public virtual ICollection<Phong> MaPhongs { get; set; } = new List<Phong>();
}
