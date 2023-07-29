using Microsoft.AspNetCore.Mvc;
using VLPMall.Interfaces;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class NhaTuyenDungController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public NhaTuyenDungController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
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
    }
}
