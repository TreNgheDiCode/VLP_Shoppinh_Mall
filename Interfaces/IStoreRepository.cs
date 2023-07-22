using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface IStoreRepository
    {
        IEnumerable<CuaHang> GetAll();
        Task<IEnumerable<CuaHang>> GetAllAsync();
        Task<CuaHang> GetCuaHang(int id);
        Task<CuaHang> GetCuaHang(string name);
        Task<CuaHang> GetByIdAsync(int id);
        Task<CuaHang> GetByIdAsyncNoTracking(int id);
        Task<CuaHang> GetByNameAsync(string name);
        Task<string> GetDiaDiemgById(int maChiNhanh, int maCuaHang);
        Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(int id);
        Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(string name);
        Task<IEnumerable<CuaHang>> GetCuaHangByTheLoai(LoaiCuaHang loaiCuaHang);
        Task<IEnumerable<CuaHang>> GetCuaHangByDanhMuc(LoaiCuaHang loaiCuaHang, int loaiDanhMuc);

		bool Add(CuaHang cuaHang, int maChiNhanh);
		bool Update(CuaHang cuaHang);
		bool Delete(CuaHang cuaHang);
		bool Save();
	}
}