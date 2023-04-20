namespace CowboyApi.Models.Base

{
    public class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}
