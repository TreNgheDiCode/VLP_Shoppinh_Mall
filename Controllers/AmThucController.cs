using Microsoft.AspNetCore.Mvc;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;
using VLPMall.Repository;
using VLPMall.Services;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class AmThucController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IStoreRepository _storeRepository;

        public AmThucController(IPhotoService photoService, IStoreRepository storeRepository)
        {
            _photoService = photoService;
            _storeRepository = storeRepository;
        }

        [Route("CuaHang/[action]/")]
        public IActionResult AmThuc()
        {
            return View("IndexAmThuc");
        }

        [Route("CuaHang/[controller]/[action]")]
        public async Task<IActionResult> DanhSachCuaHang(LoaiAmThuc name)
        {
            var cuaHang = await _storeRepository.GetCuaHangByDanhMuc(LoaiCuaHang.AmThuc, name);

            List<ListAmThucViewModel> listAmThucVM = new List<ListAmThucViewModel>();

            foreach (var item in cuaHang)
            {
                listAmThucVM.Add(new ListAmThucViewModel
                {
                    Id = item.Id,
                    TenCuaHang = item.TenCuaHang,
                    LinkAnh = item.AnhDaiDien,
                    LoaiAmThuc = item.LoaiAmThuc
                });
            }


            return View("DanhSachAmThuc", listAmThucVM);
        }
    }
}
