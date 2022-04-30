using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace signalrback.Hubs
{
    public class Mensaje : Hub
    {
        public Task NotificaATodos(string mensaje)
        {
            return Clients.All.SendAsync("prepararVneta", mensaje); //Suscripción.
        }
    }
}
