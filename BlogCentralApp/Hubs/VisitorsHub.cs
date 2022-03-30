using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BlogCentralApp.Hubs
{
    public class VisitorsHub : Hub
    {
        public async Task Visit(string user, string message)
        {
            await Clients.All.SendAsync("Visit", "visit send async");
        }
    }
}
