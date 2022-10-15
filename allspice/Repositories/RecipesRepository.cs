using System;
using System.Collections.Generic;
using System.Linq;
using allspice.Data;
using allspice.Models;
namespace allspice.Repositories //Repositories - how to access your data
{
    public class RecipesRepository
    {    
        private readonly ApplicationDbContext _context;
       
        public RecipesRepository(ApplicationDbContext context)//Constructor
        {
            this._context = context;
           
        }
    
        internal List<Recipe> GetRecipes()
        {
            return _context.Recipes.ToList();
        }


        internal Recipe GetRecipeById(int id)
        {
            Recipe recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
            return recipe;
        }

        internal Recipe CreateRecipe(Recipe newRecipe)
        {
            _context.Recipes.Add(newRecipe);
            _context.SaveChanges();
            return newRecipe;
        }

        internal void Delete(int id)
        {
            Recipe recipe = GetRecipeById(id);
            if(recipe != null) {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
            else {
                throw new Exception("Recipe not found");
            }
        }
       
    }
}