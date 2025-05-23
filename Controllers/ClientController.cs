using ClientManagementSystem.Data;
using ClientManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Require authenticated users for all actions
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/client
        [HttpGet]
        [Authorize(Roles = "Admin,User")]  // Admin and User can read
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/client/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return NotFound();

            return client;
        }

        // POST: api/client
        [HttpPost]
        [Authorize(Roles = "Admin")]  // Only Admin can create
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        // PUT: api/client/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]  // Only Admin can update
        public async Task<IActionResult> UpdateClient(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clients.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/client/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]  // Only Admin can delete
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
