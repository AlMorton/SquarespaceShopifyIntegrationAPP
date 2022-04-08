using Microsoft.AspNetCore.SignalR;

namespace SquarespaceShopifyIntegrationAPP.Hubs
{
    public class TransferJobHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Hello");
        }

        public override async Task OnConnectedAsync()
        {            
            await base.OnConnectedAsync();
        }
    }
}
