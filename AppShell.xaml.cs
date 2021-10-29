using DPS_926___App_2.Views;
using Xamarin.Forms;

namespace DPS_926___App_2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipesPage), typeof(RecipesPage));
            Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
        }
    }
}
