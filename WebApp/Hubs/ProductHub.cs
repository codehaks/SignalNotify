using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Hubs
{
    public class ProductHub : Hub
    {
        public void NotifyOthers(Product product)
        {
            Clients.Others.SendAsync("UpdateProduct", product);
        }


    }
}
