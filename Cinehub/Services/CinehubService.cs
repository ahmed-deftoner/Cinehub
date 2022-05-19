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

    }
}
