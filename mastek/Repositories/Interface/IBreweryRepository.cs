using mastek.Model;

namespace mastek.Repositories.Interface
{
    public interface IBreweryRepository
    {
        Brewery AddBrewery(Brewery brewery);
        Brewery UpdateBrewery(Brewery brewery);
        List<Brewery> GetBreweries();
        Brewery GetBrewery(int id);
    }
}
