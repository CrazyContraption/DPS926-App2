using System;

namespace DPS_926___App_2.Models
{
    public class RecipeResult : SearchResult
    {
        public RecipeResult() { }

        public RecipeResult(Recipe recipe)
        {
            ID = recipe.ID;
            Image = recipe.Image;
            ImageType = recipe.ImageType;
            Title = recipe.Title;
        }

        public RecipeResult(SavedRecipe recipe)
        {
            ID = recipe.ID;
            Image = recipe.Image;
            ImageType = recipe.ImageType;
            Title = recipe.Title;
        }

        public string Image { get; set; }
    }
}