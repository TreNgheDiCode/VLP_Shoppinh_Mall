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
	}
}
