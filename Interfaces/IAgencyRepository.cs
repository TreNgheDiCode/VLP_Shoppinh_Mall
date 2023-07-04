using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface IAgencyRepository
    {
        Task<IEnumerable<Agency>> GetAll();
        Task<Agency> GetByIdAsync(int id);
        Task<Agency> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Agency>> GetAgencyByCity (string city);
        bool Add(Agency agency);
        bool Update(Agency agency);
        bool Delete(Agency agency);
        bool Save();
    }
}
