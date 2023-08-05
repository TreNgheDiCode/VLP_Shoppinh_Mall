using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface ISaleRepository
	{
		Task<ICollection<KhuyenMai>> GetAllAsync();
		Task<KhuyenMai> GetByIdAsync(int id);

		bool Add(KhuyenMai khuyenMai);
		bool Update(KhuyenMai khuyenMai);
		bool Delete(KhuyenMai khuyenMai);
		bool Save();
	}
}
