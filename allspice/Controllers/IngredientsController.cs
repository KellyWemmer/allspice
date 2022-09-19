using System;
using System.Collections.Generic;
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
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;

        private readonly RecipesService _recipesService;

        public IngredientsController(IngredientsService ingredientsService, RecipesService recipesService)
        {
            _ingredientsService = ingredientsService;
            _recipesService = recipesService;
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetIngredientById(int id)
        {
            try 
            {
                return Ok(_ingredientsService.GetIngredientById(id));
            }
            
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("{recipeId}/IngredientsByRecipeId")]
        public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
        {
            try 
            {
                List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
                return Ok(ingredients);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient newIngredient)
        {
            try 
            {              
                Account userInfo =  await HttpContext.GetUserInfoAsync<Account>();
                Recipe recipe = _recipesService.GetRecipeById(newIngredient.RecipeId);
                if(recipe.CreatorId == userInfo.Id)
                {
                    Ingredient ingredient = _ingredientsService.Create(newIngredient);
                    return Ok(ingredient);
                }
                return BadRequest("You are not authorized to do this");
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        // [HttpDelete("{id}")]
        // public ActionResult<string> Delete(int id)
        // {
        //     try 
        //     {
        //         return Ok(_ingredientsService.Delete(id));
        //     }
        //     catch (Exception e)
        //     {
        //       return BadRequest(e.Message);
        //     }
        // }
    }

    
}