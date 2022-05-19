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

    }
}
