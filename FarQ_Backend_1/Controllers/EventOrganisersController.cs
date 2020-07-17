using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarQ_Backend_1.Context;
using Q_Backend.Models;

namespace FarQ_Backend_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventOrganisersController : ControllerBase
    {
        private readonly FarQContext _context;

        public EventOrganisersController(FarQContext context)
        {
            _context = context;
        }

        // GET: api/EventOrganisers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventOrganiser>>> GetEventOrganiser()
        {
            return await _context.EventOrganiser.ToListAsync();
        }

        // GET: api/EventOrganisers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventOrganiser>> GetEventOrganiser(string id)
        {
            var eventOrganiser = await _context.EventOrganiser.FindAsync(id);

            if (eventOrganiser == null)
            {
                return NotFound();
            }

            return eventOrganiser;
        }

        // PUT: api/EventOrganisers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventOrganiser(string id, EventOrganiser eventOrganiser)
        {
            if (id != eventOrganiser.Name)
            {
                return BadRequest();
            }

            _context.Entry(eventOrganiser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventOrganiserExists(id))
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

        // POST: api/EventOrganisers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventOrganiser>> PostEventOrganiser(EventOrganiser eventOrganiser)
        {
            _context.EventOrganiser.Add(eventOrganiser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventOrganiser", new { id = eventOrganiser.Name }, eventOrganiser);
        }

        // DELETE: api/EventOrganisers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventOrganiser>> DeleteEventOrganiser(string id)
        {
            var eventOrganiser = await _context.EventOrganiser.FindAsync(id);
            if (eventOrganiser == null)
            {
                return NotFound();
            }

            _context.EventOrganiser.Remove(eventOrganiser);
            await _context.SaveChangesAsync();

            return eventOrganiser;
        }

        private bool EventOrganiserExists(string id)
        {
            return _context.EventOrganiser.Any(e => e.Name == id);
        }
    }
}
