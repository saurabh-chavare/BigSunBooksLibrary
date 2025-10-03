using BigSun_Application.Data;
using BigSun_Modal.DTOs;
using BigSun_Modal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigSun_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MembersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public MembersController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _context.Members.AnyAsync(m => m.Email == dto.Email))
                return BadRequest("Email already exists.");

            var member = new Member
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddMember), new { id = member.MemberId }, member);
        }
    }
}
