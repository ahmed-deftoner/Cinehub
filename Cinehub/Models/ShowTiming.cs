using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class ShowTiming
    {
        public ShowTiming()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ShowTimeId { get; set; }
        public int ShowId { get; set; }
        public string ScreenType { get; set; } = null!;
        public TimeSpan ShowTime { get; set; }

        public virtual ScreenType ScreenTypeNavigation { get; set; } = null!;
        public virtual Show Show { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
