using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.Repository;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class NhaTuyenDungController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
		private readonly IPhotoService _photoService;

		public NhaTuyenDungController(ICompanyRepository companyRepository, IPhotoService photoService)
        {
            _companyRepository = companyRepository;
			_photoService = photoService;
		}

        public async Task<IActionResult> Information(string name)
        {
            var company = await _companyRepository.GetNhaTuyenDungByName(name);

            var companyVM = new InformationNhaTuyenDungViewModel
            {
                Id = company.Id,
                TenNhaTuyenDung = company.TenNhaTuyenDung,
                GioiThieu = company.GioiThieu,
                AnhDaiDien = company.AnhDaiDien,
                NganhNghe = company.NganhNghe,
                SoDienThoai = company.SoDienThoai,
                Email = company.Email,
                MangXaHoi = company.MangXaHoi,
                TrangChu = company.TrangChu,
                DiaChi = company.DiaChi,
                TuyenDungs = company.TuyenDungs
            };

            return View("InformationNhaTuyenDung", companyVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminViewModel adminVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(adminVM.nhaTuyenDungViewModel.AnhDaiDien);

                var nhaTuyenDung = new NhaTuyenDung()
                {
                    TenNhaTuyenDung = adminVM.nhaTuyenDungViewModel.TenNhaTuyenDung,
                    AnhDaiDien = result.Url.ToString(),
                    GioiThieu = adminVM.nhaTuyenDungViewModel.GioiThieu,
                    NganhNghe = adminVM.nhaTuyenDungViewModel.NganhNghe,
                    SoDienThoai = adminVM.nhaTuyenDungViewModel.SoDienThoai,
                    Email = adminVM.nhaTuyenDungViewModel.Email,
                    MangXaHoi = adminVM.nhaTuyenDungViewModel.MangXaHoi,
                    TrangChu = adminVM.nhaTuyenDungViewModel.TrangChu,
                    DiaChi = new DiaChi()
                    {
                        Duong = adminVM.nhaTuyenDungViewModel.DiaChi.Duong,
                        Phuong = adminVM.nhaTuyenDungViewModel.DiaChi.Phuong,
                        Quan = adminVM.nhaTuyenDungViewModel.DiaChi.Quan,
                        ThanhPho = adminVM.nhaTuyenDungViewModel.DiaChi.ThanhPho
                    },
                    UserId = adminVM.nhaTuyenDungViewModel.UserId
                };

                _companyRepository.Add(nhaTuyenDung);

				return RedirectToAction("Index", "Home");
			}


            ModelState.AddModelError("", "Lỗi xảy ra khi thêm nhà tuyển dụng");

            return BadRequest(ModelState);
		}

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteNhaTuyenDung(int id)
        {
            var nhaTuyenDung = await _companyRepository.GetByIdAsync(id);
            if (nhaTuyenDung == null) { return View("Error"); }

            _companyRepository.Delete(nhaTuyenDung);

            return RedirectToAction("Index", "Admin");
        }
    }
}
