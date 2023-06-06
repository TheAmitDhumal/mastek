using mastek.DBContext;
using mastek.Model;
using mastek.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace mastek.Repositories.Implementation
{
    public class BreweryBeerLinkRepository : IBreweryBeerLinkRepository
    {
        private readonly ApplicationDbContext _context;

        public BreweryBeerLinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBeerToBrewery(int breweryId, int beerId)
        {
            var brewery = _context.Breweries.Include(b => b.Beers).SingleOrDefault(b => b.Id == breweryId);
            var beer = _context.Beers.Find(beerId);

            if (brewery == null || beer == null)
                throw new Exception("Brewery or beer not found");

            brewery.Beers.Add(beer);
            _context.SaveChanges();
        }

        public Brewery GetBreweryWithBeers(int breweryId)
        {
            return _context.Breweries.Include(b => b.Beers).SingleOrDefault(b => b.Id == breweryId);
        }

        public List<Brewery> GetBreweriesWithBeers()
        {
            return _context.Breweries.Include(b => b.Beers).ToList();
        }
    }

}
