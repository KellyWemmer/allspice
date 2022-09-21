using System;
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
        internal Step GetStepById(int id)
        {
            Step step = _stepsRepo.GetStepById(id);
            if(step == null)
            {
                throw new Exception ("There's no step by that Id");
            }
            return step;
        }
        internal List<Step> GetStepsByRecipeId(int recipeId)
        {
            return _stepsRepo.GetStepsByRecipeId(recipeId);
        }

        internal Step Create(Step newStep)
        {
            return _stepsRepo.Create(newStep);
        }

        internal Step Update(Step stepUpdate)
        {
            Step original = GetStepById(stepUpdate.Id);
            original.Position = stepUpdate.Position ?? original.Position;
            original.Body = stepUpdate.Body ?? original.Body;

            return _stepsRepo.Update(original);
        }
        internal string Delete(int id)
        {
            Step step = (Step)GetStepById(id);
            {
                _stepsRepo.Delete(id);
                return $"Step {step.Position} has been deleted.";
            }
        }

    }
}