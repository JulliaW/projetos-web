using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using System.Text.Json;

namespace pokedex.Controllers
{
    public class PokemonController : Controller
    {
        public async Task<IActionResult> Index(int? pagina = 0)
        {
            const string apiUrl = "http://pokeapi.co/api/v2/pokemon";
            int limit = 200;
            var httpClient = new HttpClient();
            var resonse = await httpClient.GetAsync($"{apiUrl}?limit={limit}&offset={limit * pagina}");

            var content = await resonse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PokemonApiResponse>(content);

            int? i = limit * pagina;

            var pokemons = new List<Pokemon>();
            foreach(var p in result.Results)
            {
                i++;

                Pokemon pokemon = new();
                pokemon.Name = p.Name;
                pokemon.Url = $"https://assets.pokemon.com/assets/cms2/img/pokedex/detail/{((i < 1000) ? i?.ToString("#000") : i)}.png";
                
                pokemons.Add(pokemon);
            }

            return View(pokemons);
        }
    }
}
