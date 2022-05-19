using System;
using System.Collections.Generic;

namespace Cinehub.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Shows = new HashSet<Show>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; } = null!;
        public TimeSpan Runtime { get; set; }
        public double Rating { get; set; }
        public int? GenreId { get; set; }
        public string Certification { get; set; } = null!;
        public string? ImageSrc { get; set; }
        public string? TrailerUrl { get; set; }

        public virtual Genre? Genre { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
