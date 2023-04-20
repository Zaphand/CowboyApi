using CowboyApi.Context;
using CowboyApi.Contracts;
using CowboyApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CowboyApi.Controllers
{
    [ApiController]
    public class GunController : BaseController<Gun> , IGunRepository
    {
        public GunController(CowContext cowContext) : base(cowContext)
        {
            
        }


        [HttpPost]
        [Route("[controller]/Create")]
        public async Task<Gun> Create(string name, int maxBullets,string description)
        {
            var gun = new Gun()
            {
                Name = name,
                Description = description,
                MaxBullets = maxBullets
            };

            await Add(gun);
            return gun;

        }
    }
}
