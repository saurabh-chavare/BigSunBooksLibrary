using BigSun_Application.Data;
using BigSun_Modal.DTOs;
using BigSun_Modal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BigSun_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BorrowController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BorrowController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> BorrowBook(BorrowRequestDTO dto)
        {
            var book = await _context.Books.FindAsync(dto.BookId);
            if (book == null) return NotFound("Book not found.");
            if (book.AvailableCopies <= 0) return BadRequest("Book not available.");

            var member = await _context.Members.FindAsync(dto.MemberId);
            if (member == null) return NotFound("Member not found.");

            var borrow = new BorrowRecord
            {
                MemberId = dto.MemberId,
                BookId = dto.BookId,
                BorrowDate = DateTime.Now,
                IsReturned = false
            };

            book.AvailableCopies -= 1;
            _context.BorrowRecords.Add(borrow);
            await _context.SaveChangesAsync();

            return Ok("Book borrowed successfully.");
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook(ReturnRequestDTO dto)
        {
            var record = await _context.BorrowRecords.FindAsync(dto.BorrowId);
            if (record == null) return NotFound("Borrow record not found.");
            if (record.IsReturned) return BadRequest("Book already returned.");

            record.IsReturned = true;
            record.ReturnDate = DateTime.Now;

            var book = await _context.Books.FindAsync(record.BookId);
            book.AvailableCopies += 1;

            await _context.SaveChangesAsync();
            return Ok("Book returned successfully.");
        }
    }
}
