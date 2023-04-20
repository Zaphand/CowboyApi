using CowboyApi.Context;
using CowboyApi.Contracts;
using CowboyApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CowboyApi.Controllers
{
    [ApiController]
    public class HorseController : BaseController<Horse> , IHorseRepository
    {
        public HorseController(CowContext cowContext) : base(cowContext)
        {
        }


        [HttpPost]
        [Route("[controller]/Create")]
        public async Task<Horse> Create(string name, string color)
        {
            var horse = new Horse
            {
                Name = name,
                Color = color,
                HitPoints = 15
            };

            await Add(horse);
            return horse;
        }


    }
}
