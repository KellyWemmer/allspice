using System.Linq;
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

        internal string Delete(int recipeId, string userId)
        {           
            Favorite favoriteInDb = _context.Favorites.FirstOrDefault(x => x.RecipeId == recipeId && x.AccountId == userId);
            if(favoriteInDb != null)
            {
                _context.Favorites.Remove(favoriteInDb);
                _context.SaveChanges();
                return "Favorite was deleted";
            } else 
                return "Favorite was not found";

               
        }
    }
}