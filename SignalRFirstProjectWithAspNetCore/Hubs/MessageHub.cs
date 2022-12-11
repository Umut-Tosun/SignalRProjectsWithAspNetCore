using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRFirstProjectWithAspNetCore.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //{
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //{
        //public async Task SendMessageAsync(string message, IEnumerable<string> groupNames)
        //{
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Hub Clients Metotları
            /*
             * AllExcept - belirtilen client dışında tüm clientlara iletişim kurar
             * Client - belirtilen client ile iletişim kurulur
             * Clients - belirtilen client dışındakiler ile iletişim kurmaz
             * Groups - Belirtilen gruplardaki tüm clientslar ile iletişim kurar.önce grup kurulmalı sonra clientler subcsribe olmalıdır.
             * GroupsExcept - belirtilen grup dışındaki belirtilen client dışındakilar hariç tüm clientlar ile iletişim kurar
             * Group  - Belirtilen grupta tüm clientslar ile iletişim kurar.önce grup kurulmalı sonra clientler subcsribe olmalıdır.
             * OthersInGroup - bildiride bulunan client harici gruptaki tüm clientlara iletişim gönderir.
             * User
             * Users     
             */
            #endregion
            /*
            * Caller
            * sadece servera bildirim gönderen client`la iletişim kurar.
            * await Clients.Caller.SendAsync("receiveMessage",message);
            */

            /* 
            * All
            * servera bildirim gönderen client`ların hepsiyle iletişim kurar.
            * await Clients.All.SendAsync("receiveMessage", message);
            */

            /*
            * Others
            * sadece servere bildirim gönderen client dışında servere bağlı olan tüm clientlarla iletişim kurar
            * await Clients.Others.SendAsync("receiveMessage", message);
            */

            /*
            *  AllExcept
            *  await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            *  
            */

            /*
            * Client
            * await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            * 
            */

            /*
            * Clients
            * await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            * 
            */

            /*
            * Group
            * await Clients.Group(groupName).SendAsync("receiveMessage", message);
            * 
            */

            /*
            * GroupExcept
            * await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            * 
            */

            /*
            * Groups
            * await Clients.Groups(groupNames).SendAsync("receiveMessage", message);
            * 
            */

            /*
            * OthersInGroup
            * await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            */

        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
