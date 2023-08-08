using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface IProductRepository
	{
		Task<ICollection<SanPham>> GetAllAsync();
		Task<SanPham> GetByIdAsync(int id);
		Task<ICollection<CuaHang>> GetCuaHangBySanPham(string name);
		Task<SanPham> GetSanPhamByName(string name);
		bool UpdateFavorite();
        bool Add(CuaHang cuaHang, SanPham sanPham);
        bool Add(SanPham sanPham);
        bool Update(SanPham sanPham);
        bool Delete(SanPham sanPham);
        bool Save();
    }
}
