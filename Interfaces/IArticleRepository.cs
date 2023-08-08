using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface IArticleRepository
	{
		Task<ICollection<TinTuc>> GetAllAsync();
		Task<ICollection<TinTuc>> GetTop6Async();
		Task<ICollection<TinTuc>> GetTop10Async();
		Task<ICollection<TinTuc>> GetTinTucByLoaiTinTUc(LoaiTinTuc loaiTinTuc);
		Task<TinTuc> GetTinTucById(int id);
		Task<TinTuc> GetTinTucByName(string name);

		bool Add(TinTuc tinTuc);
		bool Delete(TinTuc tinTuc);
		bool Update(TinTuc tinTuc);
		bool Save();
    }
}
