using Microsoft.AspNetCore.Mvc;
using КурсачAPI.Clients;
using КурсачAPI.Models;

namespace КурсачAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CocktailsController : ControllerBase
    {
        private readonly ILogger<CocktailsController> Logger;
        public CocktailsController(ILogger<CocktailsController> logger) 
        { 
            Logger = logger;
        }
        [HttpGet(Name ="Coctails_by_name")]
        public Cocktail cocktail_by_name(string drink)
        {
            Database db = new Database();
            Client client = new Client();
            db.InsertCocktailAsync(client.GetCocktailsByNameAsync(drink).Result, drink);
            return client.GetCocktailsByNameAsync(drink).Result;
        }

        [HttpGet(Name = "Cocktails_by_ingredient")]
        public Cocktail cocktail_by_ingrediente(string ingrediente)
        {
            Database db = new Database();
            Client client = new Client();
            db.InsertCocktailAsync(client.GetCocktailsByIngredienteAsync(ingrediente).Result, ingrediente);
            return client.GetCocktailsByIngredienteAsync(ingrediente).Result;
        }

        [HttpGet(Name = "Coctail_random")]
        public Cocktail cocktail_random()
        {
            Client client = new Client();
            return client.GetCocktailRandomAsync().Result;
        }
    }
}
