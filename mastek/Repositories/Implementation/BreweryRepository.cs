using mastek.DBContext;
using mastek.Model;
using mastek.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace mastek.Repositories.Implementation
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly ApplicationDbContext _context;

        public BreweryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Brewery AddBrewery(Brewery brewery)
        {
            _context.Breweries.Add(brewery);
            _context.SaveChanges();
            return brewery;
        }

        public Brewery UpdateBrewery(Brewery brewery)
        {
            _context.Breweries.Update(brewery);
            _context.SaveChanges();
            return brewery;
        }

        public List<Brewery> GetBreweries()
        {
            return _context.Breweries.Include(b => b.Beers).ToList();
        }

        public Brewery GetBrewery(int id)
        {
            return _context.Breweries.Include(b=>b.Beers).SingleOrDefault(b => b.Id == id);
        }
    }

}
