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
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _context.Books.AnyAsync(b => b.ISBN == dto.ISBN))
                return BadRequest("ISBN already exists.");

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublishedYear = dto.PublishedYear,
                AvailableCopies = dto.AvailableCopies
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooks), new { id = book.BookId }, book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author,
                    b.ISBN,
                    b.PublishedYear,
                    b.AvailableCopies,
                    IsAvailable = b.AvailableCopies > 0
                })
                .ToListAsync();

            return Ok(books);
        }
    }
}
