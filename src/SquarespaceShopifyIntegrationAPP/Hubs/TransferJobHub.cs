using Microsoft.AspNetCore.SignalR;

namespace SquarespaceShopifyIntegrationAPP.Hubs
{
    public class TransferJobHub : Hub<ITransferJobHub>
    {
        public async Task SendMessage()
        {
            await Clients.All.ReceiveMessage("Hello");
        }

        public override async Task OnConnectedAsync()
        {            
            await base.OnConnectedAsync();
        }
    }

    public interface ITransferJobHub
    {
        Task ReceiveMessage(string message);
    }
}
