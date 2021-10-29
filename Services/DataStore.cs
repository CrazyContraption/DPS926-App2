using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using DPS_926___App_2.Models;

namespace DPS_926___App_2.Services
{
    public class DataStore
    {
        readonly SQLiteAsyncConnection database;

        public DataStore(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<SavedRecipe>().Wait();
        }

        public Task<List<SavedRecipe>> LoadRecipesAsync()
        {
            return database.Table<SavedRecipe>().ToListAsync();
        }

        public Task<SavedRecipe> LoadRecipeAsync(int id)
        {
            return database.Table<SavedRecipe>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(SavedRecipe recipe)
        {
            if (recipe.ID != 0)
                return database.UpdateAsync(recipe);
            else
                return database.InsertAsync(recipe);
        }

        public Task<int> RemoveRecipeAsync(SavedRecipe recipe)
        {
            return database.DeleteAsync(recipe);
        }
    }
}