using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym_Store.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public List<Product> ProductList { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            ProductList = _db.Products.ToList();
        }
    }
}
