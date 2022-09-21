using System;
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
        internal Ingredient GetIngredientById(int id)
        {
            Ingredient ingredient = _ingredientsRepo.GetIngredientById(id);
            if(ingredient == null)
            {
                throw new Exception("There's no ingredient by that Id");
            }
            return ingredient;
        }
        
        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            return _ingredientsRepo.GetIngredientsByRecipeId(recipeId);
        }

        internal Ingredient Create(Ingredient newIngredient)
        {
            return _ingredientsRepo.Create(newIngredient);
        }

        internal Ingredient Update(Ingredient ingredientUpdate)
        {
            Ingredient original = GetIngredientById(ingredientUpdate.Id);
            original.Name = ingredientUpdate.Name ?? original.Name; 
            original.Quantity = ingredientUpdate.Quantity ?? original.Quantity;

            return _ingredientsRepo.Update(original);
        }
        internal string Delete(int id)
        {
            Ingredient ingredient = (Ingredient)GetIngredientById(id);
            {
                _ingredientsRepo.Delete(id);
                return $"The ingredient {ingredient.Name} has been deleted.";
            }
        }

    }
}