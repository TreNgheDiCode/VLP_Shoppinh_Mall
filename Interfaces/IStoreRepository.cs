using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<CuaHang>> GetAll();
        Task<CuaHang> GetByIdAsync();
        Task<IEnumerable<CuaHang>> GetCuaHangByChiNhanh(int maChiNhanh);
    }
}