using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Nhanvien
{
    public int IdnhanVien { get; set; }

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? ChucVu { get; set; }

    public int? Iduser { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual ICollection<Hopdong> Hopdongs { get; set; } = new List<Hopdong>();

    public virtual Taikhoan? IduserNavigation { get; set; }
}
