using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalrback.Hubs;
using signalrback.Models;

namespace signalrback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly IHubContext<Mensaje> _hubContext;
        public SenderController(IHubContext<Mensaje> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public IActionResult SendArticulo([FromBody] Articulo a)
        {
            string art = Newtonsoft.Json.JsonConvert.SerializeObject(a);
            //Envío a Hub
            _hubContext.Clients.All.SendAsync("enviar", art);
           
            return Ok(new { r = "Enviado" }); //JSON que devuelvo una vez ejecutada la petición.
        }

    }
}
