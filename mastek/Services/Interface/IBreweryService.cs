using mastek.Model;

namespace mastek.Services.Interface
{
    public interface IBreweryService
    {
        Brewery CreateBrewery(Brewery brewery);
        Brewery UpdateBrewery(int id, Brewery brewery);
        List<Brewery> GetBreweries();
        Brewery GetBrewery(int id);
    }
}
