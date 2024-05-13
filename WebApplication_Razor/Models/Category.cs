using System.ComponentModel.DataAnnotations;

namespace WebApplication_Razor.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(30)]
		[Display(Name = "Category Name", Prompt = "Category Name")]
		public string Name { get; set; }
		[Display(Name = "Display Order", Prompt = "1")]
		[Range(1, 100, ErrorMessage = "The field Display Order must be between 1 - 100.")]
		public int DisplayOrder { get; set; }
	}
}
