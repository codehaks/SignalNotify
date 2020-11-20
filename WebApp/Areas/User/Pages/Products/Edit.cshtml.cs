using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Common.Extentions;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Areas.User.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int id)
        {
            Product = _db.Products.Find(id);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }
        public IActionResult OnPost()
        {
            _db.Products.Add(Product);
            Product.UserId = User.GetUserId();
            Product.Date = DateTime.Now;

            _db.SaveChanges();
            return Page();
        }
    }
}
