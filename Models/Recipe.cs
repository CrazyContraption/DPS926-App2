namespace DPS_926___App_2.Models
{
    public class Recipe : RecipeResult
    {
        public Recipe() { }

        public Recipe(SavedRecipe recipe)
        {
            ID = recipe.ID;
            Title = recipe.Title;
            Image = recipe.Image;
            ImageType = recipe.ImageType;
            Vegitarian = recipe.Vegitarian;
            Vegan = recipe.Vegan;
            GlutenFree = recipe.GlutenFree;
            DairyFree = recipe.DairyFree;
            VeryPopular = recipe.VeryPopular;
            Sustainable = recipe.Sustainable;
            WeightWatcherPoints = recipe.WeightWatcherPoints;
            LowFodmap = recipe.LowFodmap;
            Likes = recipe.Likes;
            SpoonScore = recipe.SpoonScore;
            HealthScore = recipe.HealthScore;
            CreditsText = recipe.CreditsText;
            License = recipe.License;
            SourceName = recipe.SourceName;
            PricePerServing = recipe.PricePerServing;
            ReadyInMinutes = recipe.ReadyInMinutes;
            Servings = recipe.Servings;
            SourceUrl = recipe.SourceUrl;
            Summary = recipe.Summary;
            Instructions = recipe.Instructions;
        }

        public bool Vegitarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }
        public bool DairyFree { get; set; }
        public bool VeryPopular { get; set; }
        public bool Sustainable { get; set; }
        public int WeightWatcherPoints { get; set; }
        public bool LowFodmap { get; set; }
        public int Likes { get; set; }
        public double SpoonScore { get; set; }
        public double HealthScore { get; set; }
        public string CreditsText { get; set; }
        public string License { get; set; }
        public string SourceName { get; set; }
        public double PricePerServing { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string SourceUrl { get; set; }
        public string Summary { get; set; }
        public string Instructions { get; set; }
    }
}