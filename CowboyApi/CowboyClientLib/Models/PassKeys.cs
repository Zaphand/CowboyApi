namespace CowboyApi.Models
{
	public class PassKey
	{
		public Guid Id { get; set; }
		public Guid CowboyId { get; set; }
		public string HashedPassword { get; set; }
	}
}
