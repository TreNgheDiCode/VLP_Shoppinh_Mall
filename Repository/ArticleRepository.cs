using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using VLPMall.Data;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
	public class ArticleRepository : IArticleRepository
	{
		private readonly DataContext _context;
		private readonly IPhotoService _photoService;

		public ArticleRepository(DataContext context, IPhotoService photoService)
        {
			_context = context;
			_photoService = photoService;
		}

		public bool Add(TinTuc tinTuc)
		{
			_context.Add(tinTuc);

			return Save();
		}

		public bool Delete(TinTuc tinTuc)
		{
			_context.Remove(tinTuc);

			return Save();
		}

		public async Task<ICollection<TinTuc>> GetAllAsync()
		{
			return await _context.TinTucs.ToListAsync();
		}

        public async Task<TinTuc> GetTinTucById(int id)
		{
			return await _context.TinTucs.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task<ICollection<TinTuc>> GetTinTucByLoaiTinTUc(LoaiTinTuc loaiTinTuc)
		{
			return await _context.TinTucs.Where(s => (s.LoaiTinTuc == loaiTinTuc && s.TrangThai == true)).ToListAsync();
		}

        public async Task<TinTuc> GetTinTucByName(string name)
        {
			return await _context.TinTucs.Include(a => a.User).FirstOrDefaultAsync(a => a.TieuDe == name);
        }

        public async Task<ICollection<TinTuc>> GetTop10Async()
        {
            return await _context.TinTucs.Where(s => s.TrangThai == true).OrderByDescending(a => a.NgayDang).Take(10).ToListAsync();
        }

        public async Task<ICollection<TinTuc>> GetTop6Async()
        {
            return await _context.TinTucs.OrderByDescending(a => a.NgayDang).Take(6).ToListAsync();
        }

		public bool Save()
		{
			var saved = _context.SaveChanges();

			return saved > 0 ? true : false;
		}

		public bool Update(TinTuc tinTuc)
		{
			_context.Update(tinTuc);

			return Save();
		}
	}
}
