using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly DataContext _context;

        public DirectoryRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ChiNhanh> GetAll()
        {
            return _context.ChiNhanh.ToList();
        }

        public async Task<IEnumerable<ChiNhanh>> GetAllAsync()
        {
            return await _context.ChiNhanh.ToListAsync();
        }

        public async Task<ChiNhanh> GetByIdAsync(int id)
        {
            return await _context.ChiNhanh.Include(a => a.DiaChi).FirstOrDefaultAsync(i => i.Id == id);
        }

        public List<CuaHang> GetCuaHangByChiNhanh(int id)
        {
            return _context.ChiNhanhCuaHang.Where(a => a.ChiNhanh.Id == id).Select(s => s.CuaHang).ToList();
        }
    }
}
