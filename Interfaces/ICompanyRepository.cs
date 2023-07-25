using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface ICompanyRepository
	{
		Task<ICollection<NhaTuyenDung>> GetAllAsync();
	}
}
