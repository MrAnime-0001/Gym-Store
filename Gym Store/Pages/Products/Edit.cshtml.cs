using Gym_Store.Data;
using Gym_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Gym_Store.Pages.Products
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Product Product { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public EditModel(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int id)
        {
            Product = _dbContext.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productFromDb = _dbContext.Products.Find(Product.Id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            // Upload new image if provided
            if (ImageFile != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Gym_Store", "Images");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(fileStream);
                }

                productFromDb.ImageUrl = $"/Gym_Store/Images/{fileName}";
            }

            // Update other fields
            productFromDb.Name = Product.Name;
            productFromDb.Type = Product.Type;
            productFromDb.Price = Product.Price;
            productFromDb.Quantity = Product.Quantity;

            _dbContext.SaveChanges();
            TempData["success"] = "Product updated successfully!";
            return RedirectToPage("Index");
        }
    }
}
