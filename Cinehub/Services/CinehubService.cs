using Cinehub.Models;

namespace Cinehub.Services
{
    public class CinehubService
    {
        private CinehubContext _context;

        public CinehubService()
        {
            _context = new CinehubContext();
        }

        public void InsertBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Booking> GetBookings(int showTimeId)
        {
            var bookings = _context.Bookings
            .Where(b => b.ShowTimeId == showTimeId)
            .ToList();
            return bookings;
        }

        public List<int> getBookingId(string username)
        {
            List<int> bookingsId = new List<int>();
            var bookings = _context.Bookings
            .Where(b => b.Username == username)
            .ToList();
            foreach (var booking in bookings)
            {
                bookingsId.Add(booking.BookingId);
            }
            return bookingsId;
        }

        public List<Movie> getShows(DateTime day)
        {
            var shows = from s in _context.Set<Show>()
                        join m in _context.Set<Movie>()
                         on s.MovieId equals m.MovieId
                        where s.ShowDate.Day == (day.Day)
                        select new
                        { s, m };
            List<Movie> movies = new List<Movie>();
            foreach (var show in shows)
            {
                movies.Add(show.m);
            }
            return movies;
        }

        public Genre GetGenre(Movie movie)
        {
            return _context.Genres.Find(movie.GenreId);
        }

        public int getShowId(Movie movie, DateTime date)
        {
            var shows = from s in _context.Set<Show>()
                        join m in _context.Set<Movie>()
                         on s.MovieId equals m.MovieId
                        where (s.ShowDate.Day == date.Day &&
                        m.MovieId == movie.MovieId)
                        select new
                        { s, m };
            List<Show> list = new List<Show>();
            foreach (var show in shows)
            {
                list.Add(show.s);
            }
            return list[0].ShowId;
        }

        public List<ShowTiming> GetShowTiming(int showId)
        {
            var timing = _context.ShowTimings
            .Where(s => s.ShowId == showId)
            .ToList();
            return timing;
        }

        public List<Movie> GetMovies(string username)
        {
            var movie = from st in _context.Set<ShowTiming>()
                        join b in _context.Set<Booking>() on st.ShowTimeId equals b.ShowTimeId
                        join s in _context.Set<Show>() on st.ShowId equals s.ShowId
                        join m in _context.Set<Movie>() on s.MovieId equals m.MovieId
                        where b.Username == username
                        select new { m };
            List<Movie> movies = new List<Movie>();
            foreach (var mov in movie)
            {
                movies.Add(mov.m);
            }
            return movies;
        }
    }
}
