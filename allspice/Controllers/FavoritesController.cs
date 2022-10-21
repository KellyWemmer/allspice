using System;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Favorite>> Create(Favorite newFavorite)
        {
            try 
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                Recipe recipe = _recipesService.GetRecipeById(newFavorite.RecipeId);
                if(user.Id == newFavorite.AccountId && recipe != null)
                {
                    Favorite favorite = _favoritesService.Create(newFavorite);
                    return Ok(favorite);
                }
                return BadRequest("You need to be logged in to create a favorite");
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpDelete("{recipeId}")]
        [Authorize]

        public async Task<ActionResult<string>> Delete(int recipeId)
        {
            try 
            {
              Account user = await HttpContext.GetUserInfoAsync<Account>();

              string message = _favoritesService.Delete(recipeId, user.Id);
              return Ok(message);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }        
        
    }
}