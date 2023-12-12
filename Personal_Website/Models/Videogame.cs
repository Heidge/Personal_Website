using System.ComponentModel.DataAnnotations;

namespace Personal_Website.Models
{
	public class Videogame
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }
		public string? Genre { get; set; }
		public bool Done { get; set; }
	}
}
