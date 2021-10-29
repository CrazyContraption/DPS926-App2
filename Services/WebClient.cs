using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DPS_926___App_2.Models;

namespace DPS_926___App_2.Services
{
    public class WebClient
    {
        static readonly HttpClient client = new HttpClient();

        private static string SpoonacularKey = "2fa953be9058495c8061f04d871144fa";
        
        public WebClient()
        {
            InitializeMe();
        }

        private static void InitializeMe()
        {
            if (client.BaseAddress is null)
            {
                client.BaseAddress = new Uri("https://api.spoonacular.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        private static string GetQueryString(string[] queries)
        {

            string parameters = "?apiKey=" + SpoonacularKey;
            if (queries.Length <= 0)
                return parameters;
            foreach (var query in queries)
            {
                parameters += $"&{query}";
            }
            return parameters;
        }

        public static async Task<List<SearchResult>> AutoCompleteRecipes(string term)
        {
            InitializeMe();

            List<SearchResult> results = null;
            UriBuilder builder = new UriBuilder(client.BaseAddress
                + "recipes/autocomplete"
                + GetQueryString(new string[] { $"query={term}" }))
            {
                Scheme = Uri.UriSchemeHttps
            };
            HttpResponseMessage response = await client.GetAsync(builder.Uri);
            Console.WriteLine($"{builder.Uri}\nRETURNED {response.StatusCode}");
            if (response.StatusCode.ToString() == "PaymentRequired" && SpoonacularKey != "1febd37b3f8e478eab12e086f470071d")
            {
                SpoonacularKey = "1febd37b3f8e478eab12e086f470071d";
                response = await client.GetAsync(builder.Uri);
                Console.WriteLine($"{builder.Uri}\nRETURNED {response.StatusCode}");
            }

            if (response.IsSuccessStatusCode)
                results = await response.Content.ReadAsAsync<List<SearchResult>>();
            return results;
        }

        public static async Task<RecipeResults> GetRecipesByTerm(string term)
        {
            InitializeMe();

            RecipeResults results = null;
            UriBuilder builder = new UriBuilder(client.BaseAddress
                + "recipes/complexSearch"
                + GetQueryString(new string[] { $"query={term}", "sort=popularity"}))
            {
                Scheme = Uri.UriSchemeHttps
            };
            HttpResponseMessage response = await client.GetAsync(builder.Uri);
            Console.WriteLine($"{builder.Uri}\nRETURNED {response.StatusCode}");
            if (response.StatusCode.ToString() == "PaymentRequired" && SpoonacularKey != "1febd37b3f8e478eab12e086f470071d")
            {
                SpoonacularKey = "1febd37b3f8e478eab12e086f470071d";
                response = await client.GetAsync(builder.Uri);
                Console.WriteLine($"{builder.Uri}\nRETURNED {response.StatusCode}");
            }

            if (response.IsSuccessStatusCode)
                results = await response.Content.ReadAsAsync<RecipeResults>();
            return results;
        }

        public static async Task<Recipe> GetRecipeByID(int id, bool includeNutrition = true)
        {
            InitializeMe();

            Recipe results = null;
            UriBuilder builder = new UriBuilder(client.BaseAddress
                + $"recipes/{id}/information"
                + GetQueryString(new string[] { $"includeNutrition={includeNutrition}" }))
            {
                Scheme = Uri.UriSchemeHttps
            };
            HttpResponseMessage response = await client.GetAsync(builder.Uri);
            Console.WriteLine($"{builder.Uri}\nRETURNED {response.StatusCode}");
            if (response.StatusCode.ToString() == "PaymentRequired" && SpoonacularKey != "1febd37b3f8e478eab12e086f470071d")
            {
                SpoonacularKey = "1febd37b3f8e478eab12e086f470071d";
                response = await client.GetAsync(builder.Uri);
                Console.WriteLine($"{builder.Uri}\nRETURNED {response.StatusCode}");
            }

            if (response.IsSuccessStatusCode)
                results = await response.Content.ReadAsAsync<Recipe>();
            return results;
        }
    }
}