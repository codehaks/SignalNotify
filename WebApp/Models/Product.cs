using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
