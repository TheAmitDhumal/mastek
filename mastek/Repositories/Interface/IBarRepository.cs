using mastek.Model;

namespace mastek.Repositories.Interface
{
    public interface IBarRepository
    {
        Bar AddBar(Bar bar);
        Bar UpdateBar(Bar bar);
        List<Bar> GetBars();
        Bar GetBar(int id);
    }
}
