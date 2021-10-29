using SQLite;

namespace DPS_926___App_2.Models
{
    public class SavedRecipe : Recipe
    {
        public SavedRecipe() { }

        public SavedRecipe(Recipe child)
        {
            ID = 0;
            Title = child.Title;
            Image = child.Image;
            ImageType = child.ImageType;
            Vegitarian = child.Vegitarian;
            Vegan = child.Vegan;
            GlutenFree = child.GlutenFree;
            DairyFree = child.DairyFree;
            VeryPopular = child.VeryPopular;
            Sustainable = child.Sustainable;
            WeightWatcherPoints = child.WeightWatcherPoints;
            LowFodmap = child.LowFodmap;
            Likes = child.Likes;
            SpoonScore = child.SpoonScore;
            HealthScore = child.HealthScore;
            CreditsText = child.CreditsText;
            License = child.License;
            SourceName = child.SourceName;
            PricePerServing = child.PricePerServing;
            ReadyInMinutes = child.ReadyInMinutes;
            Servings = child.Servings;
            SourceUrl = child.SourceUrl;
            Summary = child.Summary;
            Instructions = child.Instructions;
            Notes = "";
        }

        [PrimaryKey, AutoIncrement]
        public new int ID { get; set; }
        public string Notes { get; set; }
    }
}