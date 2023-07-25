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

        public async Task<ICollection<KhuyenMai>> GetAllAsync()
		{
			return await _context.KhuyenMais.ToListAsync();
		}
	}
}
