using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface IDirectoryRepository
    {
        List<ChiNhanh> GetAll();
        Task<IEnumerable<ChiNhanh>> GetAllAsync();
        Task<ChiNhanh> GetByIdAsync(int id);
        List<CuaHang> GetCuaHangByChiNhanh(int maChiNhanh);
        bool Add(ChiNhanh chiNhanh);
        bool Update(ChiNhanh chiNhanh);
        bool Delete(ChiNhanh chiNhanh);
        bool Save();
    }
}
