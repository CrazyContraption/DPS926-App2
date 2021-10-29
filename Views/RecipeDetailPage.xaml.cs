using Xamarin.Forms;

namespace DPS_926___App_2.Views
{
    public partial class RecipeDetailPage : ContentPage
    {
        private readonly ViewModels.RecipeDetailViewModel ViewModel;

        public RecipeDetailPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ViewModels.RecipeDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}