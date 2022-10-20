using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _favoritesRepo;
        private readonly RecipesService _recipesService;

        public FavoritesService(FavoritesRepository favoritesRepo, RecipesService recipesService)
        {
            _favoritesRepo = favoritesRepo;
            _recipesService = recipesService;
        }
        internal Favorite Create(Favorite newFavorite)
        {
             return _favoritesRepo.Create(newFavorite);              
        }
    }

}