using mastek.Model;
using mastek.Repositories.Interface;
using mastek.Services.Interface;

namespace mastek.Services.Implementation
{
    public class BarService : IBarService
    {
        private readonly IBarRepository _barRepository;

        public BarService(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public Bar CreateBar(Bar bar)
        {
            return _barRepository.AddBar(bar);
        }

        public Bar UpdateBar(int id,Bar bar)
        {
            var existingBar = _barRepository.GetBar(id);
            if (existingBar == null)
                throw new Exception("Bar not found");

            existingBar.Name= bar.Name;
            existingBar.Address= bar.Address;

            return _barRepository.UpdateBar(existingBar);
        }

        public List<Bar> GetBars()
        {
            return _barRepository.GetBars();
        }

        public Bar GetBar(int id)
        {
            return _barRepository.GetBar(id);
        }
    }

}
