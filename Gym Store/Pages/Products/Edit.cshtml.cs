using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_Store.Pages.Products
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        // Property to hold the Product object for binding
        public Product Product { get; set; }

        // Constructor to inject the ApplicationDbContext
        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET method to retrieve the product by ID
        public void OnGet(int id)
        {
            if (id != 0)
            {
                Product = _dbContext.Products.Find(id);
            }
        }

        // POST method to handle product updates
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(Product);
                _dbContext.SaveChanges();
                TempData["success"] = "Product updated successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
