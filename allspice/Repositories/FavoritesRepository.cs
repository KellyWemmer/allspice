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

        //Checks to see if there is a favorite for this recipe/account, if not, it will return null
        internal Favorite GetFavoriteIfExists(int recipeId, string accountId)
        {
            return _context.Favorites.FirstOrDefault(f => f.RecipeId == recipeId && f.AccountId == accountId);
        }
    }
}