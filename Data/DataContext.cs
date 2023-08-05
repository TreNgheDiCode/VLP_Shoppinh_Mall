using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VLPMall.Models;

namespace VLPMall.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DiaChi> DiaChis { get; set; }
        public DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<TuyenDung> TuyenDungs { get; set; }
        public DbSet<NhaTuyenDung> NhaTuyenDungs { get; set; }
        public DbSet<ChiNhanhCuaHang> ChiNhanhCuaHang { get; set; }
        public DbSet<CuaHangSanPham> CuaHangSanPham { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ChiNhanhCuaHang>()
                .HasKey(_as => new { _as.MaChiNhanh, _as.MaCuaHang });

            builder.Entity<ChiNhanhCuaHang>()
                .HasOne(a => a.ChiNhanh)
                .WithMany(_as => _as.ChiNhanhCuaHangs)
                .HasForeignKey(a => a.MaChiNhanh)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ChiNhanhCuaHang>()
                .HasOne(s => s.CuaHang)
                .WithMany(_as => _as.ChiNhanhCuaHangs)
                .HasForeignKey(s => s.MaCuaHang)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CuaHangSanPham>()
                .HasKey(_as => new { _as.MaCuaHang, _as.MaSanPham });

            builder.Entity<CuaHangSanPham>()
                .HasOne(s => s.CuaHang)
                .WithMany(_as => _as.CuaHangSanPhams)
                .HasForeignKey(s => s.MaCuaHang)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CuaHangSanPham>()
                .HasOne(p => p.SanPham)
                .WithMany(_as => _as.CuaHangSanPhams)
                .HasForeignKey(p => p.MaSanPham)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
