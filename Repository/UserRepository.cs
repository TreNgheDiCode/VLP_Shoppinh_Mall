using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;

		public UserRepository(DataContext context)
        {
			_context = context;
		}

        public async Task<ICollection<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}
	}
}
