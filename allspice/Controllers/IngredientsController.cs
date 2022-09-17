using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
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
    }

    
}