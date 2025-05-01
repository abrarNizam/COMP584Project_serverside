using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Server.Models;

namespace Portfolio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProjectContext _context;

        public UserProfileController(UserProjectContext context)
        {
            _context = context;
        }

        // GET: api/UserProfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfiles>>> GetUserProfiles()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        // GET: api/UserProfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfiles>> GetUserProfiles(int id)
        {
            var userProfiles = await _context.UserProfiles.FindAsync(id);

            if (userProfiles == null)
            {
                return NotFound();
            }

            return userProfiles;
        }

        // PUT: api/UserProfile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfiles(int id, UserProfiles userProfiles)
        {
            if (id != userProfiles.UserID)
            {
                return BadRequest();
            }

            _context.Entry(userProfiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfilesExists(id))
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

        // POST: api/UserProfile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserProfiles>> PostUserProfiles(UserProfiles userProfiles)
        {
            _context.UserProfiles.Add(userProfiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserProfiles", new { id = userProfiles.UserID }, userProfiles);
        }

        // DELETE: api/UserProfile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfiles(int id)
        {
            var userProfiles = await _context.UserProfiles.FindAsync(id);
            if (userProfiles == null)
            {
                return NotFound();
            }

            _context.UserProfiles.Remove(userProfiles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserProfilesExists(int id)
        {
            return _context.UserProfiles.Any(e => e.UserID == id);
        }
    }
}
