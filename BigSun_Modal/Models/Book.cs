using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; } = null!;

        public int PublishedYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "AvailableCopies cannot be negative")]
        public int AvailableCopies { get; set; }

        public ICollection<BorrowRecord>? BorrowRecords { get; set; }
    }
}
