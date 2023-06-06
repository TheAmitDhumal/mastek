using mastek.Model;
using mastek.Repositories.Interface;
using mastek.Services.Interface;

namespace mastek.Services.Implementation
{
    public class BreweryService : IBreweryService
    {
        private readonly IBreweryRepository _breweryRepository;

        public BreweryService(IBreweryRepository breweryRepository)
        {
            _breweryRepository = breweryRepository;
        }

        public Brewery CreateBrewery(Brewery brewery)
        {
            return _breweryRepository.AddBrewery(brewery);
        }

        public Brewery UpdateBrewery(int id, Brewery brewery)
        {
            var existingBrewery = _breweryRepository.GetBrewery(id);
            if (existingBrewery == null)
                throw new Exception("Brewery not found");

            existingBrewery.Name = brewery.Name;

            return _breweryRepository.UpdateBrewery(existingBrewery);
        }

        public List<Brewery> GetBreweries()
        {
            return _breweryRepository.GetBreweries();
        }

        public Brewery GetBrewery(int id)
        {
            return _breweryRepository.GetBrewery(id);
        }
    }

}
