using mastek.Model;

namespace mastek.Repositories.Interface
{
    public interface IBeerRepository
    {
        Beer AddBeer(Beer beer);
        Beer UpdateBeer(Beer beer);
        List<Beer> GetBeers(decimal? gtAlcoholByVolume, decimal? ltAlcoholByVolume);
        Beer GetBeer(int id);
    }
}
