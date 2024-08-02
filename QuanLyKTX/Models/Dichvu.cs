using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Dichvu
{
    public int MaDv { get; set; }

    public string? TenDichVuBatBuoc { get; set; }

    public int? DinhMuc { get; set; }

    public int? DonGia { get; set; }

    public string? Dvt { get; set; }

    public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; } = new List<Chitiethoadon>();
}
