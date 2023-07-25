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

        public async Task<ICollection<SanPham>> GetAllAsync()
		{
			return await _context.SanPhams.ToListAsync();
		}

		public async Task<ICollection<SanPham>> GetSanPhamByCuaHangId(int maCuaHang)
		{
			return await _context.SanPhams.Where(s => s.MaCuaHang == maCuaHang).OrderByDescending(s => s.LuotMua).ToListAsync();
		}
	}
}
