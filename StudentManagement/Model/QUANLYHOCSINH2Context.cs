using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;

namespace StudentManagement.Model
{
    public partial class QUANLYHOCSINH2Context : DbContext
    {
        public QUANLYHOCSINH2Context()
        {
        }

        public QUANLYHOCSINH2Context(DbContextOptions<QUANLYHOCSINH2Context> options)
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
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diemmonhoc>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Mahk, e.Mamh, e.Malkt })
                    .HasName("PK__DIEMMONH__C4AB4E68E6D6F5E8");

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

                entity.HasOne(d => d.MahkNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Mahk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHOC__MAHK__74AE54BC");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHOC__MAHS__73BA3083");

                entity.HasOne(d => d.MalktNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Malkt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHO__MALKT__76969D2E");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Diemmonhocs)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIEMMONHOC__MAMH__75A278F5");
            });

            modelBuilder.Entity<Giaovien>(entity =>
            {
                entity.HasKey(e => e.Magv)
                    .HasName("PK__GIAOVIEN__603F38B125881CC3");

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
                    .HasConstraintName("FK__GIAOVIEN__USERNA__534D60F1");
            });

            modelBuilder.Entity<Hanhkiem>(entity =>
            {
                entity.HasKey(e => e.MaHanhKiem)
                    .HasName("PK__HANHKIEM__2B2C87EDCB80E34D");

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
                    .HasName("PK__HOCKY__603F20C59445FAE8");

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
                    .HasName("PK__HOCLUC__97954DD5FC1FA5B7");

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
                    .HasName("PK__HOCSINH__603F20DD745D602F");

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
                    .HasName("PK__KETQUA__D5B3102A72D0761D");

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
                    .HasName("PK__KHANANGG__C63CCE2FBCFF80B1");

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
                    .HasConstraintName("FK__KHANANGGIA__MAGV__151B244E");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Khananggiangdays)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KHANANGGIA__MAMH__160F4887");
            });

            modelBuilder.Entity<Kqhockymonhoc>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Mamh, e.Mahk, e.Manh })
                    .HasName("PK__KQHOCKYM__12EAEA96FAA3A1D0");

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
                    .HasConstraintName("FK__KQHOCKYMON__MAHK__03F0984C");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Kqhockymonhocs)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYMON__MAHS__02084FDA");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Kqhockymonhocs)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYMON__MAMH__02FC7413");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Kqhockymonhocs)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYMON__MANH__04E4BC85");
            });

            modelBuilder.Entity<Kqhockytonghop>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Mahk, e.Manh })
                    .HasName("PK__KQHOCKYT__2D5CED8058F39F42");

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
                    .HasConstraintName("FK__KQHOCKYTO__MaHan__0B91BA14");

                entity.HasOne(d => d.MaHocLucNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.MaHocLuc)
                    .HasConstraintName("FK__KQHOCKYTO__MaHoc__0A9D95DB");

                entity.HasOne(d => d.MahkNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.Mahk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYTON__MAHK__08B54D69");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYTON__MAHS__07C12930");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Kqhockytonghops)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQHOCKYTON__MANH__09A971A2");
            });

            modelBuilder.Entity<Kqnamhoc>(entity =>
            {
                entity.HasKey(e => new { e.Mahs, e.Manh })
                    .HasName("PK__KQNAMHOC__D63CD5CD45865D3F");

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
                    .HasConstraintName("FK__KQNAMHOC__MaHanh__114A936A");

                entity.HasOne(d => d.MaHocLucNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.MaHocLuc)
                    .HasConstraintName("FK__KQNAMHOC__MaHocL__10566F31");

                entity.HasOne(d => d.MaKetQuaNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.MaKetQua)
                    .HasConstraintName("FK__KQNAMHOC__MaKetQ__123EB7A3");

                entity.HasOne(d => d.MahsNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.Mahs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQNAMHOC__MAHS__0E6E26BF");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Kqnamhocs)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KQNAMHOC__MANH__0F624AF8");
            });

            modelBuilder.Entity<Loaikiemtra>(entity =>
            {
                entity.HasKey(e => e.Malkt)
                    .HasName("PK__LOAIKIEM__7A3D008E453BE876");

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
                    .HasName("PK__LOP__7A3DE21193F31556");

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
                    .HasName("PK__LOPHOCTH__353317E44F4599D5");

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
                    .HasConstraintName("FK__LOPHOCTHU__MAGVC__693CA210");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Lophocthuctes)
                    .HasForeignKey(d => d.Malop)
                    .HasConstraintName("FK__LOPHOCTHU__MALOP__6754599E");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Lophocthuctes)
                    .HasForeignKey(d => d.Manh)
                    .HasConstraintName("FK__LOPHOCTHUC__MANH__68487DD7");

                entity.HasMany(d => d.Mahs)
                    .WithMany(p => p.Malhtts)
                    .UsingEntity<Dictionary<string, object>>(
                        "LophocthucteHocsinh",
                        l => l.HasOne<Hocsinh>().WithMany().HasForeignKey("Mahs").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LOPHOCTHUC__MAHS__6E01572D"),
                        r => r.HasOne<Lophocthucte>().WithMany().HasForeignKey("Malhtt").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LOPHOCTHU__MALHT__6D0D32F4"),
                        j =>
                        {
                            j.HasKey("Malhtt", "Mahs").HasName("PK__LOPHOCTH__F330E5E913C4B5F7");

                            j.ToTable("LOPHOCTHUCTE_HOCSINH");

                            j.IndexerProperty<string>("Malhtt").HasMaxLength(10).HasColumnName("MALHTT");

                            j.IndexerProperty<string>("Mahs").HasMaxLength(7).HasColumnName("MAHS");
                        });
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.Mamh)
                    .HasName("PK__MONHOC__603F69EBB68A4476");

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
                    .HasName("PK__NAMHOC__603F510A0FDF71BC");

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
                    .HasName("PK__NHANVIEN__603F5114416544FF");

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
                    .HasConstraintName("FK__NHANVIENP__USERN__571DF1D5");
            });

            modelBuilder.Entity<Phanconggiangday>(entity =>
            {
                entity.HasKey(e => new { e.Manh, e.Malhtt, e.Mamh, e.Magv })
                    .HasName("PK__PHANCONG__520A5CEED46EF9DE");

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
                    .HasConstraintName("FK__PHANCONGGI__MAGV__1BC821DD");

                entity.HasOne(d => d.MalhttNavigation)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => d.Malhtt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGG__MALHT__1AD3FDA4");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => d.Mamh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGGI__MAMH__1CBC4616");

                entity.HasOne(d => d.ManhNavigation)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => d.Manh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGGI__MANH__19DFD96B");

                entity.HasOne(d => d.Ma)
                    .WithMany(p => p.Phanconggiangdays)
                    .HasForeignKey(d => new { d.Magv, d.Mamh })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHANCONGGIANGDAY__1EA48E88");
            });

            modelBuilder.Entity<Phh>(entity =>
            {
                entity.HasKey(e => e.Maphhs)
                    .HasName("PK__PHHS__5401D0A5C29DA9FF");

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
                    .HasConstraintName("FK__PHHS__MAHS__5EBF139D");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__TAIKHOAN__B15BE12FBC0E2EA1");

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
