using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace BlogCentralApp.Hubs
{
    public class VisitorsHub : Hub
    {
        public static int visitors { get; set; } = 0;

        public async Task Visit(string user, string message)
        {
            visitors++;
            // pass visitors count
            await Clients.All.SendAsync("Visit", visitors);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            visitors--;
            return base.OnDisconnectedAsync(exception);
        }
    }
}
