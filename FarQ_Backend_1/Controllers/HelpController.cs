using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarQ_Backend_1.Context;
using Q_Backend.Models;

namespace FarQ_Backend_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpController : ControllerBase
    {
        private readonly FarQContext _context;

        public HelpController(FarQContext context)
        {
            _context = context;
        }


        [HttpGet("{eventID}")]
        public async Task<ActionResult<Event>> GetEvent(int eventID)
        {
            var events = from e in _context.Event select e;
            var helpLink = events.First(e => e.EventID.Equals(eventID))?.HelpLink;

            if (helpLink == null)
            {
                return NotFound();
            }

            return Ok(helpLink);
        }
    }
}