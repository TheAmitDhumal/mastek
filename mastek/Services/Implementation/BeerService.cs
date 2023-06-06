using mastek.Model;
using mastek.Repositories.Interface;
using mastek.Services.Interface;

namespace mastek.Services.Implementation
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public Beer CreateBeer(Beer beer)
        {
            return _beerRepository.AddBeer(beer);
        }

        public Beer UpdateBeer(Beer beer)
        {
            var existingBeer = _beerRepository.GetBeer(beer.Id);
            if (existingBeer == null)
                throw new Exception("Beer not found");

            existingBeer.Name = beer.Name;
            existingBeer.PercentageAlcoholByVolume = beer.PercentageAlcoholByVolume;

            return _beerRepository.UpdateBeer(existingBeer);
        }

        public List<Beer> GetBeers(decimal? gtAlcoholByVolume, decimal? ltAlcoholByVolume)
        {
            return _beerRepository.GetBeers(gtAlcoholByVolume, ltAlcoholByVolume);
        }

        public Beer GetBeer(int id)
        {
            return _beerRepository.GetBeer(id);
        }
    }
}
