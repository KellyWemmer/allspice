using allspice.Data;
using allspice.Models;

namespace allspice.Repositories
{
    public class FavoritesRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoritesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        internal Favorite Create(Favorite newFavorite)
        {
            _context.Favorites.Add(newFavorite);
            _context.SaveChanges();
            return newFavorite;
        }
    }
}