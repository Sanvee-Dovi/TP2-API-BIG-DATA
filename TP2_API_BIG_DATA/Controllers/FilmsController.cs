using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP2_API_BIG_DATA.Models;


namespace TP2_API_BIG_DATA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly DbContexts _dbContext;

        public FilmsController(DbContexts dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
        {
            var films = await _dbContext.Films.ToListAsync();
            return Ok(films);
        }

        [HttpPost]
        public async Task<IActionResult> AddFilm([FromBody] FilmRequest filmRequest)
        {
            try
            {
                DateTime dateTime = DateTime.UtcNow;
                DateTime utcDateTime = dateTime.ToUniversalTime();

                // Créez une nouvelle instance de film avec les données fournies.
                var newFilm = new Film
                {
                    Title = filmRequest.Name,
                    Description = filmRequest.Description,
                    ReleaseYear = 2005,
                    RentalDuration = 10,
                    RentalRate = 1,
                    LanguageId = 1,
                    LastUpdate = utcDateTime,
                    SpecialFeatures  = new List<string> { "Commentaries"}
                };

                // Ajoutez le nouveau film à la base de données.
                _dbContext.Films.Add(newFilm);
                await _dbContext.SaveChangesAsync();

                // Retournez une réponse réussie avec le film ajouté.
                return Ok(newFilm);
            }
            catch (Exception ex)
            {
                // Gérez les erreurs
                Console.WriteLine($"Erreur lors de l'ajout du film : {ex.Message}");
                return StatusCode(500, "Une erreur s'est produite lors de l'ajout du film.");
            }
        }

        [HttpGet("{filmID}")]
        public IActionResult GetFilm(int filmID)
        {
            try
            {
                // Récupérez le dernier film en fonction de l'ID fourni.
                var latestFilm = _dbContext.Films
                    .OrderByDescending(f => f.FilmId)
                    .FirstOrDefault(f => f.FilmId == filmID);

                if (latestFilm == null)
                {
                    // Retournez une réponse 404 si le film n'est pas trouvé.
                    return NotFound($"Film avec l'ID {filmID} non trouvé.");
                }

                // Retournez le dernier film.
                return Ok(latestFilm);
            }
            catch (Exception ex)
            {
                // Gérez les erreurs, loggez-les si nécessaire.
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
