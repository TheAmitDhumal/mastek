using mastek.Model;

namespace mastek.Repositories.Interface
{
    public interface IBreweryBeerLinkRepository
    {
        void AddBeerToBrewery(int breweryId, int beerId);
        Brewery GetBreweryWithBeers(int breweryId);
        List<Brewery> GetBreweriesWithBeers();
    }
}
