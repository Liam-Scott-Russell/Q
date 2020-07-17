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
        
        [HttpGet("{interviewerID}, {eventID}, {choice}")]
        public async Task<ActionResult<Event>> GetHelpAsInterviewer(int interviewerID, string choice)
        {
            var interviewers = _context.Interviewer.ToArray();
            var interviewer = interviewers.First(i => i.UserID.Equals(interviewerID));

            if (choice == "come")
            {
                var booths = _context.Booth.ToArray();
                var boothLink = booths.First(b => b.InterviewerID.Equals(interviewer.UserID));
                // TODO: Notify the event organiser of this help request
                return Ok();
            }
            else if (choice == "go")
            {
                var events = _context.Event.ToArray();
                var helpLink = events.First(e => e.EventID.Equals(interviewer.EventID))?.HelpLink;

                if (helpLink == null)
                {
                    return NotFound();
                }

                return Ok(helpLink);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}