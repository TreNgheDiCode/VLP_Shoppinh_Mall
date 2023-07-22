using Microsoft.AspNetCore.Mvc;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;
using VLPMall.Repository;
using VLPMall.Services;
using VLPMall.ViewModels;

namespace VLPMall.Controllers
{
    public class DanhMucCuaHangController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IStoreRepository _storeRepository;

        public DanhMucCuaHangController(IPhotoService photoService, IStoreRepository storeRepository)
        {
            _photoService = photoService;
            _storeRepository = storeRepository;
        }

        [Route("CuaHang/[action]/")]
        public IActionResult Index(string danhmuc)
        {
            return View("IndexDanhMuc", danhmuc);
        }

        [Route("CuaHang/[controller]/[action]")]
        public async Task<IActionResult> DanhSachCuaHang(LoaiCuaHang loaiCuaHang, int loaiDanhMuc)
        {
            var cuaHang = await _storeRepository.GetCuaHangByDanhMuc(loaiCuaHang, loaiDanhMuc);

            List<ListDanhMucViewModel> listDanhMucVM = new List<ListDanhMucViewModel>();

            foreach (var item in cuaHang)
            {
                switch(loaiCuaHang)
                {
                    case LoaiCuaHang.AmThuc:
                        {
                            listDanhMucVM.Add(new ListDanhMucViewModel
                            {
                                Id = item.Id,
                                TenCuaHang = item.TenCuaHang,
                                LinkAnh = item.AnhDaiDien,
                                LoaiAmThuc = item.LoaiAmThuc
                            });

                            break;
                        }
                    case LoaiCuaHang.GiaiTri:
                        {
                            listDanhMucVM.Add(new ListDanhMucViewModel
                            {
                                Id = item.Id,
                                TenCuaHang = item.TenCuaHang,
                                LinkAnh = item.AnhDaiDien,
                                LoaiGiaiTri = item.LoaiGiaiTri
                            });

                            break;
                        }
                    case LoaiCuaHang.TienIch:
                        {
                            listDanhMucVM.Add(new ListDanhMucViewModel
                            {
                                Id = item.Id,
                                TenCuaHang = item.TenCuaHang,
                                LinkAnh = item.AnhDaiDien,
                                LoaiTienIch = item.LoaiTienIch
                            });

                            break;
                        }
                    case LoaiCuaHang.DichVu:
                        {
                            listDanhMucVM.Add(new ListDanhMucViewModel
                            {
                                Id = item.Id,
                                TenCuaHang = item.TenCuaHang,
                                LinkAnh = item.AnhDaiDien,
                                LoaiDichVu = item.LoaiDichVu
                            });

                            break;
                        }
                    case LoaiCuaHang.MuaSam:
                        {
                            listDanhMucVM.Add(new ListDanhMucViewModel
                            {
                                Id = item.Id,
                                TenCuaHang = item.TenCuaHang,
                                LinkAnh = item.AnhDaiDien,
                                LoaiMuaSam = item.LoaiMuaSam
                            });

                            break;
                        }
                }
                
            }


            return View("DanhSachCuaHang", listDanhMucVM);
        }
    }
}
