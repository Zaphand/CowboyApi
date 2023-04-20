
using CowboyApi.Context;
using CowboyApi.Controllers;
using CowboyApi.Models;

namespace CowboyApiTest
{
    [TestClass]
    public class TestCowboyController
    {
        private readonly CowContext _context;
        public TestCowboyController() 
        { 
            _context = new CowContext();    
        }

        [TestMethod]
        public async void TestMethod1()
        {   
            

            var controller = new CowboyController(_context);

            await controller.Add(TestCowboy);
        }


        private Cowboy TestCowboy = new()
        {
            BulletsInGun = 6,
            GunId = Guid.Empty,
            HorseId = Guid.Empty,
            Id = Guid.Empty,
            Name = "TestCowboy",
            TotalBullets = 12,
        };
    }
}