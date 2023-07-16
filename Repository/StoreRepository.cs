using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Data.Enum;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext _context;

        public StoreRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<CuaHang>> GetAllAsync()
        {
            return await _context.CuaHang.ToListAsync();
        }

        public async Task<CuaHang> GetByIdAsync(int id)
        {
            return await _context.CuaHang.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<CuaHang> GetByNameAsync(string name)
        {
            return await _context.CuaHang.FirstOrDefaultAsync(s => s.TenCuaHang == name);
        }

        public async Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(int id)
        {
            return await _context.ChiNhanhCuaHang.Where(s => s.CuaHang.Id == id).Select(s => s.ChiNhanh).ToListAsync();
        }

        public async Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(string name)
        {
            return await _context.ChiNhanhCuaHang.Where(s => s.CuaHang.TenCuaHang == name).Select(s => s.ChiNhanh).ToListAsync();
        }

        public async Task<IEnumerable<CuaHang>> GetCuaHangByDanhMuc(LoaiCuaHang loaiCuaHang, LoaiAmThuc loaiAmThuc)
        {
            return await _context.CuaHang.Where(s => (s.LoaiCuaHang == loaiCuaHang) && (s.LoaiAmThuc == loaiAmThuc)).ToListAsync();
        }

        public Task<IEnumerable<CuaHang>> GetCuaHangByTheLoai(LoaiCuaHang loaiCuaHang)
        {
            throw new NotImplementedException();
        }
    }
}
