using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_Store.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        // Property to hold the Category object for binding
        public Category Category { get; set; }

        // Constructor to inject the ApplicationDbContext
        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET method to retrieve the category by ID
        public void OnGet(int id)
        {
            if (id != 0)
            {
                Category = _dbContext.Categories.Find(id);
            }
        }

        // POST method to handle category updates
        public IActionResult OnPost()
        {
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
