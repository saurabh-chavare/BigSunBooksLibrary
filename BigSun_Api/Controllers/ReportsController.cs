using BigSun_Application.Data;
using BigSun_Modal.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigSun_Api.Controllers
{
    [ApiController]
    [Route("api/reports")]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ReportsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet("top-borrowed")]
        public async Task<IActionResult> TopBorrowed()
        {
            var topBooks = await _context.BorrowRecords
                .Include(br => br.Book)
                .GroupBy(br => br.BookId)
                .Select(g => new TopBorrowedDTO
                {
                    BookId = g.Key,
                    Title = g.First().Book.Title,
                    BorrowCount = g.Count()
                })
                .OrderByDescending(x => x.BorrowCount)
                .Take(5)
                .ToListAsync();

            return Ok(topBooks);
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> Overdue()
        {
            var overdue = await _context.BorrowRecords
                .Include(br => br.Book)
                .Include(br => br.Member)
                .Where(br => !br.IsReturned && br.BorrowDate.AddDays(14) < DateTime.Now)
                .Select(br => new OverdueBookDTO
                {
                    BorrowId = br.BorrowId,
                    MemberName = br.Member.Name,
                    MemberEmail = br.Member.Email,
                    BookTitle = br.Book.Title,
                    BorrowDate = br.BorrowDate
                })
                .ToListAsync();

            return Ok(overdue);
        }
    }
}
