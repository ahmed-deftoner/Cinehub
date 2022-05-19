using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Logins = new HashSet<Login>();
            Transactions = new HashSet<Transaction>();
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
