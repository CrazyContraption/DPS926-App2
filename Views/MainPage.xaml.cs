using Xamarin.Forms;

namespace DPS_926___App_2.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.MainViewModel();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar search = sender as SearchBar;
            if (search.Text.Length <= 0)
            {
                SearchResults.ItemsSource = null;
                SearchResults.IsVisible = false;
                infoBlock.IsVisible = true;
            }
            else
            {
                SearchResults.ItemsSource = await Services.WebClient.AutoCompleteRecipes(search.Text);
                infoBlock.IsVisible = false;
                SearchResults.IsVisible = true;
            }
        }
    }
}