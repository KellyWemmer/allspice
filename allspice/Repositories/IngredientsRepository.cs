using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        internal Ingredient GetIngredientById(int id)
        {
            string sql = @"
            SELECT
                i.*
                FROM ingredient i
                WHERE i.Id = @id;
            ";
            Ingredient ingredient = _db.Query<Ingredient>(sql, new {id}).FirstOrDefault();
            return ingredient;
        }

        internal Ingredient Create(Ingredient newIngredient)
        {
            string sql = @"
            INSERT INTO ingredient
            (name, quantity, recipeId)
            VALUES
            (@name, @quantity, @recipeId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newIngredient);
            newIngredient.Id = id;
            return newIngredient;
        }

        internal void Delete(int id)
        {
            string sql = @"
                DELETE FROM ingredient WHERE id=@id;
            ";
            _db.Execute(sql, new {id});
        }
    }
}