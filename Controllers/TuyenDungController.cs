using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class TuyenDungController : Controller
    {
        private readonly ICareerRepository _careerRepository;

        public TuyenDungController(ICareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
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
    }
}
