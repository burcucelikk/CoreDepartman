using System.ComponentModel.DataAnnotations;

namespace CoreDepartman.Models
{
	public class Departman
	{
		[Key]
		public int Id { get; set; }
		public string Ad { get; set; }
		public List<Personel> Personels { get; set; }
	}
}
