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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnPost()
        {
            
            Product.UserId = User.GetUserId();
            Product.Date = DateTime.Now;
            _db.Products.Add(Product);
            _db.SaveChanges();
            return RedirectToPage("/index");
        }
    }
}
