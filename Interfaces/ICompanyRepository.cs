using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface ICompanyRepository
	{
		Task<ICollection<NhaTuyenDung>> GetAllAsync();
		Task<NhaTuyenDung> GetNhaTuyenDungByName(string name);
		Task<ICollection<TuyenDung>> GetTuyenDungByNhaTuyenDung(int id);
	}
}
