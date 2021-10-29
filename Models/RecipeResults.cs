namespace DPS_926___App_2.Models
{
    public class RecipeResults /// : RecipeResult
    {
        public RecipeResult[] results { get; set; }
        public int offset { get; set; }
        public int number { get; set; }
        public int totalResults { get; set; }
    }
}