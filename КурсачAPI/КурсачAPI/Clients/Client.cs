using System.Text.Json.Serialization;
using КурсачAPI.Models;
using Newtonsoft.Json;

namespace КурсачAPI.Clients
{
    public class Client
    {
        private HttpClient httpClient;
        private static string apikey;
        private static string address;
        public Client()
        {
            address = Constants.Address;
            apikey = Constants.Apikey;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(address);
        }
        public async Task<Cocktail> GetCocktailsByNameAsync(string drink)
        {
            var responce = await httpClient.GetAsync($"/api/json/v1/{apikey}/search.php?s={drink}");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Cocktail>(content);
            return result;
        }

        public async Task<Cocktail> GetCocktailsByIngredienteAsync(string ingrediente)
        {
            var responce = await httpClient.GetAsync($"/api/json/v1/{apikey}/filter.php?i={ingrediente}");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Cocktail>(content);
            return result;
        }

        public async Task<Cocktail> GetCocktailRandomAsync()
        {
            var responce = await httpClient.GetAsync($"/api/json/v1/{apikey}/random.php");
            responce.EnsureSuccessStatusCode();
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Cocktail>(content);
            return result;
        }

    }

}
