using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace htcssk.Models
{
    public partial class mytestdbContext : DbContext
    {
        public mytestdbContext()
        {
        }

        public mytestdbContext(DbContextOptions<mytestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bacsi> Bacsis { get; set; } = null!;
        public virtual DbSet<Benhnhan> Benhnhans { get; set; } = null!;
        public virtual DbSet<Chuyenkhoa> Chuyenkhoas { get; set; } = null!;
        public virtual DbSet<Dichvu> Dichvus { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Hotline> Hotlines { get; set; } = null!;
        public virtual DbSet<Thongtinthuoc> Thongtinthuocs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DUCVANCODER;Database=mytestdb;Integrated security=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bacsi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bacsi");

                entity.Property(e => e.ChuyenKhoa).HasMaxLength(50);

                entity.Property(e => e.IdBacSi).ValueGeneratedOnAdd();

                entity.Property(e => e.PhotoFileName).HasMaxLength(500);

                entity.Property(e => e.TenBacSi).HasMaxLength(50);
            });

            modelBuilder.Entity<Benhnhan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("benhnhan");

                entity.Property(e => e.BenhLi).HasMaxLength(50);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.IdBenhNhan).ValueGeneratedOnAdd();

                entity.Property(e => e.PhotoFileName).HasMaxLength(500);

                entity.Property(e => e.TenBenhNhan).HasMaxLength(50);
            });

            modelBuilder.Entity<Chuyenkhoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("chuyenkhoa");

                entity.Property(e => e.IdChuyenKhoa).ValueGeneratedOnAdd();

                entity.Property(e => e.TenChuyenKhoa).HasMaxLength(50);
            });

            modelBuilder.Entity<Dichvu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dichvu");

                entity.Property(e => e.Gia).HasMaxLength(50);

                entity.Property(e => e.IdDichVu).ValueGeneratedOnAdd();

                entity.Property(e => e.MoTa).HasMaxLength(50);

                entity.Property(e => e.TenDichVu).HasMaxLength(50);
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hoadon");

                entity.Property(e => e.IdBenhNhan).HasMaxLength(500);

                entity.Property(e => e.IdDichVu).HasMaxLength(50);

                entity.Property(e => e.IdHoaDon).ValueGeneratedOnAdd();

                entity.Property(e => e.IdThuoc).HasMaxLength(50);

                entity.Property(e => e.ThoiGian).HasColumnType("datetime");

                entity.Property(e => e.TienThanhToan).HasMaxLength(50);
            });

            modelBuilder.Entity<Hotline>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hotline");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Phong)
                    .HasMaxLength(50)
                    .HasColumnName("phong");

                entity.Property(e => e.Sohotline)
                    .HasMaxLength(50)
                    .HasColumnName("sohotline");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(50)
                    .HasColumnName("trangthai");
            });

            modelBuilder.Entity<Thongtinthuoc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("thongtinthuoc");

                entity.Property(e => e.GiaBan).HasMaxLength(50);

                entity.Property(e => e.IdThuoc).ValueGeneratedOnAdd();

                entity.Property(e => e.NhaPhanPhoi).HasMaxLength(50);

                entity.Property(e => e.SoLuong).HasMaxLength(50);

                entity.Property(e => e.TenThuoc).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
