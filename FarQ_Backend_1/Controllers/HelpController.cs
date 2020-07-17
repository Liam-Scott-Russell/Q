using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarQ_Backend_1.Context;
using Q_Backend.Models;
using FarQ_Backend_1.DTOs;

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
        
        [HttpGet("getHelpAsUser")]
        public async Task<ActionResult<Event>> GetHelpAsUser(int userID)
        {
            var user = await _context.User.FindAsync(userID);
            if (user != null)
            {
                NotificationsController notificationsController = new NotificationsController(_context);
                NotificationRequest notificationRequest = new NotificationRequest
                {
                    RequestRole = "Event Organiser",
                    RequesterID = userID,
                    Message = $"{user.Name} has requested help in their room",
                    Payload = string.Empty
                };

                await notificationsController.PostNotification(notificationRequest);
                return Ok();
            }

            return NotFound();

        }
        
        
        [HttpGet("{interviewerID}, {eventID}, {choice}")]
        public async Task<ActionResult<Event>> GetHelpAsInterviewer(int interviewerID, string choice)
        {
            var interviewers = _context.Interviewer.ToArray();
            var interviewer = interviewers.First(i => i.UserID.Equals(interviewerID));

            if (choice == "come")
            {
                var booths = _context.Booth.ToArray();
                var boothLink = booths.First(b => b.InterviewerID.Equals(interviewer.UserID)).Payload;
                
                var notificationsController = new NotificationsController(_context);
                var notificationRequest = new NotificationRequest
                {
                    RequestRole = "Event Organiser",
                    RequesterID = interviewerID,
                    Message = interviewer.Name + " has requested help in their room",
                    Payload = boothLink
                };

                await notificationsController.PostNotification(notificationRequest);
                return Ok();
            }

            if (choice == "go")
            {
                var events = _context.Event.ToArray();
                var helpLink = events.First(e => e.EventID.Equals(interviewer.EventID))?.HelpLink;

                if (helpLink == null)
                {
                    return NotFound();
                }

                return Ok(helpLink);
            }
                
            return BadRequest();
        }
    }
}