using System;
using System.Collections.Generic;
using System.Linq;
using allspice.Data;
using allspice.Models;
using Microsoft.EntityFrameworkCore;

namespace allspice.Repositories
{
    public class AccountsRepository
    {        
        private readonly ApplicationDbContext _context;

        public AccountsRepository(ApplicationDbContext context)
        {
        
            this._context = context;
        }

        internal Account GetByEmail(string userEmail)
        {

            Account account = _context.Accounts.FirstOrDefault(a => a.Email == userEmail);
            return account;
        }

        internal Account GetById(string id)
        {
            
            Account account = _context.Accounts.FirstOrDefault(a => a.Id == id);
            return account;
        }

        internal Account Create(Account newAccount)
        {
            
            //Pass in new account, save it, newAccount will have Id set
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            return newAccount;
        }

        internal Account Edit(Account update)
        {

            //Updates accountInDb because it's already cached
            Account accountInDb = GetById(update.Id);
            if(accountInDb != null) {
                //only want to update these columns
                accountInDb.Name = update.Name;
                accountInDb.Picture = update.Picture;
                _context.Accounts.Update(accountInDb);
                _context.SaveChanges();
            }
            else {
                throw new Exception("account not found");
            }
            return accountInDb;
        }


        internal List<Recipe> GetRecipesByUser(string userId)
        {
            List<Recipe> userRecipes = _context.Recipes.Where(r => r.CreatorId == userId).ToList();
            return userRecipes;
        }
        internal List<Recipe> GetFavoritesByUser(string userId)
        {
            List<Recipe> recipes = _context.Accounts // Want a list of favorited recipes
                .Include("Favorites") //join favorites table
                .Include("Favorites.Recipe") //join recipe object from favorites table
                .FirstOrDefault(x => x.Id == userId && (x.Favorites != null && x.Favorites.Count > 0)) //where account id = userId and favorites are not null and greater than 0
                .Favorites
                .Select(x => x.Recipe)//select the favorited recipes and form list
                .ToList();

            return recipes;
        }
    }
}
