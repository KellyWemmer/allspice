using System;
using System.Collections.Generic;
using System.Linq;
using allspice.Data;
using allspice.Models;

namespace allspice.Repositories
{
    public class IngredientsRepository
    {
        private readonly ApplicationDbContext _context;
        public IngredientsRepository(ApplicationDbContext context)
        {
            this._context = context;
            
        }
        internal Ingredient GetIngredientById(int id)
        {

            Ingredient ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            return ingredient;
        }
        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)//Banana word
        {
            
            //"Where" returns an IQueriable, which needs to be turned back into a list
            List<Ingredient> ingredients = _context.Ingredients.Where(i => i.RecipeId == recipeId).ToList();
            return ingredients;    

        }

        internal Ingredient Create(Ingredient newIngredient)
        {
            _context.Ingredients.Add(newIngredient);
            _context.SaveChanges();
            return newIngredient;
        }

        internal Ingredient Update(Ingredient original)
        {            
            Ingredient ingredientInDb = GetIngredientById(original.Id);
            if(ingredientInDb != null) {
                //only want to update these columns
                ingredientInDb.Name = original.Name;
                ingredientInDb.Quantity = original.Quantity;
                ingredientInDb.RecipeId = original.RecipeId;
                _context.Ingredients.Update(ingredientInDb);
                _context.SaveChanges();
            }
            else {
                throw new Exception("ingredient not found");
            }
            return ingredientInDb;
        }

        internal void Delete(int id)
        {            
            Ingredient ingredient = GetIngredientById(id);
            if(ingredient != null) {
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
            else {
                throw new Exception("ingredient not found");
            }
        }
    }
}