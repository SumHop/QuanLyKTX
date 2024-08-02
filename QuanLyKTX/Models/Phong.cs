using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Phong
{
    public int MaPhong { get; set; }

    public string? TenPhong { get; set; }

    public string? Khu { get; set; }

    public string? Tang { get; set; }

    public int? SoGiuong { get; set; }

    public int? SoNguoiO { get; set; }

    public int? DonGia { get; set; }

    public virtual ICollection<Hopdong> SohopDongs { get; set; } = new List<Hopdong>();
}
