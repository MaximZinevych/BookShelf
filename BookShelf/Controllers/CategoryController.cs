using BookShelf.Data;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace BookShelf.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categoryList = _dbContext.Categories.ToList();

            return View(categoryList);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
		public IActionResult Create(Category category)
		{
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order cannot match Name");
            }

            if(ModelState.IsValid)
            {
				_dbContext.Categories.Add(category);
				_dbContext.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}

            return View();
			
		}

		public IActionResult Edit(int? id)
		{
			if(id == null || id == 0) 
			{ 
				return NotFound();
			}

			Category? category = _dbContext.Categories.Find(id);

            if (category == null)
            {
				return NotFound();
            }

            return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			
			if (ModelState.IsValid)
			{
				_dbContext.Categories.Update(category);
				_dbContext.SaveChanges();
				TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");
			}

			return View();

		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category? category = _dbContext.Categories.Find(id);

			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? category = _dbContext.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}

			_dbContext.Categories.Remove(category);
			_dbContext.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
