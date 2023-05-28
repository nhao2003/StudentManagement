﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentManagement.Models
{
    public partial class QUANLYHOCSINHContext : DbContext
    {
        public QUANLYHOCSINHContext()
        {
        }

        public QUANLYHOCSINHContext(DbContextOptions<QUANLYHOCSINHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diemmonhoc> Diemmonhocs { get; set; } = null!;
        public virtual DbSet<Giaovien> Giaoviens { get; set; } = null!;
        public virtual DbSet<Hanhkiem> Hanhkiems { get; set; } = null!;
        public virtual DbSet<Hocky> Hockies { get; set; } = null!;
        public virtual DbSet<Hocluc> Hoclucs { get; set; } = null!;
        public virtual DbSet<Hocsinh> Hocsinhs { get; set; } = null!;
        public virtual DbSet<Ketqua> Ketquas { get; set; } = null!;
        public virtual DbSet<Khananggiangday> Khananggiangdays { get; set; } = null!;
        public virtual DbSet<Kqhockymonhoc> Kqhockymonhocs { get; set; } = null!;
        public virtual DbSet<Kqhockytonghop> Kqhockytonghops { get; set; } = null!;
        public virtual DbSet<Kqnamhoc> Kqnamhocs { get; set; } = null!;
        public virtual DbSet<Loaikiemtra> Loaikiemtras { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<Lophocthucte> Lophocthuctes { get; set; } = null!;
        public virtual DbSet<Monhoc> Monhocs { get; set; } = null!;
        public virtual DbSet<Namhoc> Namhocs { get; set; } = null!;
        public virtual DbSet<Nhanvienphongdaotao> Nhanvienphongdaotaos { get; set; } = null!;
        public virtual DbSet<Phanconggiangday> Phanconggiangdays { get; set; } = null!;
        public virtual DbSet<Phh> Phhs { get; set; } = null!;
        public virtual DbSet<Taikhoan> Taikhoans { get; set; } = null!;
        public virtual DbSet<Thamso> Thamsos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ANH\\SQLEXPRESS;Initial Catalog=QUANLYHOCSINH;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diemmonhoc>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Mahk, e.Mamh, e.Malkt })
                    .HasName("PK__DIEMMONH__C4AB4E68669ECBC4");

                entity.ToTable("DIEMMONHOC");

                entity.Property(e => e.Mahs)
                    .HasMaxLength(7)
                    .HasColumnName("MAHS");

                entity.Property(e => e.Mahk)
                    .HasMaxLength(7)
                    .HasColumnName("MAHK");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(7)
                    .HasColumnName("MAMH");

                entity.Property(e => e.Malkt)
                    .HasMaxLength(7)
                    .HasColumnName("MALKT");

                entity.Property(e => e.Diem).HasColumnName("DIEM");

                entity.Property(e => e.Manh)
                    .HasMaxLength(7)
                    .HasColumnName("MANH");

                entity.HasOne(d => d.MahkNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Mahk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHOC__MAHK__628FA481");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHOC__MAHS__619B8048");

                entity.HasOne(d => d.MalktNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Malkt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHO__MALKT__656C112C");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHOC__MAMH__6383C8BA");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Manh)
                    .HasConstraintName("FK__DIEMMONHOC__MANH__6477ECF3");
            });

            modelBuilder.Entity<Giaovien>(entity =>
            {
                entity.HasKey(e => e.Magv)
                    .HasName("PK__GIAOVIEN__603F38B15F8C7834");

                entity.ToTable("GIAOVIEN");

                entity.Property(e => e.Magv)
                    .HasMaxLength(7)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Hocvi)
                    .HasMaxLength(50)
                    .HasColumnName("HOCVI");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Giaoviens)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GIAOVIEN__USERNA__412EB0B6");
            });

            modelBuilder.Entity<Hanhkiem>(entity =>
            {
                entity.HasKey(e => e.MaHanhKiem)
                    .HasName("PK__HANHKIEM__2B2C87ED2252B8C8");

                entity.ToTable("HANHKIEM");

                entity.Property(e => e.MaHanhKiem).HasMaxLength(7);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TenHanhKiem).HasMaxLength(50);
            });

            modelBuilder.Entity<Hocky>(entity =>
            {
                entity.HasKey(e => e.Mahk)
                    .HasName("PK__HOCKY__603F20C5345D193D");

                entity.ToTable("HOCKY");

                entity.Property(e => e.Mahk)
                    .HasMaxLength(7)
                    .HasColumnName("MAHK");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tenhk)
                    .HasMaxLength(20)
                    .HasColumnName("TENHK");
            });

            modelBuilder.Entity<Hocluc>(entity =>
            {
                entity.HasKey(e => e.MaHocLuc)
                    .HasName("PK__HOCLUC__97954DD537D211C1");

                entity.ToTable("HOCLUC");

                entity.Property(e => e.MaHocLuc).HasMaxLength(7);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TenHocLuc).HasMaxLength(50);
            });

            modelBuilder.Entity<Hocsinh>(entity =>
            {
                entity.HasKey(e => e.Mahs)
                    .HasName("PK__HOCSINH__603F20DDA06FC7F6");

                entity.ToTable("HOCSINH");

                entity.Property(e => e.Mahs)
                    .HasMaxLength(7)
                    .HasColumnName("MAHS");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(12)
                    .HasColumnName("CCCD");

                entity.Property(e => e.Dantoc)
                    .HasMaxLength(10)
                    .HasColumnName("DANTOC");

                entity.Property(e => e.Dchi)
                    .HasMaxLength(250)
                    .HasColumnName("DCHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("GIOITINH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hotenhs)
                    .HasMaxLength(100)
                    .HasColumnName("HOTENHS");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ngsinh)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("NGSINH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tongiao)
                    .HasMaxLength(10)
                    .HasColumnName("TONGIAO");
            });

            modelBuilder.Entity<Ketqua>(entity =>
            {
                entity.HasKey(e => e.MaKetQua)
                    .HasName("PK__KETQUA__D5B3102A2AAC853F");

                entity.ToTable("KETQUA");

                entity.Property(e => e.MaKetQua).HasMaxLength(7);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TenKetQua).HasMaxLength(50);
            });

            modelBuilder.Entity<Khananggiangday>(entity =>
            {
                entity.HasKey(e => new { e.Magv, e.Mamh })
                    .HasName("PK__KHANANGG__C63CCE2FCB8E4AC6");

                entity.ToTable("KHANANGGIANGDAY");

                entity.Property(e => e.Magv)
                    .HasMaxLength(7)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(7)
                    .HasColumnName("MAMH");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Khananggiangdays)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KHANANGGIA__MAGV__03F0984C");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Khananggiangdays)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KHANANGGIA__MAMH__04E4BC85");
            });

            modelBuilder.Entity<Kqhockymonhoc>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Mamh, e.Mahk, e.Manh })
                    .HasName("PK__KQHOCKYM__12EAEA964BA63607");

                entity.ToTable("KQHOCKYMONHOC");

                entity.Property(e => e.Mahs)
                    .HasMaxLength(7)
                    .HasColumnName("MAHS");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(7)
                    .HasColumnName("MAMH");

                entity.Property(e => e.Mahk)
                    .HasMaxLength(7)
                    .HasColumnName("MAHK");

                entity.Property(e => e.Manh)
                    .HasMaxLength(7)
                    .HasColumnName("MANH");

                entity.Property(e => e.DtbmonHocKy).HasColumnName("DTBMonHocKy");

                entity.HasOne(d => d.MahkNavigation)
                    .WithMany(p => p.Kqhockymonhocs)
                    .HasForeignKey(d => d.Mahk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYMON__MAHK__72C60C4A");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Kqhockymonhocs)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYMON__MAHS__70DDC3D8");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Kqhockymonhocs)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYMON__MAMH__71D1E811");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Kqhockymonhocs)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYMON__MANH__73BA3083");
            });

            modelBuilder.Entity<Kqhockytonghop>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Mahk, e.Manh })
                    .HasName("PK__KQHOCKYT__2D5CED80911DC8FB");

                entity.ToTable("KQHOCKYTONGHOP");

                entity.Property(e => e.Mahs)
                    .HasMaxLength(7)
                    .HasColumnName("MAHS");

                entity.Property(e => e.Mahk)
                    .HasMaxLength(7)
                    .HasColumnName("MAHK");

                entity.Property(e => e.Manh)
                    .HasMaxLength(7)
                    .HasColumnName("MANH");

                entity.Property(e => e.DtbtatCaMonHocKy).HasColumnName("DTBTatCaMonHocKy");

                entity.Property(e => e.MaHanhKiem).HasMaxLength(7);

                entity.Property(e => e.MaHocLuc).HasMaxLength(7);

                entity.HasOne(d => d.MaHanhKiemNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.MaHanhKiem)
                    .HasConstraintName("FK__KQHOCKYTO__MaHan__7A672E12");

                entity.HasOne(d => d.MaHocLucNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.MaHocLuc)
                    .HasConstraintName("FK__KQHOCKYTO__MaHoc__797309D9");

                entity.HasOne(d => d.MahkNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.Mahk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYTON__MAHK__778AC167");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYTON__MAHS__76969D2E");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYTON__MANH__787EE5A0");
            });

            modelBuilder.Entity<Kqnamhoc>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Manh })
                    .HasName("PK__KQNAMHOC__D63CD5CD2F1754CF");

                entity.ToTable("KQNAMHOC");

                entity.Property(e => e.Mahs)
                    .HasMaxLength(7)
                    .HasColumnName("MAHS");

                entity.Property(e => e.Manh)
                    .HasMaxLength(7)
                    .HasColumnName("MANH");

                entity.Property(e => e.MaHanhKiem).HasMaxLength(7);

                entity.Property(e => e.MaHocLuc).HasMaxLength(7);

                entity.Property(e => e.MaKetQua).HasMaxLength(7);

                entity.HasOne(d => d.MaHanhKiemNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.MaHanhKiem)
                    .HasConstraintName("FK__KQNAMHOC__MaHanh__00200768");

                entity.HasOne(d => d.MaHocLucNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.MaHocLuc)
                    .HasConstraintName("FK__KQNAMHOC__MaHocL__7F2BE32F");

                entity.HasOne(d => d.MaKetQuaNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.MaKetQua)
                    .HasConstraintName("FK__KQNAMHOC__MaKetQ__01142BA1");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQNAMHOC__MAHS__7D439ABD");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQNAMHOC__MANH__7E37BEF6");
            });

            modelBuilder.Entity<Loaikiemtra>(entity =>
            {
                entity.HasKey(e => e.Malkt)
                    .HasName("PK__LOAIKIEM__7A3D008EAE739B1C");

                entity.ToTable("LOAIKIEMTRA");

                entity.Property(e => e.Malkt)
                    .HasMaxLength(7)
                    .HasColumnName("MALKT");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tenloaikiemtra)
                    .HasMaxLength(50)
                    .HasColumnName("TENLOAIKIEMTRA");

                entity.Property(e => e.Tile).HasColumnName("TILE");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.Malop)
                    .HasName("PK__LOP__7A3DE211429FC3C5");

                entity.ToTable("LOP");

                entity.Property(e => e.Malop)
                    .HasMaxLength(7)
                    .HasColumnName("MALOP");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Khoi).HasColumnName("KHOI");

                entity.Property(e => e.Tenlop)
                    .HasMaxLength(7)
                    .HasColumnName("TENLOP");
            });

            modelBuilder.Entity<Lophocthucte>(entity =>
            {
                entity.HasKey(e => e.Malhtt)
                    .HasName("PK__LOPHOCTH__353317E42535E89C");

                entity.ToTable("LOPHOCTHUCTE");

                entity.Property(e => e.Malhtt)
                    .HasMaxLength(10)
                    .HasColumnName("MALHTT");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Magvcn)
                    .HasMaxLength(7)
                    .HasColumnName("MAGVCN");

                entity.Property(e => e.Malop)
                    .HasMaxLength(7)
                    .HasColumnName("MALOP");

                entity.Property(e => e.Manh)
                    .HasMaxLength(7)
                    .HasColumnName("MANH");

                entity.HasOne(d => d.MagvcnNavigation)
                    .WithMany(p => p.Lophocthuctes)
                    .HasForeignKey(d => d.Magvcn)
                    .HasConstraintName("FK__LOPHOCTHU__MAGVC__571DF1D5");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Lophocthuctes)
                    .HasForeignKey(d => d.Malop)
                    .HasConstraintName("FK__LOPHOCTHU__MALOP__5535A963");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Lophocthuctes)
                    .HasForeignKey(d => d.Manh)
                    .HasConstraintName("FK__LOPHOCTHUC__MANH__5629CD9C");

                entity.HasMany(d => d.Mahs)
                    .WithMany(p => p.Malhtts)
                    .UsingEntity<Dictionary<string, object>>(
                        "LophocthucteHocsinh",
                        l => l.HasOne<Hocsinh>().WithMany().HasForeignKey("Mahs").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LOPHOCTHUC__MAHS__5BE2A6F2"),
                        r => r.HasOne<Lophocthucte>().WithMany().HasForeignKey("Malhtt").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LOPHOCTHU__MALHT__5AEE82B9"),
                        j =>
                        {
                            j.HasKey("Malhtt", "Mahs").HasName("PK__LOPHOCTH__F330E5E968883F1A");

                            j.ToTable("LOPHOCTHUCTE_HOCSINH");

                            j.IndexerProperty<string>("Malhtt").HasMaxLength(10).HasColumnName("MALHTT");

                            j.IndexerProperty<string>("Mahs").HasMaxLength(7).HasColumnName("MAHS");
                        });
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.Mamh)
                    .HasName("PK__MONHOC__603F69EB42C1576A");

                entity.ToTable("MONHOC");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(7)
                    .HasColumnName("MAMH");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tenmh)
                    .HasMaxLength(30)
                    .HasColumnName("TENMH");
            });

            modelBuilder.Entity<Namhoc>(entity =>
            {
                entity.HasKey(e => e.Manh)
                    .HasName("PK__NAMHOC__603F510A8CE73F0D");

                entity.ToTable("NAMHOC");

                entity.Property(e => e.Manh)
                    .HasMaxLength(7)
                    .HasColumnName("MANH");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tennamhoc)
                    .HasMaxLength(20)
                    .HasColumnName("TENNAMHOC");
            });

            modelBuilder.Entity<Nhanvienphongdaotao>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("PK__NHANVIEN__603F51147EEA6D51");

                entity.ToTable("NHANVIENPHONGDAOTAO");

                entity.Property(e => e.Manv)
                    .HasMaxLength(7)
                    .HasColumnName("MANV");

                entity.Property(e => e.Chucvu)
                    .HasMaxLength(50)
                    .HasColumnName("CHUCVU");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Nhanvienphongdaotaos)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NHANVIENP__USERN__44FF419A");
            });

            modelBuilder.Entity<Phanconggiangday>(entity =>
            {
                entity.HasKey(e => new { e.Manh, e.Malhtt, e.Mamh, e.Magv })
                    .HasName("PK__PHANCONG__520A5CEED15C2CFE");

                entity.ToTable("PHANCONGGIANGDAY");

                entity.Property(e => e.Manh)
                    .HasMaxLength(7)
                    .HasColumnName("MANH");

                entity.Property(e => e.Malhtt)
                    .HasMaxLength(10)
                    .HasColumnName("MALHTT");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(7)
                    .HasColumnName("MAMH");

                entity.Property(e => e.Magv)
                    .HasMaxLength(7)
                    .HasColumnName("MAGV");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MagvNavigation)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => d.Magv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGGI__MAGV__0A9D95DB");

                entity.HasOne(d => d.MalhttNavigation)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => d.Malhtt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGG__MALHT__09A971A2");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGGI__MAMH__0B91BA14");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGGI__MANH__08B54D69");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => new { d.Magv, d.Mamh })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGGIANGDAY__0D7A0286");
            });

            modelBuilder.Entity<Phh>(entity =>
            {
                entity.HasKey(e => e.Maphhs)
                    .HasName("PK__PHHS__5401D0A5FD1EEFE0");

                entity.ToTable("PHHS");

                entity.Property(e => e.Maphhs)
                    .HasMaxLength(7)
                    .HasColumnName("MAPHHS");

                entity.Property(e => e.Hotenphhs)
                    .HasMaxLength(100)
                    .HasColumnName("HOTENPHHS");

                entity.Property(e => e.Mahs)
                    .HasMaxLength(7)
                    .HasColumnName("MAHS");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .HasColumnName("SDT");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Phhs)
                    .HasForeignKey(d => d.Mahs)
                    .HasConstraintName("FK__PHHS__MAHS__4CA06362");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__TAIKHOAN__B15BE12F3AB23FCB");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Dchi)
                    .HasMaxLength(250)
                    .HasColumnName("DCHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("GIOITINH")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(100)
                    .HasColumnName("HOTEN");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ngsinh)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("NGSINH");

                entity.Property(e => e.Passwrd)
                    .HasMaxLength(100)
                    .HasColumnName("PASSWRD");

                entity.Property(e => e.Vaitro)
                    .HasMaxLength(7)
                    .HasColumnName("VAITRO");
            });

            modelBuilder.Entity<Thamso>(entity =>
            {
                entity.ToTable("THAMSO");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(1000)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Giatri)
                    .HasMaxLength(1000)
                    .HasColumnName("GIATRI");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tents)
                    .HasMaxLength(100)
                    .HasColumnName("TENTS");

                entity.Property(e => e.Typets)
                    .HasMaxLength(100)
                    .HasColumnName("TYPETS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
