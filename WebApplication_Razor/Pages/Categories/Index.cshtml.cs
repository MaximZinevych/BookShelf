using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Razor.Data;
using WebApplication_Razor.Models;

namespace WebApplication_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public List<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext DbContext)
        {
			_dbContext = DbContext;

		}

        public void OnGet()
        {
            Categories = _dbContext.Categories.ToList();
        }
    }
}
