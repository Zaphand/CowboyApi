using CowboyApi.Models;

namespace CowboyApi.Contracts
{
    public interface IGunRepository : IBaseController<Gun>
    {
        public Task<Gun> Create(string name, int maxBullets, string description);
    }
}
