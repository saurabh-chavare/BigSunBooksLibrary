using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.DTOs
{
    public class OverdueBookDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BorrowId must be greater than 0")]
        public int BorrowId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "MemberName cannot be empty")]
        public string MemberName { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string MemberEmail { get; set; } = null!;

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "BookTitle cannot be empty")]
        public string BookTitle { get; set; } = null!;

        [Required]
        public DateTime BorrowDate { get; set; }
    }
}
