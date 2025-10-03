using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.DTOs
{
    public class TopBorrowedDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BookId must be greater than 0")]
        public int BookId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BorrowCount must be at least 1")]
        public int BorrowCount { get; set; }
    }
}
