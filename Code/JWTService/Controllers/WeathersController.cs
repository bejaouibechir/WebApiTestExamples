using JWTService.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeathersController : ControllerBase
    {
        private readonly IContext _context;

        public WeathersController(IContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Weather> Get()
        {
            var cookie = new CookieOptions
            {
                // Sp�cifie le domaine de la cookie
                Domain = "https://localhost:7187",
                // Sp�cifie le chemin de la cookie (optionnel)
                Path = "/",
                // D�finit si la cookie est accessible uniquement via HTTP (false par d�faut)
                HttpOnly = false,
                // D�finit si la cookie est s�curis�e (false par d�faut)
                Secure = false,
                // D�finit si la cookie est accessible uniquement via HTTPS (false par d�faut)
                SameSite = SameSiteMode.None,
                // Dur�e de vie de la cookie (optionnel)
                Expires = DateTimeOffset.UtcNow.AddDays(1)
            };
            // Ajouter la cookie � la r�ponse HTTP
            Response.Cookies.Append("MonCookie", "ValeurDuCookie", cookie);

            return _context.Weathers;
        }
        [HttpGet("{id}")]
        public Weather Get(int id)
        {
            var current = _context.Weathers.Where(e => e.Id == id).FirstOrDefault();
            return current;
        }

        [HttpPost]
        public void Add([FromBody] Weather Weather)
        {
            _context.Add(Weather);
        }

        [HttpPut]
        public void Update(int id, [FromBody] Weather Weather)
        {
            var current = Get(id);
            current = Weather;

        }

        [HttpDelete]
        public void Remove([FromBody] Weather Weather)
        {
            _context.Remove(Weather);
        }

    }
}
