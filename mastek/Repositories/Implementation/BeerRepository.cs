using mastek.DBContext;
using mastek.Model;
using mastek.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace mastek.Repositories.Implementation
{
    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationDbContext _context;

        public BeerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Beer AddBeer(Beer beer)
        {
            _context.Beers.Add(beer);
            _context.SaveChanges();
            return beer;
        }

        public Beer UpdateBeer(Beer beer)
        {
            _context.Beers.Update(beer);
            _context.SaveChanges();
            return beer;
        }

        public List<Beer> GetBeers(decimal? gtAlcoholByVolume, decimal? ltAlcoholByVolume)
        {
            var query = _context.Beers.AsQueryable();
            if (gtAlcoholByVolume.HasValue && ltAlcoholByVolume.HasValue)
                query = query.Where(b => b.PercentageAlcoholByVolume > gtAlcoholByVolume.Value && b.PercentageAlcoholByVolume < ltAlcoholByVolume.Value);

           else if (gtAlcoholByVolume.HasValue)
                query = query.Where(b => b.PercentageAlcoholByVolume > gtAlcoholByVolume.Value);

           else if (ltAlcoholByVolume.HasValue)
                query = query.Where(b => b.PercentageAlcoholByVolume < ltAlcoholByVolume.Value);

            return query.ToList();
        }

        public Beer GetBeer(int id)
        {
            return _context.Beers.Find(id);
        }
    }

}
