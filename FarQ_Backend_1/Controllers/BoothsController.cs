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
    public class BoothsController : ControllerBase
    {
        private readonly FarQContext _context;

        public BoothsController(FarQContext context)
        {
            _context = context;
        }

        // GET: api/Booths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booth>>> GetBooth()
        {
            return await _context.Booth.ToListAsync();
        }

        // GET: api/Booths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booth>> GetBooth(int id)
        {
            var booth = await _context.Booth.FindAsync(id);

            if (booth == null)
            {
                return NotFound();
            }

            return booth;
        }

        // PUT: api/Booths/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooth(int id, Booth booth)
        {
            if (id != booth.BoothID)
            {
                return BadRequest();
            }

            _context.Entry(booth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoothExists(id))
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

        // POST: api/Booths
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Booth>> PostBooth(Booth booth)
        {
            _context.Booth.Add(booth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooth", new { id = booth.BoothID }, booth);
        }

        // POST: api/Booths
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("updateAvailability")]
        public async Task<ActionResult<Booth>> PostBoothAvailability(int boothID, bool isAvailable)
        {
            var booth = GetBoothById(boothID);
            booth.IsAvailable = isAvailable;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Booths/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booth>> DeleteBooth(int id)
        {
            var booth = await _context.Booth.FindAsync(id);
            if (booth == null)
            {
                return NotFound();
            }

            _context.Booth.Remove(booth);
            await _context.SaveChangesAsync();

            return booth;
        }

        private bool BoothExists(int id)
        {
            return _context.Booth.Any(e => e.BoothID == id);
        }

        private Booth GetBoothById(int id) 
        {
            var booths = _context.Booth.ToArray();
            return booths.First(booth => booth.BoothID == id);
        }
    }
}
