using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Areas.Admin.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnPost()
        {
            var product = _db.Products.Find(Product.Id);

            //product.Id = Product.Id;
            product.IsActive = Product.IsActive;
            product.Price = Product.Price;

            _db.SaveChanges();
            return RedirectToPage("/products/index");
        }

        public void OnGet(int id)
        {
            Product = _db.Products.Find(id);
        }
    }
}
