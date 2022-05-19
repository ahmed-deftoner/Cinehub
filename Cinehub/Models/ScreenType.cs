using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class ScreenType
    {
        public ScreenType()
        {
            ShowTimings = new HashSet<ShowTiming>();
        }

        public string ScreenType1 { get; set; } = null!;
        public int Price { get; set; }

        public virtual ICollection<ShowTiming> ShowTimings { get; set; }
    }
}
