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
    public class StepsController : ControllerBase
    {
        private readonly StepsService _stepsService;

        private readonly RecipesService _recipesService;

        public StepsController(StepsService stepsService, RecipesService recipesService)
        {
            _stepsService = stepsService;
        }
        [HttpGet("{recipeId}/StepsByRecipeId")]

        public ActionResult<List<Step>>GetStepsByRecipeId(int recipeId)
        {
            try 
            {
                List<Step> steps = _stepsService.GetStepsByRecipeId(recipeId);
                return Ok(steps);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        
        public async Task<ActionResult<Step>> Create([FromBody] Step newStep)
        {
            try 
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Recipe recipe = _recipesService.GetRecipeById(newStep.RecipeId);
                if(recipe.CreatorId == userInfo.Id)
                {
                    Step step = _stepsService.Create(newStep);
                    return Ok(step);
                }
                return BadRequest("You are not authorized to do this");

            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}