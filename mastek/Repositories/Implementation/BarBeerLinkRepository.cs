using mastek.DBContext;
using mastek.Model;
using mastek.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace mastek.Repositories.Implementation
{
    public class BarBeerLinkRepository : IBarBeerLinkRepository
    {
        private readonly ApplicationDbContext _context;

        public BarBeerLinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBeerToBar(int barId, int beerId)
        {
            var bar = _context.Bars.Include(b => b.Beers).SingleOrDefault(b => b.Id == barId);
            var beer = _context.Beers.Find(beerId);

            if (bar == null || beer == null)
                throw new Exception("Bar or beer not found");

            bar.Beers.Add(beer);
            _context.SaveChanges();
        }

        public Bar GetBarWithBeers(int barId)
        {
            return _context.Bars.Include(b => b.Beers).SingleOrDefault(b => b.Id == barId);
        }

        public List<Bar> GetBarsWithBeers()
        {
            return _context.Bars.Include(b => b.Beers).ToList();
        }
    }

}
