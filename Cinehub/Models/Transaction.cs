using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? BookingId { get; set; }
        public string? Username { get; set; }
        public string CardType { get; set; } = null!;
        public string CardHolder { get; set; } = null!;
        public int Amount { get; set; }
        public string CardNumber { get; set; } = null!;
        public DateTime ExpiryDate { get; set; }
        public string Cvv { get; set; } = null!;

        public virtual Booking? Booking { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}
