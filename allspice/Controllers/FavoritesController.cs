using allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;

        private readonly RecipesService _recipesService;

        private readonly AccountService _accountService;

        public FavoritesController(FavoritesService favoritesService, RecipesService recipesService, AccountService accountService)
        {
            _favoritesService = favoritesService;
            _recipesService = recipesService;
            _accountService = accountService;
        }

        
        
    }
}