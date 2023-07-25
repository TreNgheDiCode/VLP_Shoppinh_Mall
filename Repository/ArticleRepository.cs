using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using VLPMall.Data;
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
	}
}
