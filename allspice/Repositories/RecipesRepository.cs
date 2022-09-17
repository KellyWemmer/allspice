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

        public RecipesRepository(IDbConnection db)
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
        
    }
}