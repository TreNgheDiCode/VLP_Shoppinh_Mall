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
			return await _context.TinTucs.Where(s => s.LoaiTinTuc == loaiTinTuc).ToListAsync();
		}

        public async Task<ICollection<TinTuc>> GetTop10Async()
        {
            return await _context.TinTucs.OrderByDescending(a => a.NgayDang).Take(10).ToListAsync();
        }

        public async Task<ICollection<TinTuc>> GetTop6Async()
        {
            return await _context.TinTucs.OrderByDescending(a => a.NgayDang).Take(6).ToListAsync();
        }
    }
}
