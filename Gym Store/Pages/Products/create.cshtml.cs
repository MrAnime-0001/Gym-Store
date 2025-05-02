using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_Store.Pages.Products
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Product Product { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET method to render the create page
        public void OnGet()
        {
            Product = new Product();
        }

        // POST method to create a new product
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Products.Add(Product);
            _db.SaveChanges();

            TempData["success"] = "Product created successfully!";
            return RedirectToPage("Index");
        }
    }
}
