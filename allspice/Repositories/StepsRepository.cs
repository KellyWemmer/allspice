using System;
using System.Collections.Generic;
using System.Linq;
using allspice.Data;
using allspice.Models;

namespace allspice.Repositories
{
    public class StepsRepository
    {
        private readonly ApplicationDbContext _context;
       
        public StepsRepository(ApplicationDbContext context)
        {
            this._context = context;
            
        }
        internal Step GetStepById(int id)
        {
            Step step = _context.Steps.FirstOrDefault(s => s.Id == id);
            return step;
        }
        internal List<Step> GetStepsByRecipeId(int recipeId)
        {
           List<Step> steps = _context.Steps.Where(s => s.RecipeId == recipeId).ToList();
            return steps;  
        }

        internal Step Create(Step newStep)
        {
            _context.Steps.Add(newStep);
            _context.SaveChanges();
            return newStep;
        }

        internal Step Update(Step original)
        {
            // string sql = @"
            //     UPDATE step SET
            //         position = @position,
            //         body = @body,
            //         recipeId = @recipeId
            //     WHERE id = @id
            // ";
            Step stepInDb = GetStepById(original.Id);
            if(stepInDb != null) {
                //only want to update these columns
                stepInDb.Position = original.Position;
                stepInDb.Body = original.Body;
                stepInDb.RecipeId = original.RecipeId;
                _context.Steps.Update(stepInDb);
                _context.SaveChanges();
            }
            else {
                throw new Exception("step not found");
            }
            return stepInDb;
        }

        internal void Delete(int id)
        {
            Step step = GetStepById(id);
            if(step != null) {
                _context.Steps.Remove(step);
                _context.SaveChanges();
            }
            else {
                throw new Exception("step not found");
            }
        }
    }
}