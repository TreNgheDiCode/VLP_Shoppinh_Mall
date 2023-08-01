using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface IUserRepository
	{
		Task<ICollection<User>> GetAllAsync();
		Task<User> GetUserById(string id);
		bool Add(User user);
		bool Update(User user);
		bool Delete(User user);
		bool Save();
	}
}
