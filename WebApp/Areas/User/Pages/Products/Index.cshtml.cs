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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Product> ProductList { get; set; }

        public void OnGet()
        {
            ProductList = _db.Products
                .Where(p => p.UserId == User.GetUserId())
                .ToList();
        }
    }
}
