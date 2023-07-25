using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface IUserRepository
	{
		Task<ICollection<User>> GetAllAsync();
	}
}
