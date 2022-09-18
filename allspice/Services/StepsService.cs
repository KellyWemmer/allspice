using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
    public class StepsService
    {
        private readonly StepsRepository _stepsRepo;

        public StepsService(StepsRepository stepsRepo)
        {
            _stepsRepo = stepsRepo;
        }
        internal List<Step> GetStepsByRecipeId(int recipeId)
        {
            return _stepsRepo.GetStepsByRecipeId(recipeId);
        }
    }
}