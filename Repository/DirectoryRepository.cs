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

        public bool Add(ChiNhanh chiNhanh)
        {
            _context.Add(chiNhanh);

            return Save();
        }

        public bool Delete(ChiNhanh chiNhanh)
        {
            _context.Remove(chiNhanh);

            return Save();
        }

        public List<ChiNhanh> GetAll()
        {
            return _context.ChiNhanh.ToList();
        }

        public async Task<IEnumerable<ChiNhanh>> GetAllAsync()
        {
            return await _context.ChiNhanh.Include(a => a.DiaChi).ToListAsync();
        }

        public async Task<ChiNhanh> GetByIdAsync(int id)
        {
            return await _context.ChiNhanh.Include(a => a.DiaChi).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<ChiNhanh> GetByIdAsyncNoTracking(int id)
        {
            return await _context.ChiNhanh.Include(a => a.DiaChi).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public List<CuaHang> GetCuaHangByChiNhanh(int id)
        {
            return _context.ChiNhanhCuaHang.Where(a => a.ChiNhanh.Id == id).Select(s => s.CuaHang).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool Update(ChiNhanh chiNhanh)
        {
            _context.Update(chiNhanh);

            return Save();
        }
    }
}
