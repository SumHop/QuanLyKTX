using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Chitiethoadon
{
    public int MaHd { get; set; }

    public int MaDv { get; set; }

    public int? ChiSoDau { get; set; }

    public int? ChiSoCuoi { get; set; }

    public virtual Dichvu MaDvNavigation { get; set; } = null!;

    public virtual Hoadon MaHdNavigation { get; set; } = null!;
}
