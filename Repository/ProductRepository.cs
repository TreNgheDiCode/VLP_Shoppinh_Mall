using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly DataContext _context;

		public ProductRepository(DataContext context)
        {
			_context = context;
		}

        public bool Add(CuaHang cuaHang, SanPham sanPham)
        {
            var cuaHangSanPham = new CuaHangSanPham()
            {
                CuaHang = cuaHang,
                SanPham = sanPham
            };

            _context.Add(cuaHangSanPham);

            return Save();
        }

        public bool Delete(SanPham sanPham)
        {
            _context.Remove(sanPham);

            return Save();
        }

        public async Task<ICollection<SanPham>> GetAllAsync()
		{
			return await _context.SanPhams.ToListAsync();
		}

		public async Task<SanPham> GetByIdAsync(int id)
		{
            return await _context.SanPhams.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<ICollection<CuaHang>> GetCuaHangBySanPham(string name)
        {
            return await _context.CuaHangSanPham.Where(p => p.SanPham.TenSanPham == name).Select(p => p.CuaHang).ToListAsync();
        }


        public async Task<SanPham> GetSanPhamByName(string name)
        {
			return await _context.SanPhams.FirstOrDefaultAsync(p => p.TenSanPham == name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool Update(SanPham sanPham)
        {
            _context.Update(sanPham);

            return Save();
        }

        public bool UpdateFavorite()
        {
            throw new NotImplementedException();
        }
    }
}
