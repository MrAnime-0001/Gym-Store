using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_Store.Pages.Products
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        // Property to hold the Product object for binding
        public Product Product { get; set; }

        // Constructor to inject the ApplicationDbContext
        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET method to retrieve the product by ID for deletion confirmation
        public void OnGet(int id)
        {
            if (id != 0)
            {
                Product = _dbContext.Products.Find(id);
            }
        }

        // POST method to handle product deletion
        public IActionResult OnPost()
        {
            // Find the product in the database by its ID
            var obj = _dbContext.Products.Find(Product.Id);
            if (obj == null)
            {
                // If the product doesn't exist, return NotFound
                return NotFound();
            }

            // Remove the product from the database
            _dbContext.Products.Remove(obj);
            _dbContext.SaveChanges();

            TempData["success"] = "Product deleted successfully";
            // Redirect to the Product index page after deletion
            return RedirectToPage("Index");
        }
    }
}
