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

        public bool Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}

        public async Task<User> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _context.Update(user);

            return Save();
        }
    }
}
