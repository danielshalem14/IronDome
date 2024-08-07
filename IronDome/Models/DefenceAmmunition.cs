using System.ComponentModel.DataAnnotations;

namespace IronDome.Models
{
	public class DefenceAmmunition
	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
		public int amount { get; set; }
	}
}
