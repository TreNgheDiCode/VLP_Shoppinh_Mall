using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface IDirectoryRepository
    {
        IEnumerable<ChiNhanh> GetAll();
        Task<IEnumerable<ChiNhanh>> GetAllAsync();
        Task<ChiNhanh> GetByIdAsync(int id);
        List<CuaHang> GetCuaHangByChiNhanh(int maChiNhanh);
    }
}
