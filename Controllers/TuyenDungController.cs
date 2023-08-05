using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.Models;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class TuyenDungController : Controller
    {
        private readonly ICareerRepository _careerRepository;
		private readonly ICompanyRepository _companyRepository;

		public TuyenDungController(ICareerRepository careerRepository, ICompanyRepository companyRepository)
        {
            _careerRepository = careerRepository;
			_companyRepository = companyRepository;
		}

        public async Task<IActionResult> Index()
        {
            var careers = await _careerRepository.GetAllAsync();

            return View("IndexTuyenDung", careers);
        }

        public async Task<IActionResult> Information(string name)
        {
            var career = await _careerRepository.GetTuyenDungByName(name);

            var careerVM = new InformationTuyenDungViewModel
            {
                Id = career.Id,
                TenTuyenDung = career.TenTuyenDung,
                NoiDung = career.NoiDung,
                YeuCau = career.YeuCau,
                QuyenLoi = career.QuyenLoi,
                SoLuong = career.SoLuong,
                DiaChi = career.DiaChi,
                MucLuong = career.MucLuong,
                NgayDang = career.NgayDang,
                NgayHetHan = career.NgayHetHan,
                NhaTuyenDung = career.NhaTuyenDung,
                LoaiHinhTuyenDung = career.LoaiHinhTuyenDung,
                LoaiKinhNghiem = career.LoaiKinhNghiem,
                LoaiNgheNghiep = career.LoaiNgheNghiep,
                LoaiTrinhDo = career.LoaiTrinhDo
            };

            return View("InformationTuyenDung", careerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminViewModel adminVM)
        {
            if (ModelState.IsValid)
            {
                var nhaTuyenDung = await _companyRepository.GetByUserIdAsync(adminVM.tuyenDungViewModel.UserId);

                var tuyenDung = new TuyenDung()
                {
                    TenTuyenDung = adminVM.tuyenDungViewModel.TenTuyenDung,
                    NoiDung = adminVM.tuyenDungViewModel.NoiDung,
                    YeuCau = adminVM.tuyenDungViewModel.YeuCau,
                    QuyenLoi = adminVM.tuyenDungViewModel.QuyenLoi,
                    SoLuong = adminVM.tuyenDungViewModel.SoLuong,
                    DiaChi = new DiaChi()
                    {
                        Duong = adminVM.tuyenDungViewModel.DiaChi.Duong,
                        Phuong = adminVM.tuyenDungViewModel.DiaChi.Phuong,
                        Quan = adminVM.tuyenDungViewModel.DiaChi.Quan,
                        ThanhPho = adminVM.tuyenDungViewModel.DiaChi.ThanhPho
                    },
                    MucLuong = adminVM.tuyenDungViewModel.MucLuong,
                    NgayDang = adminVM.tuyenDungViewModel.NgayDang,
                    NgayHetHan = adminVM.tuyenDungViewModel.NgayHetHan,
                    UserId = adminVM.tuyenDungViewModel.UserId,
                    LoaiNgheNghiep = adminVM.tuyenDungViewModel.LoaiNgheNghiep,
                    LoaiHinhTuyenDung = adminVM.tuyenDungViewModel.LoaiHinhTuyenDung,
                    LoaiKinhNghiem = adminVM.tuyenDungViewModel.LoaiKinhNghiem,
                    LoaiTrinhDo = adminVM.tuyenDungViewModel.LoaiTrinhDo,
                    MaNhaTuyenDung = nhaTuyenDung.Id
                };

                _careerRepository.Add(tuyenDung);
            }

            ModelState.AddModelError("", "Lỗi xảy ra khi tạo tuyển dụng");

            return BadRequest(ModelState);
        }
    }
}
