using Microsoft.AspNetCore.SignalR;

namespace WebApplication2.Hubs
{
    public class ChatHub : Hub
    {
        //Hosting pets & training (pets , pet owners and pet trainer)
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("AddedToGroup", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }
        //public async Task SendPrivateMessage(string user,string other, string message) =>
        //    await Clients.All.SendAsync("ReceiveMessage", user, other, message);
        //await Clients.User(user).SendAsync("ReceiveMessage", user, other,  message);

        public async Task SendPrivateMessage(string user, string targetConnectionId, string message)
        {
            Console.WriteLine($"{Context.ConnectionId}-{targetConnectionId}-{message}");

            //await Clients.User(...)
            await Clients.Client(targetConnectionId).SendAsync("ReceiveMessageToUser", user, targetConnectionId, message);
        }

        public async Task NewMessage(long username,int chat_code, string message) =>
            await Clients.All.SendAsync("messageReceived", username, chat_code, message);
    }
}
