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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Product Product { get; set; }

        public CreateModel(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            Product = new Product();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Gym_Store", "Images");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                Product.ImageUrl = $"/Gym_Store/Images/{fileName}";
            }

            _db.Products.Add(Product);
            await _db.SaveChangesAsync();

            TempData["success"] = "Product created successfully!";
            return RedirectToPage("Index");
        }
    }
}
