using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRFirstProjectWithAspNetCore.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
          await  Clients.All.SendAsync("receiveMessage",message);
        }
    }
}
