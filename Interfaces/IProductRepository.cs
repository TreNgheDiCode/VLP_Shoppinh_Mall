using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface IProductRepository
	{
		Task<ICollection<SanPham>> GetAllAsync();
		Task<ICollection<SanPham>> GetSanPhamByCuaHangId(int maCuaHang);
	}
}
