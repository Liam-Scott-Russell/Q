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
    public class InterviewersController : ControllerBase
    {
        private readonly FarQContext _context;

        public InterviewersController(FarQContext context)
        {
            _context = context;
        }

        // GET: api/Interviewers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interviewer>>> GetInterviewer()
        {
            return await _context.Interviewer.ToListAsync();
        }

        // GET: api/Interviewers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interviewer>> GetInterviewer(string id)
        {
            var interviewer = await _context.Interviewer.FindAsync(id);

            if (interviewer == null)
            {
                return NotFound();
            }

            return interviewer;
        }

        // PUT: api/Interviewers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewer(string id, Interviewer interviewer)
        {
            if (id != interviewer.Name)
            {
                return BadRequest();
            }

            _context.Entry(interviewer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewerExists(id))
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

        // POST: api/Interviewers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Interviewer>> PostInterviewer(Interviewer interviewer)
        {
            _context.Interviewer.Add(interviewer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewer", new { id = interviewer.Name }, interviewer);
        }

        // DELETE: api/Interviewers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interviewer>> DeleteInterviewer(string id)
        {
            var interviewer = await _context.Interviewer.FindAsync(id);
            if (interviewer == null)
            {
                return NotFound();
            }

            _context.Interviewer.Remove(interviewer);
            await _context.SaveChangesAsync();

            return interviewer;
        }

        private bool InterviewerExists(string id)
        {
            return _context.Interviewer.Any(e => e.Name == id);
        }
    }
}
