using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.DTOs
{
    public class BorrowRequestDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "MemberId must be greater than 0")]
        public int MemberId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BookId must be greater than 0")]
        public int BookId { get; set; }
    }
}
