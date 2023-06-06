using mastek.Model;

namespace mastek.Services.Interface
{
    public interface IBreweryBeerLinkService
    {
        void AddBeerToBrewery(int breweryId, int beerId);
        Brewery GetBreweryWithBeers(int breweryId);
        List<Brewery> GetBreweriesWithBeers();
    }
}
