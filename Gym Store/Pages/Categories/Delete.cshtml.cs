using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_Store.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        // Property to hold the Category object for binding
        public Category Category { get; set; }

        // Constructor to inject the ApplicationDbContext
        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET method to retrieve the category by ID for deletion confirmation
        public void OnGet(int id)
        {
            if (id != 0)
            {
                Category = _dbContext.Categories.Find(id);
            }
        }

        // POST method to handle category deletion
        public IActionResult OnPost()
        {
            // Find the category in the database by its ID
            var obj = _dbContext.Categories.Find(Category.Id);
            if (obj == null)
            {
                // If the category doesn't exist, return NotFound
                return NotFound();
            }

            // Remove the category from the database
            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            // Redirect to the Category index page after deletion
            return RedirectToPage("Index");
        }
    }
}
