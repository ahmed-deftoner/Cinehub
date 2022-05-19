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

    }
}
