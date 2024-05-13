using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Razor.Data;
using WebApplication_Razor.Models;

namespace WebApplication_Razor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;

        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _dbContext.Add(Category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
