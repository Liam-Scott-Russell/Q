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
    public class PoolsController : ControllerBase
    {
        private readonly FarQContext _context;

        public PoolsController(FarQContext context)
        {
            _context = context;
        }

        // GET: api/Pools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pool>>> GetPool()
        {
            return await _context.Pool.ToListAsync();
        }

        // GET: api/Pools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pool>> GetPool(string id)
        {
            var pool = await _context.Pool.FindAsync(id);

            if (pool == null)
            {
                return NotFound();
            }

            return pool;
        }

        // PUT: api/Pools/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPool(string id, Pool pool)
        {
            if (id != pool.Booths)
            {
                return BadRequest();
            }

            _context.Entry(pool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoolExists(id))
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

        // POST: api/Pools
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pool>> PostPool(Pool pool)
        {
            _context.Pool.Add(pool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPool", new { id = pool.Booths }, pool);
        }

        // DELETE: api/Pools/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pool>> DeletePool(string id)
        {
            var pool = await _context.Pool.FindAsync(id);
            if (pool == null)
            {
                return NotFound();
            }

            _context.Pool.Remove(pool);
            await _context.SaveChangesAsync();

            return pool;
        }

        private bool PoolExists(string id)
        {
            return _context.Pool.Any(e => e.Booths == id);
        }
    }
}
