using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DPS_926___App_2.Models;
using DPS_926___App_2.Views;
using Xamarin.Forms;

namespace DPS_926___App_2.ViewModels
{
    [QueryProperty(nameof(RecipeTerm), nameof(RecipeResult.Title))]
    public class RecipesViewModel : BaseViewModel
    {
        public ObservableCollection<RecipeResult> Recipes { get; }
        public ICommand LoadItemsCommand { get; }
        public ICommand SearchResults_SelectionChanged { get; }

        public RecipesViewModel()
        {
            Title = "";
            Recipes = new ObservableCollection<RecipeResult>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SearchResults_SelectionChanged = new Command<SearchResult>(async (SearchResult result) =>
            {
                if ((recipeTerm ?? "") == "")
                    await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?{nameof(RecipeResult.ID)}={Math.Abs(result.ID) * -1}", true);
                else
                    await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?{nameof(RecipeResult.ID)}={result.ID}", true);
            });
        }

        private string recipeTerm;
        public string RecipeTerm
        {
            get => recipeTerm;
            set
            {
                recipeTerm = value;
                Title = $"{((recipeTerm ?? "") == "" ? "Saved" : "\"" + recipeTerm +"\"")} Recipies";
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                if (Recipes.Count > 0)
                {
                    IsBusy = false;
                    return;
                }
                IsBusy = true;

                if ((recipeTerm ?? "") != "")
                {
                    Recipes.Clear();
                    RecipeResults recipes = await Services.WebClient.GetRecipesByTerm(recipeTerm);

                    if (recipes.totalResults <= 0)
                    {
                        await Application.Current.MainPage.DisplayAlert("Opps!", "Sorry, we couldn't find any recipes for you.", "Ok");
                        await Shell.Current.GoToAsync("..");
                    }

                    foreach (RecipeResult recipe in recipes.results)
                        Recipes.Add(recipe);
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Unknown Error", $"An unknown error occured.\n{e.Message}", "Oops");
                IsBusy = false;
                await Shell.Current.GoToAsync("..");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void OnAppearing()
        {
            IsBusy = true;
            if ((recipeTerm ?? "") == "")
            {
                List<SavedRecipe> recipes = await App.Database.LoadRecipesAsync();

                if (recipes.Count <= 0)
                {
                    await Application.Current.MainPage.DisplayAlert("No Recipes", "You don't have any saved recipes, try adding some, and then coming back!", "Ok");
                    await Shell.Current.GoToAsync("//HomePage", true);
                }

                foreach (SavedRecipe recipe in recipes)
                    Recipes.Add(new RecipeResult(recipe));

                IsBusy = false;
            }
        }
    }
}