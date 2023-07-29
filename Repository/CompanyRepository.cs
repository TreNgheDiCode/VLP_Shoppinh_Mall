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

        public async Task<ICollection<NhaTuyenDung>> GetAllAsync()
		{
			return await _context.NhaTuyenDungs.ToListAsync();
		}

        public async Task<NhaTuyenDung> GetNhaTuyenDungByName(string name)
        {
			return await _context.NhaTuyenDungs.Include(c => c.TuyenDungs).Include(c => c.DiaChi).FirstOrDefaultAsync(c => c.TenNhaTuyenDung == name);
        }

        public async Task<ICollection<TuyenDung>> GetTuyenDungByNhaTuyenDung(int id)
        {
            return await _context.TuyenDungs.Where(c => c.MaNhaTuyenDung == id).ToListAsync();
        }
    }
}
