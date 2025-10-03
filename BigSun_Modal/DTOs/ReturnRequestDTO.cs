using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.DTOs
{
    public class ReturnRequestDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BorrowId must be greater than 0")]
        public int BorrowId { get; set; }
    }
    
}
