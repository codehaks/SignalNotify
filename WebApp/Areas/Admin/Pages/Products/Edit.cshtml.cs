using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using WebApp.Data;
using WebApp.Hubs;
using WebApp.Models;

namespace WebApp.Areas.Admin.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHubContext<ProductHub> _hub;

        public EditModel(ApplicationDbContext db, IHubContext<ProductHub> hub)
        {
            _db = db;
            _hub = hub;
        }
        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var product = _db.Products.Find(Product.Id);

            //product.Id = Product.Id;
            product.IsActive = Product.IsActive;
            product.Price = Product.Price;

            _db.SaveChanges();

            await _hub.Clients.All.SendAsync("UpdateProduct", product);
            return RedirectToPage("/products/index");
        }

        public void OnGet(int id)
        {
            Product = _db.Products.Find(id);
        }
    }
}
