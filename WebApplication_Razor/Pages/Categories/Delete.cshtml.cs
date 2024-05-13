using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Razor.Data;
using WebApplication_Razor.Models;

namespace WebApplication_Razor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _dbContext;
		[BindProperty]
		public Category? Category { get; set; }

		public DeleteModel(ApplicationDbContext DbContext)
		{
			_dbContext = DbContext;

		}
		public void OnGet(int? id)
        {
			if (id != null && id != 0)
			{
				Category = _dbContext.Categories.Find(id);
			}
		}

		public IActionResult OnPost()
		{
			Category? category = _dbContext.Categories.Find(Category.Id);
			if (category == null)
			{
				return NotFound();
			}

			_dbContext.Categories.Remove(category);
			_dbContext.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToPage("Index");

		}
    }
}
