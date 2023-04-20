using CowboyApi.Context;
using CowboyApi.Contracts;
using CowboyApi.Models;
using CowboyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CowboyApi.Controllers
{
    [ApiController]
    public class CowboyController :  BaseController<Cowboy>, ICowboyRepository
    {
        private readonly OpenAIService _openAIService;
        public CowboyController(CowContext cowContext, OpenAIService openAIService) : base(cowContext)
        {
            _openAIService = openAIService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[controller]/Create")]
        public async Task<Cowboy> Create(UserInfo newUser)
        {

            var cowboy = new Cowboy()
            {
                Id = Guid.NewGuid(),
                Name = newUser.Username,
                HitPoints = 10,
            };

            var hasher = new PasswordHasher<Cowboy>();
            var hashedPass = hasher.HashPassword(cowboy, newUser.Password);

            var newPassKey = new PassKey
            {
                Id = Guid.NewGuid(),
                CowboyId = cowboy.Id,
                HashedPassword = hashedPass,
            };

            _context.PassKeys.Add(newPassKey);
            _context.Cowboys.Add(cowboy);
            
            await _context.SaveChangesAsync();
            return cowboy;
        }

        [HttpPatch]
        [Route("[controller]/Shoot")]
        public async Task<IEnumerable<Cowboy>> Shoot(Guid cowboyShootingId, Guid cowboyGettingShotId)
        {
            var rnd = new Random();
            
            var cowBoyShooting = await Single(cowboyShootingId);
            var cowboyGettingShot = await Single(cowboyGettingShotId);


            var cowboyShootingHitting = rnd.Next(0,100);
            var cowboyGettingShotLuck = rnd.Next(0,100);

            if(cowboyShootingHitting > cowboyGettingShotLuck)
            {
                var dmgTaken = rnd.Next(0, 10);
                cowboyGettingShot.HitPoints -= dmgTaken;

            }
            cowBoyShooting.TotalBullets--;
            
           return  await UpdateRange(new List<Cowboy> { cowBoyShooting, cowboyGettingShot});
        }


        [HttpGet]
        [Route("[controller]/GetRandom")]
        public async Task<string> GetRandom(string input)
        {

            var response = await _openAIService.GetRandomData(input);


            return string.Empty;

        }


    }
}
