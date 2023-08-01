using VLPMall.Models;

namespace VLPMall.Interfaces
{
	public interface IAdminRepository
	{
		Task<ICollection<ChiNhanh>> GetAllUserChiNhanh();
		Task<ICollection<CuaHang>> GetAllUserCuaHang();
		Task<ICollection<TinTuc>> GetAllUserTinTuc();
		Task<ICollection<TuyenDung>> GetAllUserTuyenDung();
		Task<ICollection<NhaTuyenDung>> GetAllUserNhaTuyenDung();
		Task<ICollection<SanPham>> GetAllUserSanPham();
		Task<ICollection<KhuyenMai>> GetAllUserKhuyenMai();
	}
}
