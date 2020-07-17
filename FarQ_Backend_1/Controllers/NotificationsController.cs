using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarQ_Backend_1.Context;
using Q_Backend.Models;
using FarQ_Backend_1.DTOs;

namespace FarQ_Backend_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly FarQContext _context;

        public NotificationsController(FarQContext context)
        {
            _context = context;
        }

        // GET: api/Notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotification()
        {
            return await _context.Notification.ToListAsync();
        }

        // GET: api/Notifications/5
        [HttpGet("getnotificationbyid")]
        public List<Notification> GetNotification(int userID)
        {
            var allNotifications = _context.Notification.ToList();
            var notifications = allNotifications.Where(x => x.RespondentID == userID && x.IsActioned == false).ToList();

            if (notifications == null)
            {
                return new List<Notification>();
            }

            return notifications;
        }

        // PUT: api/Notifications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotification(int id, Notification notification)
        {
            if (id != notification.NotificationID)
            {
                return BadRequest();
            }

            _context.Entry(notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Notifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("postNotification")]
        public async Task<ActionResult<Notification>> PostNotification(NotificationRequest notificationRequest)
        {
            
            if (notificationRequest.RequestRole == "Event Organiser")
            {
                List<EventOrganiser> eventOrganisers = _context.EventOrganiser.ToList();

                foreach (var eventOrganiser in eventOrganisers)
                {
                    Notification noti = new Notification
                    {
                        IsActioned = false,
                        Message = notificationRequest.Message,
                        Payload = notificationRequest.Payload,
                        RequesterID = notificationRequest.RequesterID,
                        RespondentID = eventOrganiser.UserID
                    };

                    _context.Notification.Add(noti);
                    await _context.SaveChangesAsync();
                }
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("dismissNotification")]
        public async Task<ActionResult<Notification>> DismissNotification(int notificationID)
        {
            var notification = GetNotificationById(notificationID);
            notification.IsActioned = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notification>> DeleteNotification(int id)
        {
            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.Notification.Remove(notification);
            await _context.SaveChangesAsync();

            return notification;
        }

        private bool NotificationExists(int id)
        {
            return _context.Notification.Any(e => e.NotificationID == id);
        }

        private Notification GetNotificationById(int id)
        {
            var notifications = _context.Notification.ToArray();
            return notifications.First(x => x.NotificationID == id);
        }
    }
}
