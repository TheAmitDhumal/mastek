using mastek.Model;

namespace mastek.Services.Interface
{
    public interface IBarBeerLinkService
    {
        void AddBeerToBar(int barId, int beerId);
        Bar GetBarWithBeers(int barId);
        List<Bar> GetBarsWithBeers();
    }
}
