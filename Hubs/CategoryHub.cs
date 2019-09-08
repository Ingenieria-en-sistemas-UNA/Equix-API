using EquixAPI.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Hubs
{
    public class CategoryHub : Hub
    {
        public async Task SendCategory(Category category)
        {
            await Clients.All.SendAsync("SendCategory", new object[] { category });
        }
    }
}
