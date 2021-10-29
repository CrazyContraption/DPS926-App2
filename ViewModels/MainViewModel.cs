using System;
using System.Windows.Input;
using DPS_926___App_2.Models;
using DPS_926___App_2.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DPS_926___App_2.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }
        public ICommand TestCommand { get; }
        public ICommand SearchBar_SearchButtonPressed { get; }
        public ICommand SearchResults_SelectionChanged { get; }

        public MainViewModel()
        {
            Title = "Recipe Browser";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://spoonacular.com/food-api"));
            TestCommand = new Command(async () => await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?{nameof(RecipeResult.ID)}=633194", true));
            SearchBar_SearchButtonPressed = new Command<string>((string searchTerm) => DoSearch(searchTerm));
            SearchResults_SelectionChanged = new Command<SearchResult>((SearchResult result) => DoSearch(result.Title));
        }

        private async void DoSearch(string term)
            => await Shell.Current.GoToAsync($"{nameof(RecipesPage)}?{nameof(RecipeResult.Title)}={term}", true);
    }
}