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
    [ApiController]//Is attribute - inherits from Attributes Class
    [Route("api/[controller]")]//Base URL /api/controller name - 'controller' -> https://localhost:5001/api/Recipes
    public class RecipesController : ControllerBase //Inherit from controller base to use their stuff
    {
        private readonly RecipesService _recipesService; //_ means private property

        public RecipesController(RecipesService recipesService)//RecipesService is datatype
        {
            _recipesService = recipesService;//recipeService is being assigned to _recipeService to be used throughout the class
        }

        [HttpGet] //https://localhost:5001/api/Recipes
        public ActionResult<List<Recipe>> GetRecipes()//Action result is return type, List is the type of ActionResult, the Recipe is the type of List.
        {
            try 
            {
              List<Recipe> recipes = _recipesService.GetRecipes();
              return Ok(recipes);//this passes recipes to the OK-method which is an action result
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipeById(int id)
        {
          try 
          {
            Recipe recipe = _recipesService.GetRecipeById(id);
            return Ok(recipe);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody]Recipe newRecipe)
        {
          try 
          {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            newRecipe.CreatorId = userInfo.Id;
            Recipe recipe = _recipesService.Create(newRecipe);
            recipe.Creator = userInfo;
            return Ok(recipe);
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          }
        } 
        
    }
}