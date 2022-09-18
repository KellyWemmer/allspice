using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StepsController : ControllerBase
    {
        private readonly StepsService _stepsService;

        public StepsController(StepsService stepsService)
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
    }
}