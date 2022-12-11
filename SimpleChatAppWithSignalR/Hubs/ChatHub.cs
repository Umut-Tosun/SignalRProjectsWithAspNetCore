using Microsoft.AspNetCore.SignalR;
using SimpleChatAppWithSignalR.Data;
using SimpleChatAppWithSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChatAppWithSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task GetNickName(string nickName)
        {
            Client client = new Client
            {
                connectionId = Context.ConnectionId,
                NickName = nickName
            };
            ClientSource.clients.Add(client);
            await Clients.Others.SendAsync("clientJoined",nickName);
            await Clients.All.SendAsync("clients",ClientSource.clients);
        }
    }
}
