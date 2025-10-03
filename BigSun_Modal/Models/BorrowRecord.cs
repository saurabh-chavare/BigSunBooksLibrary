using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSun_Modal.Models
{
    public class BorrowRecord
    {
        public int BorrowId { get; set; }  // Primary key

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
    }
}
