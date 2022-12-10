using Microsoft.AspNetCore.SignalR;
using SignalRFirstProjectWithAspNetCore.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRFirstProjectWithAspNetCore.Business
{
    public class MyBusiness
    {
        IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
