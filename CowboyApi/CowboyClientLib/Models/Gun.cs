using CowboyApi.Models.Base;

namespace CowboyApi.Models
{
    public class Gun : BaseModel
    {
        public int MaxBullets { get; set; }
        public string Description { get; set; }
        
    }
}
