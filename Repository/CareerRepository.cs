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

		public bool Add(TuyenDung tuyenDung)
		{
			_context.Add(tuyenDung);

			return Save();
		}

		public bool Delete(TuyenDung tuyenDung)
		{
			_context.Remove(tuyenDung);

			return Save();
		}

		public async Task<ICollection<TuyenDung>> GetAllAsync()
		{
			return await _context.TuyenDungs.Include(c => c.NhaTuyenDung).ToListAsync();
		}

        public async Task<TuyenDung> GetByIdAsync(int id)
        {
			return await _context.TuyenDungs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<TuyenDung>> GetTop6Async()
        {
            return await _context.TuyenDungs.Include(c => c.NhaTuyenDung).OrderByDescending(c => c.NgayDang).Take(6).ToListAsync();
        }

        public async Task<TuyenDung> GetTuyenDungByName(string name)
        {
            return await _context.TuyenDungs.Include(c => c.DiaChi).Include(c => c.NhaTuyenDung).FirstOrDefaultAsync(c => c.TenTuyenDung == name);
        }

		public bool Save()
		{
			var saved = _context.SaveChanges();

			return saved > 0 ? true : false;
		}

		public bool Update(TuyenDung tuyenDung)
		{
			_context.Update(tuyenDung);

			return Save();
		}
	}
}
