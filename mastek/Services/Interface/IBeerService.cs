using mastek.Model;

namespace mastek.Services.Interface
{
    public interface IBeerService
    {
        Beer CreateBeer(Beer beer);
        Beer UpdateBeer(Beer beer);
        List<Beer> GetBeers(decimal? gtAlcoholByVolume, decimal? ltAlcoholByVolume);
        Beer GetBeer(int id);
    }
}
