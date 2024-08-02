using System;
using System.Collections.Generic;

namespace QuanLyKTX.Models;

public partial class Phuhuynh
{
    public int IdphuHuynh { get; set; }

    public string? HoTen { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? NgheNghiep { get; set; }

    public string? Sdt { get; set; }

    public string? QuanHe { get; set; }

    public int? IdsinhVien { get; set; }

    public virtual Sinhvien? IdsinhVienNavigation { get; set; }
}
