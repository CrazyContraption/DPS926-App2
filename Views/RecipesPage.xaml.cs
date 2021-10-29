using Xamarin.Forms;

namespace DPS_926___App_2.Views
{
    public partial class RecipesPage : ContentPage
    {
        readonly ViewModels.RecipesViewModel ViewModel;

        public RecipesPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ViewModels.RecipesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
            RecipesRefresh.IsEnabled = false;
        }
    }
}