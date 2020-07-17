using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarQ_Backend_1.Context;
using Q_Backend.Models;
using Newtonsoft.Json;

namespace FarQ_Backend_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueuesController : ControllerBase
    {
        private readonly FarQContext _context;

        public QueuesController(FarQContext context)
        {
            _context = context;
        }

        // GET: api/Queues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Queue>>> GetQueue()
        {
            return await _context.Queue.ToListAsync();
        }

        // GET: api/Queues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Queue>> GetQueue(int id)
        {
            var queue = await _context.Queue.FindAsync(id);

            if (queue == null)
            {
                return NotFound();
            }

            return queue;
        }

        // PUT: api/Queues/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueue(int id, Queue queue)
        {
            if (id != queue.QueueID)
            {
                return BadRequest();
            }

            _context.Entry(queue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueueExists(id))
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

        // POST: api/Queues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Queue>> PostQueue(Queue queue)
        {
            queue.UserIDs = JsonConvert.SerializeObject(new Queue<int>());
            _context.Queue.Add(queue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQueue", new { id = queue.QueueID }, queue);
        }

        // DELETE: api/Queues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Queue>> DeleteQueue(int id)
        {
            var queue = await _context.Queue.FindAsync(id);
            if (queue == null)
            {
                return NotFound();
            }

            _context.Queue.Remove(queue);
            await _context.SaveChangesAsync();

            return queue;
        }

        [HttpPost("addUser")]
        public async Task<ActionResult<Queue>> AddUser(int queueID, int userID)
        {
            var queues = _context.Queue.ToList();
            Queue queue = queues.First(queue => queue.QueueID.Equals(queueID));
            var userIDs = JsonConvert.DeserializeObject<Queue<int>>(queue.UserIDs);
            userIDs.Enqueue(userID);
            queue.UserIDs = JsonConvert.SerializeObject(userIDs);
            await _context.SaveChangesAsync();
            return queue;
        }

        [HttpPost("popQueue")]
        public async Task<ActionResult<Queue>> PopUser(int queueID)
        {
            var queues = _context.Queue.ToList();
            Queue queue = queues.First(queue => queue.QueueID.Equals(queueID));
            var userIDs = JsonConvert.DeserializeObject<Queue<int>>(queue.UserIDs);
            userIDs.Dequeue();
            queue.UserIDs = JsonConvert.SerializeObject(userIDs);
            await _context.SaveChangesAsync();
            return queue;
        }

        private bool QueueExists(int id)
        {
            return _context.Queue.Any(e => e.QueueID == id);
        }
    }
}
