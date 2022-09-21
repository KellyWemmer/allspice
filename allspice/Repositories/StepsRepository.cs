using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        internal Step GetStepById(int id)
        {
            string sql = @"
            SELECT
                s.*
                FROM step s
                WHERE s.Id = @id;
            ";
            Step step = _db.Query<Step>(sql, new {id}).FirstOrDefault();
            return step;
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

        internal Step Create(Step newStep)
        {
            string sql = @"
            INSERT INTO step
            (position, body, recipeId)
            VALUES
            (@position, @body, @recipeId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newStep);
            newStep.Id = id;
            return newStep;
        }

        internal Step Update(Step original)
        {
            string sql = @"
                UPDATE step SET
                    position = @position,
                    body = @body,
                    recipeId = @recipeId
                WHERE id = @id
            ";
            int rowsAffected = _db.Execute(sql, original);
            if(rowsAffected == 0)
            {
                throw new System.Exception("Unable to edit step.");
            }
            return original;
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM step WHERE id=@id;
            ";
            _db.Execute(sql, new {id});
        }
    }
}