using CowboyApi.Models.Base;

namespace CowboyApi.Models
{
    public class Horse : BaseModel
    {
        public string Color { get; set; }
        public int HitPoints { get; set; } 

    }
}
