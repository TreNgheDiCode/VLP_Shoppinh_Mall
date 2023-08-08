using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly DataContext _context;

		public CompanyRepository(DataContext context)
        {
			_context = context;
		}

		public bool Add(NhaTuyenDung nhaTuyenDung)
		{
			_context.Add(nhaTuyenDung);

			return Save();
		}

		public bool Delete(NhaTuyenDung nhaTuyenDung)
		{
			_context.Remove(nhaTuyenDung);

			return Save();
		}

		public async Task<ICollection<NhaTuyenDung>> GetAllAsync()
		{
			return await _context.NhaTuyenDungs.Include(c => c.DiaChi).ToListAsync();
		}

        public async Task<NhaTuyenDung> GetByIdAsync(int id)
        {
			return await _context.NhaTuyenDungs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<NhaTuyenDung> GetByUserIdAsync(string userId)
		{
			return await _context.NhaTuyenDungs.FirstAsync(c => c.UserId == userId);
		}

		public async Task<NhaTuyenDung> GetNhaTuyenDungByName(string name)
        {
			return await _context.NhaTuyenDungs.Include(c => c.TuyenDungs).Include(c => c.DiaChi).FirstOrDefaultAsync(c => c.TenNhaTuyenDung == name);
        }

        public async Task<ICollection<TuyenDung>> GetTuyenDungByNhaTuyenDung(int id)
        {
            return await _context.TuyenDungs.Where(c => c.MaNhaTuyenDung == id).ToListAsync();
        }

		public bool Save()
		{
			var saved = _context.SaveChanges();

			return saved > 0 ? true : false;
		}

		public bool Update(NhaTuyenDung nhaTuyenDung)
		{
			_context.Update(nhaTuyenDung);

			return Save();
		}
	}
}
