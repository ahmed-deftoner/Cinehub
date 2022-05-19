using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public int GenreId { get; set; }
        public string Genre1 { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
