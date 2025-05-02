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

        public Product Product { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Load the product for editing
        public IActionResult OnGet(int id)
        {
            Product = _dbContext.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        // POST: Update the product in the database
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(Product);
                _dbContext.SaveChanges();
                TempData["success"] = "Product updated successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
