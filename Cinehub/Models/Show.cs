using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class Show
    {
        public Show()
        {
            ShowTimings = new HashSet<ShowTiming>();
        }

        public int ShowId { get; set; }
        public int? MovieId { get; set; }
        public DateTime ShowDate { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual ICollection<ShowTiming> ShowTimings { get; set; }
    }
}
