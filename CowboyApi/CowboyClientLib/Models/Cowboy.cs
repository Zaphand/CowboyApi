using CowboyApi.Models.Base;

namespace CowboyApi.Models
{
    public class Cowboy : BaseModel
    {
        public int TotalBullets { get; set; }
        public int BulletsInGun { get;set; }
        public int HitPoints { get; set; } 


        public Guid GunId { get; set; }
        public Gun Gun { get; set; }

        public Guid HorseId { get; set; }
        public Horse Horse { get; set; }

    }
}
