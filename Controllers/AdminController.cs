using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
	public class AdminController : Controller
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IAdminRepository _adminRepository;

		public AdminController(IAdminRepository adminRepository, IHttpContextAccessor httpContextAccessor)
        {
			_adminRepository = adminRepository;
			_httpContextAccessor = httpContextAccessor;
		}

        public async Task<IActionResult> Index()
		{
			var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
			var userChiNhanhs = await _adminRepository.GetAllUserChiNhanh();
			var userCuaHangs = await _adminRepository.GetAllUserCuaHang();
			var userTinTucs = await _adminRepository.GetAllUserTinTuc();
			var userTuyenDungs = await _adminRepository.GetAllUserTuyenDung();
			var userNhaTuyenDungs = await _adminRepository.GetAllUserNhaTuyenDung();
			var userSanPhams = await _adminRepository.GetAllUserSanPham();
			var userKhuyenMais = await _adminRepository.GetAllUserKhuyenMai();
			var userViews = new AdminViewModel()
			{
				ChiNhanhs = userChiNhanhs,
				CuaHangs = userCuaHangs,
				TinTucs = userTinTucs,
				TuyenDungs = userTuyenDungs,
				NhaTuyenDungs = userNhaTuyenDungs,
				SanPhams = userSanPhams,
				KhuyenMais = userKhuyenMais,
				chiNhanhViewModel = new CreateChiNhanhViewModel()
				{
					UserId = curUserId
				},
				cuaHangViewModel = new CreateCuaHangViewModel()
				{
					UserId = curUserId,
				},
				sanPhamViewModel = new CreateSanPhamViewModel()
				{
					UserId = curUserId,
				},
				khuyenMaiViewModel = new CreateKhuyenMaiViewModel()
				{
					UserId = curUserId,
				},
				nhaTuyenDungViewModel = new CreateNhaTuyenDungViewModel()
				{
					UserId = curUserId,
				},
				tuyenDungViewModel = new CreateTuyenDungViewModel()
				{
					UserId = curUserId,
				}
			};
			return View("IndexAdmin", userViews);
		}
	}
}
