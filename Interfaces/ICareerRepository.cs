using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface ICareerRepository
    {
        Task<ICollection<TuyenDung>> GetAllAsync();
        Task<TuyenDung> GetTuyenDungByName(string name);
    }
}
