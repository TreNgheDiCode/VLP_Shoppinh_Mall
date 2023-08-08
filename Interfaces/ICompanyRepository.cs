using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface ICompanyRepository
	{
		Task<ICollection<NhaTuyenDung>> GetAllAsync();
		Task<NhaTuyenDung> GetByIdAsync(int id);
		Task<NhaTuyenDung> GetNhaTuyenDungByName(string name);
		Task<NhaTuyenDung> GetByUserIdAsync(string userId);
		Task<ICollection<TuyenDung>> GetTuyenDungByNhaTuyenDung(int id);

		bool Add(NhaTuyenDung nhaTuyenDung);
		bool Delete(NhaTuyenDung nhaTuyenDung);
		bool Update(NhaTuyenDung nhaTuyenDung);
		bool Save();
	}
}
