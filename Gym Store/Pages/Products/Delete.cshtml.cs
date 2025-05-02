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

        public Product Product { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Load the product to confirm deletion
        public IActionResult OnGet(int id)
        {
            Product = _dbContext.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        // POST: Delete the product
        public IActionResult OnPost()
        {
            var productInDb = _dbContext.Products.Find(Product.Id);
            if (productInDb == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(productInDb);
            _dbContext.SaveChanges();

            TempData["success"] = "Product deleted successfully!";
            return RedirectToPage("Index");
        }
    }
}
