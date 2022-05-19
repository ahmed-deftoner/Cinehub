using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int BookingId { get; set; }
        public int ShowTimeId { get; set; }
        public string Username { get; set; } = null!;
        public int NoOfSeats { get; set; }
        public string SeatNumbers { get; set; } = null!;

        public virtual ShowTiming ShowTime { get; set; } = null!;
        public virtual User UsernameNavigation { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
