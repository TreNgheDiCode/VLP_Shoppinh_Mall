using VLPMall.Data.Enum;
using VLPMall.Models;

namespace VLPMall.Interfaces
{
    public interface IStoreRepository
    {
        IEnumerable<CuaHang> GetAll();
        Task<IEnumerable<CuaHang>> GetAllAsync();
        Task<CuaHang> GetByIdAsync(int id);
        Task<CuaHang> GetByIdAsyncNoTracking(int id);
        Task<CuaHang> GetByNameAsync(string name);
        Task<string> GetDiaDiemgById(int maChiNhanh, int maCuaHang);
        Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(int id);
        Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(string name);
        Task<IEnumerable<SanPham>> GetSanPhamByCuaHang(int id);
        Task<IEnumerable<SanPham>> GetSanPhamByCuaHang(string name);
        Task<IEnumerable<CuaHang>> GetCuaHangByTheLoai(LoaiCuaHang loaiCuaHang);
        Task<IEnumerable<CuaHang>> GetCuaHangByDanhMuc(LoaiCuaHang loaiCuaHang, int loaiDanhMuc);
        bool CuaHangTonTai(int id);
        bool CuaHangTonTai(string name);
		bool Add(CuaHang cuaHang, ChiNhanh chiNhanh, string diaDiem);
		bool Add(CuaHang cuaHang, SanPham sanPham);
		bool Update(CuaHang cuaHang);
		bool Delete(CuaHang cuaHang);
		bool Save();
	}
}