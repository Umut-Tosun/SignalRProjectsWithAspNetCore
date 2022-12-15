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
            await Clients.Others.SendAsync("clientJoined", nickName);
            await Clients.All.SendAsync("clients", ClientSource.clients);
            await Clients.All.SendAsync("groups", GroupSource.groups);
        }
        public async Task SendMessageAsync(string message, string clientName)
        {
            clientName = clientName.Trim();
            Client senderClient = ClientSource.clients.FirstOrDefault(x => x.connectionId == Context.ConnectionId);
            if (clientName == "Tümü")
            {
                await Clients.Others.SendAsync("receiveMessage", message, senderClient.NickName);
            }
            else
            {
                Client client = ClientSource.clients.FirstOrDefault(x => x.NickName == clientName);
                await Clients.Client(client.connectionId).SendAsync("receiveMessage", message, senderClient.NickName);
            }
        }
        public async Task AddGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Group group = new Group { GroupName = groupName };
            group.Clients.Add(ClientSource.clients.FirstOrDefault(x => x.connectionId == Context.ConnectionId));
            GroupSource.groups.Add(group);

            await Clients.All.SendAsync("groups", GroupSource.groups);
        }
        public async Task AddClientToGroup(IEnumerable<string> groupNames)
        {
            Client client = ClientSource.clients.FirstOrDefault(x => x.connectionId == Context.ConnectionId);
            foreach (var groupName in groupNames)
            {
                Group _group = GroupSource.groups.FirstOrDefault(x => x.GroupName == groupName);

                var result = _group.Clients.Any(c => c.connectionId == Context.ConnectionId);
                if (!result)
                {
                    _group.Clients.Add(client);
                    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
                }
            }
        }
        public async Task GetClientToGroup(string groupName)
        {

            Group group = GroupSource.groups.FirstOrDefault(x => x.GroupName == groupName);
            await Clients.Caller.SendAsync("clients",groupName!="-1" ?group.Clients:ClientSource.clients);

        }
        public async Task SendMessageToGroupAsync(string groupName,string message)
        {
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage",message,ClientSource.clients.FirstOrDefault(x=>x.connectionId==Context.ConnectionId).NickName);

        }
    }
}
