using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.DTOs
{
    public class BookDTO
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Author is required")]
        [StringLength(150, MinimumLength = 1)]
        public string Author { get; set; } = null!;

        [Required(ErrorMessage = "ISBN is required")]
        [MaxLength(20)]
        public string ISBN { get; set; } = null!;

        public int PublishedYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "AvailableCopies cannot be negative")]
        public int AvailableCopies { get; set; }
    }
}
