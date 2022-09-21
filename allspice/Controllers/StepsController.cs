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
            _recipesService = recipesService;
        }

        [HttpGet("{id}")]
        public ActionResult<Step> GetStepById(int id)
        {
            try 
            {
                return Ok(_stepsService.GetStepById(id));
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
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

        [HttpPut("{id}")]
        [Authorize]

        public ActionResult<Step> Update(int id, [FromBody] Step stepUpdate){
            try 
            {
                stepUpdate.Id = id;
                return Ok(_stepsService.Update(stepUpdate));
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]

        public ActionResult<string> Delete(int id)
        {
            try 
            {
                return Ok(_stepsService.Delete(id));
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
    }
}