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

		public bool Add(CuaHang cuaHang, int maChiNhanh)
		{
			var chiNhanh = _context.ChiNhanh.Where(a => a.Id == maChiNhanh).FirstOrDefault();

			var chiNhanhCuaHang = new ChiNhanhCuaHang
			{
				ChiNhanh = chiNhanh,
				CuaHang = cuaHang
			};

			_context.Add(chiNhanhCuaHang);

            return Save();
		}

		public bool Delete(CuaHang cuaHang)
		{
			_context.Remove(cuaHang);

            return Save();
		}

		public IEnumerable<CuaHang> GetAll()
		{
			return _context.CuaHang.ToList();
		}

		public async Task<IEnumerable<CuaHang>> GetAllAsync()
        {
            return await _context.CuaHang.ToListAsync();
        }

        public async Task<CuaHang> GetByIdAsync(int id)
        {
            return await _context.CuaHang.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<CuaHang> GetByIdAsyncNoTracking(int id)
        {
            return await _context.CuaHang.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<CuaHang> GetByNameAsync(string name)
        {
            return await _context.CuaHang.FirstOrDefaultAsync(s => s.TenCuaHang == name);
        }

        public async Task<string> GetDiaDiemgById(int maChiNhanh, int maCuaHang)
        {
            return await _context.ChiNhanhCuaHang.Where(a => (a.MaChiNhanh == maChiNhanh) && (a.MaCuaHang == maCuaHang)).Select(a => a.DiaDiem).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(int id)
        {
            return await _context.ChiNhanhCuaHang.Where(s => s.CuaHang.Id == id).Select(s => s.ChiNhanh).ToListAsync();
        }

        public async Task<IEnumerable<ChiNhanh>> GetChiNhanhByCuaHang(string name)
        {
            return await _context.ChiNhanhCuaHang.Where(s => s.CuaHang.TenCuaHang == name).Select(s => s.ChiNhanh).ToListAsync();
        }

        public async Task<IEnumerable<CuaHang>> GetCuaHangByDanhMuc(LoaiCuaHang loaiCuaHang, int loaiDanhMuc)
        {
            switch(loaiCuaHang)
            {
                case LoaiCuaHang.AmThuc:
                    {
                        return await _context.CuaHang.Where(s => (s.LoaiCuaHang == loaiCuaHang) && (s.LoaiAmThuc == (LoaiAmThuc)loaiDanhMuc)).ToListAsync();
                    }
                case LoaiCuaHang.GiaiTri:
                    {
                        return await _context.CuaHang.Where(s => (s.LoaiCuaHang == loaiCuaHang) && (s.LoaiGiaiTri == (LoaiGiaiTri)loaiDanhMuc)).ToListAsync();
                    }
                case LoaiCuaHang.TienIch:
                    {
                        return await _context.CuaHang.Where(s => (s.LoaiCuaHang == loaiCuaHang) && (s.LoaiTienIch == (LoaiTienIch)loaiDanhMuc)).ToListAsync();
                    }
                case LoaiCuaHang.DichVu:
                    {
                        return await _context.CuaHang.Where(s => (s.LoaiCuaHang == loaiCuaHang) && (s.LoaiDichVu == (LoaiDichVu)loaiDanhMuc)).ToListAsync();
                    }
                case LoaiCuaHang.MuaSam:
                    {
                        return await _context.CuaHang.Where(s => (s.LoaiCuaHang == loaiCuaHang) && (s.LoaiMuaSam == (LoaiMuaSam)loaiDanhMuc)).ToListAsync();
                    }
                default: 
                    return null;
            }
        }

        public Task<IEnumerable<CuaHang>> GetCuaHangByTheLoai(LoaiCuaHang loaiCuaHang)
        {
            throw new NotImplementedException();
        }

		public bool Save()
		{
			var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
		}

		public bool Update(CuaHang cuaHang)
		{
			_context.Update(cuaHang);

            return Save();
		}

        public bool CuaHangTonTai(int id)
        {
            return _context.CuaHang.Any(s => s.Id == id);
        }

        public bool CuaHangTonTai(string name)
        {
            return _context.CuaHang.Any(s => s.TenCuaHang == name);
        }
    }
}
