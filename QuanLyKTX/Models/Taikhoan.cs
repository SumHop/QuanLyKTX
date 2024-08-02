using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Taikhoan
{
    public int Iduser { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public string? TenDayDu { get; set; }

    public string? VaiTro { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
