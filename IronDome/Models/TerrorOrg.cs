using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IronDome.Models
{
	public class TerrorOrg
	{
		[Key]
		public int id { get; set; }
		public int distance { get; set; }
		public string name { get; set; }
		public string location { get; set; }

	}
}
