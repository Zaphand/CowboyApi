using CowboyApi.Models;

namespace CowboyApi.Contracts
{
    public interface ICowboyRepository : IBaseController<Cowboy>
    {
        public Task<Cowboy> Create(UserInfo userInfo);

        public Task<IEnumerable<Cowboy>> Shoot(Guid cowboyShootingId, Guid cowboyGettingShotId);

    }
}
