using mastek.DBContext;
using mastek.Model;
using mastek.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace mastek.Repositories.Implementation
{
    public class BarRepository : IBarRepository
    {
        private readonly ApplicationDbContext _context;

        public BarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Bar AddBar(Bar bar)
        {
            _context.Bars.Add(bar);
            _context.SaveChanges();
            return bar;
        }

        public Bar UpdateBar(Bar bar)
        {
            _context.Bars.Update(bar);
            _context.SaveChanges();
            return bar;
        }

        public List<Bar> GetBars()
        {
            return _context.Bars.Include(b=>b.Beers).ToList();
        }

        public Bar GetBar(int id)
        {
            return _context.Bars.Include(b=> b.Beers).SingleOrDefault(b=>b.Id==id);
        }
    }

}
