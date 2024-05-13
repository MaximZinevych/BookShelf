using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Razor.Data;
using WebApplication_Razor.Models;

namespace WebApplication_Razor.Pages.Categories
{
	[BindProperties]
	public class EditModel : PageModel
    {
		private readonly ApplicationDbContext _dbContext;
		
		public Category Category { get; set; }

		public EditModel(ApplicationDbContext DbContext)
		{
			_dbContext = DbContext;

		}
		
		public void OnGet(int? id)
        {
			if(id != null && id != 0)
			{
				Category = _dbContext.Categories.Find(id);
			}
		}

		public IActionResult OnPost() {

			if (ModelState.IsValid)
			{
				_dbContext.Categories.Update(Category);
				_dbContext.SaveChanges();
				TempData["success"] = "Category updated successfully";
				return RedirectToPage("Index");
			}

			return Page();
		}
    }
}
