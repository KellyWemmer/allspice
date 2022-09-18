using System.Collections.Generic;
using System.Data;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)//Banana word
        {
            string sql = @"
            SELECT 
                i.*
                FROM ingredient i
            WHERE i.RecipeId = @recipeId;
            ";
            List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new {recipeId}).AsList();
            return ingredients;            

        }

        internal Ingredient Create(Ingredient newIngredient)
        {
        }
    }
}