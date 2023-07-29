using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
    public class CareerRepository : ICareerRepository
	{
		private readonly DataContext _context;

		public CareerRepository(DataContext context)
        {
			_context = context;
		}

        public async Task<ICollection<TuyenDung>> GetAllAsync()
		{
			return await _context.TuyenDungs.Include(c => c.NhaTuyenDung).ToListAsync();
		}

        public async Task<ICollection<TuyenDung>> GetTop6Async()
        {
            return await _context.TuyenDungs.Include(c => c.NhaTuyenDung).OrderByDescending(c => c.NgayDang).Take(6).ToListAsync();
        }

        public async Task<TuyenDung> GetTuyenDungByName(string name)
        {
            return await _context.TuyenDungs.Include(c => c.DiaChi).Include(c => c.NhaTuyenDung).FirstOrDefaultAsync(c => c.TenTuyenDung == name);
        }
    }
}
