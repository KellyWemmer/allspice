using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;
namespace allspice.Repositories //Repositories - how to access your data
{
    public class RecipesRepository
    {    
        private readonly IDbConnection _db; //Represents an open connection to a data source

        public RecipesRepository(IDbConnection db)//Constructor
        {
            _db = db;
        }
    
        internal List<Recipe> GetRecipes()
        {
            string sql = @"
            SELECT * FROM recipe";//match table in SQL
            List<Recipe> recipes = _db.Query<Recipe>(sql).ToList();//Query Type Recipe
            return recipes;
        }


        internal Recipe GetRecipeById(int id)
        {
            string sql = @"
            SELECT * FROM recipe
            WHERE id = @id;
            ";
            Recipe recipe = _db.Query<Recipe>(sql, new { id}).FirstOrDefault();//Returns as single object instead of a list
            return recipe;
        }

        internal Recipe CreateRecipe(Recipe newRecipe)
        {
            string sql = @"
            INSERT INTO recipe
            (picture, title, subtitle, category, creatorId)
            Values
            (@picture, @title, @subtitle, @category, @creatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newRecipe);
            newRecipe.Id = id;
            return newRecipe;
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM recipe WHERE id=@id;
            ";
            _db.Execute(sql, new {id});
        }
       
    }
}