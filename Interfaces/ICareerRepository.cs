using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface ICareerRepository
    {
        Task<ICollection<TuyenDung>> GetAllAsync();
        Task<ICollection<TuyenDung>> GetTop6Async();
        Task<TuyenDung> GetTuyenDungByName(string name);
    }
}
