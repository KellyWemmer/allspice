using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _favoritesService;

        public FavoritesController(FavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }
        
    }
}