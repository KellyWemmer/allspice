using System.Collections.Generic;
using System.Data;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
    public class StepsRepository
    {
        private readonly IDbConnection _db;

        public StepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Step> GetStepsByRecipeId(int recipeId)
        {
           string sql = @"
           SELECT
                s.*
                FROM step s
            WHERE s.RecipeId = @recipeId;
           ";
           List<Step> steps = _db.Query<Step>(sql, new {recipeId}).AsList();
           return steps;
        }
    }
}