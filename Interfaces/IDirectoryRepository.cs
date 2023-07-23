using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface IDirectoryRepository
    {
        List<ChiNhanh> GetAll();
        Task<IEnumerable<ChiNhanh>> GetAllAsync();
        Task<ChiNhanh> GetByIdAsync(int id);
        Task<ChiNhanh> GetByIdAsyncNoTracking(int id);
        List<CuaHang> GetCuaHangByChiNhanh(int maChiNhanh);
        bool ChiNhanhTonTai(int id);
        bool ChiNhanhTonTai(string name);
        bool Add(ChiNhanh chiNhanh, int maCuaHang);
        bool Update(ChiNhanh chiNhanh);
        bool Delete(ChiNhanh chiNhanh);
        bool Save();
    }
}
