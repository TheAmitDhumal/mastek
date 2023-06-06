using mastek.Model;
using mastek.Repositories.Interface;
using mastek.Services.Interface;

namespace mastek.Services.Implementation
{
    public class BreweryBeerLinkService : IBreweryBeerLinkService
    {
        private readonly IBreweryBeerLinkRepository _breweryBeerLinkRepository;

        public BreweryBeerLinkService(IBreweryBeerLinkRepository breweryBeerLinkRepository)
        {
            _breweryBeerLinkRepository = breweryBeerLinkRepository;
        }

        public void AddBeerToBrewery(int breweryId, int beerId)
        {
            _breweryBeerLinkRepository.AddBeerToBrewery(breweryId, beerId);
        }

        public Brewery GetBreweryWithBeers(int breweryId)
        {
            return _breweryBeerLinkRepository.GetBreweryWithBeers(breweryId);
        }

        public List<Brewery> GetBreweriesWithBeers()
        {
            return _breweryBeerLinkRepository.GetBreweriesWithBeers();
        }
    }

}
