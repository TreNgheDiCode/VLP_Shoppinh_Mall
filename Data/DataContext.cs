using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VLPMall.Models;

namespace VLPMall.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DiaChi> DiaChi { get; set; }
        public DbSet<ChiNhanh>? ChiNhanh { get; set; }
        public DbSet<CuaHang> CuaHang { get; set; }
        public DbSet<ChiNhanhCuaHang> ChiNhanhCuaHang { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ChiNhanhCuaHang>()
                .HasKey(_as => new { _as.MaChiNhanh, _as.MaCuaHang });

            builder.Entity<ChiNhanhCuaHang>()
                .HasOne(a => a.ChiNhanh)
                .WithMany(_as => _as.ChiNhanhCuaHang)
                .HasForeignKey(a => a.MaChiNhanh)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ChiNhanhCuaHang>()
                .HasOne(s => s.CuaHang)
                .WithMany(_as => _as.ChiNhanhCuaHangs)
                .HasForeignKey(s => s.MaCuaHang)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
