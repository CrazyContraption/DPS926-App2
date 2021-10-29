namespace DPS_926___App_2.Models
{
    public class RecipeResults /// : RecipeResult
    {
        public RecipeResult[] Results { get; set; }
        public int Offset { get; set; }
        public int Number { get; set; }
        public int TotalResults { get; set; }
    }
}