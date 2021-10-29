using System;
using System.Windows.Input;
using DPS_926___App_2.Models;
using DPS_926___App_2.Services;
using Xamarin.Forms;

namespace DPS_926___App_2.ViewModels
{
    [QueryProperty(nameof(RecipeID), nameof(RecipeResult.ID))]
    public class RecipeDetailViewModel : BaseViewModel
    {
        public ICommand SaveRecipe { get; }

        public RecipeDetailViewModel()
        {
            Recipe = new Recipe();
            SaveRecipe = new Command(async () => {
                try
                {
                    if (RecipeID > 0)
                    {
                        SavedRecipe newRecipe = new SavedRecipe(Recipe);
                        if (await App.Database.SaveRecipeAsync(newRecipe) <= 0)
                        {
                            await Application.Current.MainPage.DisplayAlert("Storage Error", "Failed to save recipe", "Oops");
                            IsBusy = false;
                            await Shell.Current.GoToAsync("..");
                        }
                        else if (await Application.Current.MainPage.DisplayAlert("Saved", $"Successfully saved \"{Recipe.Title}\"", "View", "Stay"))
                            await Shell.Current.GoToAsync($"{nameof(Views.RecipeDetailPage)}?{nameof(RecipeResult.ID)}={Math.Abs(newRecipe.ID) * -1}", true);
                    }
                    else
                    {
                        if (await App.Database.RemoveRecipeAsync(await App.Database.LoadRecipeAsync(Math.Abs(RecipeID))) <= 0)
                        {
                            await Application.Current.MainPage.DisplayAlert("Storage Error", "Failed to remove saved recipe", "Oops");
                            IsBusy = false;
                            await Shell.Current.GoToAsync("..");
                        }
                        else
                        {
                            IsBusy = false;
                            await Shell.Current.GoToAsync($"{nameof(Views.RecipesPage)}?{nameof(RecipeResult.Title)}=", true);
                        }
                    }
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Loading Error", $"Failed handling recipe with ID '{recipeID}'\n{e.Message}", "Oops");
                    IsBusy = false;
                    await Shell.Current.GoToAsync("..");
                }
            });
        }

        private string toolBarText;
        public string ToolBarText
        {
            get => toolBarText;
            set => _ = SetProperty(ref toolBarText, value);
        }

        private Recipe recipe;
        public Recipe Recipe
        {
            get => recipe;
            set => _ = SetProperty(ref recipe, value);
        }

        private int recipeID;
        public int RecipeID
        {
            get => recipeID;
            set
            {
                recipeID = value;
                LoadItemId(value);
            }
        }
        private async void LoadItemId(int recipeID)
        {
            try
            {
                if (recipeID <= 0)
                {
                    ToolBarText = "Delete";
                    Recipe = new Recipe(await App.Database.LoadRecipeAsync(Math.Abs(recipeID)));
                    IsBusy = false;
                }
                else
                {
                    ToolBarText = "Save";
                    Recipe = await WebClient.GetRecipeByID(recipeID);
                    IsBusy = false;
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Loading Error", $"Failed to {(recipeID <= 0 ? "load stored" : "retrieve remote")} recipe with ID '{Math.Abs(recipeID)}'\n{e.Message}", "Oops");
                IsBusy = false;
                await Shell.Current.GoToAsync("..");
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            OnPropertyChanged("IsBusy");
        }
    }
}
