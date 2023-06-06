using mastek.Model;

namespace mastek.Services.Interface
{
    public interface IBarService
    {
        Bar CreateBar(Bar bar);
        Bar UpdateBar(int id,Bar bar);
        List<Bar> GetBars();
        Bar GetBar(int id);
    }
}
