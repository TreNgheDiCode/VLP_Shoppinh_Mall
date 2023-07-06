using Microsoft.EntityFrameworkCore;
using VLPMall.Data;
using VLPMall.Interfaces;
using VLPMall.Models;

namespace VLPMall.Repository
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly DataContext _context;

        public AgencyRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Agency agency)
        {
            _context.Add(agency);

            return Save();
        }

        public bool Delete(Agency agency)
        {
            _context.Remove(agency);
            return Save();
        }

        public async Task<IEnumerable<Agency>> GetAll()
        {
            return await _context.Agencies.ToListAsync();
        }

        public async Task<Agency> GetByIdAsync(int id)
        {
            return await _context.Agencies.Include(a => a.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Agency> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Agencies.Include(a => a.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Agency>> GetAgencyByCity(string city)
        {
            return await _context.Agencies.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Agency agency)
        {
            _context.Update(agency);
            return Save();
        }
    }
}
