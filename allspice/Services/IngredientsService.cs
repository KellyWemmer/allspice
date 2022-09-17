using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepo;

        public IngredientsService(IngredientsRepository ingredientsRepo)
        {
            _ingredientsRepo = ingredientsRepo;
        } 
        
        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            return _ingredientsRepo.GetIngredientsByRecipeId(recipeId);
        }
    }
}