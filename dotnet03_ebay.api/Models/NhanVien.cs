using System;
using System.Collections.Generic;

namespace dotnet03_ebay.api.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public string? TenNhanVien { get; set; }

    public decimal? Luong { get; set; }

    public int? PhongBan { get; set; }

    public string? GioiTinh { get; set; }

    public virtual PhongBan? PhongBanNavigation { get; set; }
}
