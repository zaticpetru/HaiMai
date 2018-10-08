using Microsoft.AspNet.SignalR;
using SignalRWebApp.Models;

namespace SignalRWebApp.Hubs
{
    public class DrawHub : Hub
    {
        public void Send(Draw data)
        {
            Clients.AllExcept(Context.ConnectionId).addLine(data);
        }
    }
}