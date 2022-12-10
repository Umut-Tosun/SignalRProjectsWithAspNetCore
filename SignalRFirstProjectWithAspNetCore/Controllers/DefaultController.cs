using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRFirstProjectWithAspNetCore.Business;
using SignalRFirstProjectWithAspNetCore.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRFirstProjectWithAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        readonly MyBusiness _myBusiness;
        readonly IHubContext<MyHub> _hubContext;

        public DefaultController(MyBusiness myBusiness, IHubContext<MyHub> hubContext)
        {
            _myBusiness = myBusiness;
            _hubContext = hubContext;
        }

        [HttpGet("{message}")]
        public async Task<ActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);

            return Ok();
        }
    }
}
