using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyKTX.Models;

public partial class QlktxContext : DbContext
{
    public QlktxContext()
    {
    }

    public QlktxContext(DbContextOptions<QlktxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }

    public virtual DbSet<Dichvu> Dichvus { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Hopdong> Hopdongs { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<Phuhuynh> Phuhuynhs { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-US5EJJRM\\SQLEXPRESS;Initial Catalog=QLKTX;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitiethoadon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaDv }).HasName("PK_CHITIETHOADONDVBV");

            entity.ToTable("CHITIETHOADON");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaDv).HasColumnName("MaDV");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.MaDv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETHOADON_DICHVU");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETHOADON_HOADON");
        });

        modelBuilder.Entity<Dichvu>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK_DICHVUBATBUOC");

            entity.ToTable("DICHVU");

            entity.Property(e => e.MaDv).HasColumnName("MaDV");
            entity.Property(e => e.Dvt)
                .HasMaxLength(50)
                .HasColumnName("DVT");
            entity.Property(e => e.TenDichVuBatBuoc).HasMaxLength(50);
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK_HOADONDVBATBUOC");

            entity.ToTable("HOADON");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.IdnhanVien).HasColumnName("IDNhanVien");
            entity.Property(e => e.NgayLapHddvbc).HasColumnName("NgayLapHDDVBC");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdnhanVienNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.IdnhanVien)
                .HasConstraintName("FK_HOADON_NHANVIEN");
        });

        modelBuilder.Entity<Hopdong>(entity =>
        {
            entity.HasKey(e => e.SoHopDong);

            entity.ToTable("HOPDONG");

            entity.Property(e => e.IdnhanVien).HasColumnName("IDNhanVien");
            entity.Property(e => e.IdsinhVien).HasColumnName("IDSinhVien");
            entity.Property(e => e.NgayLapHd).HasColumnName("NgayLapHD");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.ThoiGianThue).HasMaxLength(50);

            entity.HasOne(d => d.IdnhanVienNavigation).WithMany(p => p.Hopdongs)
                .HasForeignKey(d => d.IdnhanVien)
                .HasConstraintName("FK_HOPDONG_NHANVIEN");

            entity.HasOne(d => d.IdsinhVienNavigation).WithMany(p => p.Hopdongs)
                .HasForeignKey(d => d.IdsinhVien)
                .HasConstraintName("FK_HOPDONG_SINHVIEN");

            entity.HasMany(d => d.MaPhongs).WithMany(p => p.SohopDongs)
                .UsingEntity<Dictionary<string, object>>(
                    "Chitiethopdong",
                    r => r.HasOne<Phong>().WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CHITIETHOPDONG_PHONG"),
                    l => l.HasOne<Hopdong>().WithMany()
                        .HasForeignKey("SohopDong")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CHITIETHOPDONG_HOPDONG"),
                    j =>
                    {
                        j.HasKey("SohopDong", "MaPhong");
                        j.ToTable("CHITIETHOPDONG");
                        j.IndexerProperty<int>("SohopDong").HasColumnName("SOHopDong");
                    });
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.IdnhanVien);

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.IdnhanVien).HasColumnName("IDNhanVien");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("SDT");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_NHANVIEN_TAIKHOAN");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong);

            entity.ToTable("PHONG");

            entity.Property(e => e.Khu).HasMaxLength(10);
            entity.Property(e => e.Tang).HasMaxLength(10);
            entity.Property(e => e.TenPhong).HasMaxLength(10);
        });

        modelBuilder.Entity<Phuhuynh>(entity =>
        {
            entity.HasKey(e => e.IdphuHuynh);

            entity.ToTable("PHUHUYNH");

            entity.Property(e => e.IdphuHuynh).HasColumnName("IDPhuHuynh");
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.IdsinhVien).HasColumnName("IDSinhVien");
            entity.Property(e => e.NgheNghiep).HasMaxLength(50);
            entity.Property(e => e.QuanHe).HasMaxLength(20);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("SDT");

            entity.HasOne(d => d.IdsinhVienNavigation).WithMany(p => p.Phuhuynhs)
                .HasForeignKey(d => d.IdsinhVien)
                .HasConstraintName("FK_PHUHUYNH_SINHVIEN");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.IdsinhVien);

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.IdsinhVien).HasColumnName("IDSinhVien");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.Khoa).HasMaxLength(50);
            entity.Property(e => e.Lop).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .HasColumnName("SDT");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.TenSinhVien).HasMaxLength(50);

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_SINHVIEN_TAIKHOAN");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Iduser);

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.MatKhau).HasMaxLength(20);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.TenDayDu).HasMaxLength(50);
            entity.Property(e => e.VaiTro).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
