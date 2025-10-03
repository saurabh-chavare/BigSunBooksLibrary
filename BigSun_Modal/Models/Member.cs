using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime JoinDate { get; set; } = DateTime.Now;

        public ICollection<BorrowRecord>? BorrowRecords { get; set; }
    }
}
