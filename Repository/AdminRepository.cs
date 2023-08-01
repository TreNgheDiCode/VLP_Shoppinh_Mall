using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
	public class AdminRepository : IAdminRepository
	{
		private readonly DataContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AdminRepository(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

        public async Task<ICollection<ChiNhanh>> GetAllUserChiNhanh()
		{
			var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
			var userChiNhanhs = _context.ChiNhanhs.Where(d => d.User.Id == currentUser.ToString());
			return userChiNhanhs.ToList();
		}

		public async Task<ICollection<CuaHang>> GetAllUserCuaHang()
		{
			var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
			var userCuaHangs = _context.CuaHangs.Where(s => s.User.Id == currentUser.ToString());
			return userCuaHangs.ToList();
		}

		public async Task<ICollection<KhuyenMai>> GetAllUserKhuyenMai()
		{
			var currentUser = _httpContextAccessor.HttpContext?.User;
			var userKhuyenMais = _context.KhuyenMais.Where(s => s.User.Id == currentUser.ToString());
			return userKhuyenMais.ToList();
		}

		public async Task<ICollection<NhaTuyenDung>> GetAllUserNhaTuyenDung()
		{
			var currentUser = _httpContextAccessor.HttpContext?.User;
			var userNhaTuyenDungs = _context.NhaTuyenDungs.Where(s => s.User.Id == currentUser.ToString());
			return userNhaTuyenDungs.ToList();
		}


		public async Task<ICollection<SanPham>> GetAllUserSanPham()
		{
			var currentUser = _httpContextAccessor.HttpContext?.User;
			var userSanPhams = _context.SanPhams.Where(p => p.User.Id == currentUser.ToString());
			return userSanPhams.ToList();
		}

		public async Task<ICollection<TinTuc>> GetAllUserTinTuc()
		{
			var currentUser = _httpContextAccessor.HttpContext?.User;
			var userTinTucs = _context.TinTucs.Where(a => a.User.Id == currentUser.ToString());
			return userTinTucs.ToList();
		}

		public async Task<ICollection<TuyenDung>> GetAllUserTuyenDung()
		{
			var currentUser = _httpContextAccessor.HttpContext?.User;
			var userTuyenDungs = _context.TuyenDungs.Where(c => c.User.Id == currentUser.ToString());
			return userTuyenDungs.ToList();
		}
	}
}
