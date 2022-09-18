using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipesRepo;

        public RecipesService(RecipesRepository recipesRepo)
        {
            _recipesRepo = recipesRepo;
        }
        internal List<Recipe> GetRecipes()
        {
            return _recipesRepo.GetRecipes();
        }

        internal Recipe GetRecipeById(int id)
        {
           Recipe recipe = _recipesRepo.GetRecipeById(id);
           return recipe;
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _recipesRepo.CreateRecipe(newRecipe);
        }
    }
}