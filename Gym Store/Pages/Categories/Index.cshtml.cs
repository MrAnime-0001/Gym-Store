using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Gym_Store.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public List<Product> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
