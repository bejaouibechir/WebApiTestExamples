# Tester la présence d'un cookie

## Ajout de Middleware ASP.NET Core pour vérifier la présence du cookie

Nous allons maintenant créer un middleware dans ASP.NET Core pour vérifier la présence de ce cookie.

### Créer le Middleware:

Créez un middleware personnalisé pour vérifier la présence du cookie.

``` csharp
namespace WebAppCookies
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class CookieValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("key", out var cookieValue))
            {
                if (cookieValue == "value")
                {
                    // Cookie et valeur valides, continuer la requête
                    await _next(context);
                    return;
                }
            }

            // Cookie invalide, retourner une réponse 400 Bad Request
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Cookie 'my-cookie' with value 'my-cookie-value' is required.");
        }
    }

    // Extension méthode pour ajouter le middleware à la pipeline
    public static class CookieValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCookieValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CookieValidationMiddleware>();
        }
    }

}

```
### Configurer le Middleware dans l'application ASP.NET Core

``` csharp
 var builder = WebApplication.CreateBuilder(args);

 // Add services to the container.

 builder.Services.AddControllers();

 var app = builder.Build();

 // Configure the HTTP request pipeline.

 app.UseHttpsRedirection();

 app.UseAuthorization();

 app.UseCookieValidation();

 app.MapControllers();

 app.Run();

```
# Exemple de test dans Postman

- **URL:** URL de votre application ASP.NET Core locale ou déployée.
- **Méthode:** GET, POST, ou toute autre méthode que votre middleware doit intercepter.
- **Cookies:** Assurez-vous que le cookie my-cookie avec la valeur my-cookie-value est configuré.
  
       


 
