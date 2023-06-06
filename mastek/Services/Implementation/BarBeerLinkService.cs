using mastek.Model;
using mastek.Repositories.Interface;
using mastek.Services.Interface;

namespace mastek.Services.Implementation
{
    public class BarBeerLinkService : IBarBeerLinkService
    {
        private readonly IBarBeerLinkRepository _barBeerLinkRepository;

        public BarBeerLinkService(IBarBeerLinkRepository barBeerLinkRepository)
        {
            _barBeerLinkRepository = barBeerLinkRepository;
        }

        public void AddBeerToBar(int barId, int beerId)
        {
            _barBeerLinkRepository.AddBeerToBar(barId, beerId);
        }

        public Bar GetBarWithBeers(int barId)
        {
            return _barBeerLinkRepository.GetBarWithBeers(barId);
        }

        public List<Bar> GetBarsWithBeers()
        {
            return _barBeerLinkRepository.GetBarsWithBeers();
        }
    }

}
