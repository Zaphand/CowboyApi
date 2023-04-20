using CowboyApi.Models;

namespace CowboyApi.Contracts
{
    public interface IHorseRepository : IBaseController<Horse>
    {
        public Task<Horse> Create(string name, string color);
    }
}
