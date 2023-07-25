using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface ISaleRepository
	{
		Task<ICollection<KhuyenMai>> GetAllAsync();
	}
}
