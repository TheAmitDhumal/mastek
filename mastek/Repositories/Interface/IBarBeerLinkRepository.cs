using mastek.Model;

namespace mastek.Repositories.Interface
{
    public interface IBarBeerLinkRepository
    {
        void AddBeerToBar(int barId, int beerId);
        Bar GetBarWithBeers(int barId);
        List<Bar> GetBarsWithBeers();
    }
}
