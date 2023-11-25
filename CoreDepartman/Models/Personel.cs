using System.ComponentModel.DataAnnotations;

namespace CoreDepartman.Models
{
	public class Personel
	{
		[Key]
		public int Id { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
        public string Sehir { get; set; }
		public Departman Departman { get; set; }
		public int DepartmanId { get; set; }
    }
}
