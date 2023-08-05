using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
	public class SaleRepository : ISaleRepository
	{
		private readonly DataContext _context;

		public SaleRepository(DataContext context)
        {
			_context = context;
		}

		public bool Add(KhuyenMai khuyenMai)
		{
			_context.Add(khuyenMai);

			return Save();
		}

		public bool Delete(KhuyenMai khuyenMai)
		{
			_context.Remove(khuyenMai);

			return Save();
		}

		public async Task<ICollection<KhuyenMai>> GetAllAsync()
		{
			return await _context.KhuyenMais.ToListAsync();
		}

		public async Task<KhuyenMai> GetByIdAsync(int id)
		{
			return await _context.KhuyenMais.Include(s => s.CuaHang).FirstOrDefaultAsync(s => s.Id == id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();

			return saved > 0 ? true : false;
		}

		public bool Update(KhuyenMai khuyenMai)
		{
			_context.Update(khuyenMai);

			return Save();
		}
	}
}
