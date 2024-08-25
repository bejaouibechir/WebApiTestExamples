#  Authentification avec clé API 

## Création du serveur web api 

Créez une application Web API 

***Implémentation du middleware ApiKeyMiddleware:***

Votre middleware ***ApiKeyMiddleware*** doit vérifier si la clé API fournie dans l'en-tête de la requête correspond à celle configurée dans ***appsettings.json***. Voici à quoi pourrait ressembler votre middleware:

``` CSharp
namespace WebApiKey
{
    // Fichier ApiKeyMiddleware.cs

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

     public class ApiKeyMiddleware
 {
     private readonly RequestDelegate _next;
     private readonly ILogger<ApiKeyMiddleware> _logger;
     private readonly IConfiguration _config;
     private const string APIKEYNAME = "X-API-KEY"; // Nom de l'en-tête API KEY
     private const string APISECRET = "X-API-SECRET"; //Nom de l'entête APP SECRET 

 public ApiKeyMiddleware(RequestDelegate next, ILogger<ApiKeyMiddleware> logger, IConfiguration config)
     {
         _next = next;
         _logger = logger;
         _config = config;
     }

     public async Task Invoke(HttpContext context)
     {
         if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
         {
             context.Response.StatusCode = 401; // Unauthorized
             await context.Response.WriteAsync("API Key was not provided.");
             return;
         }

         if (!context.Request.Headers.TryGetValue(APISECRET, out var extractedAppSecret))
         {
             context.Response.StatusCode = 401; // Unauthorized
             await context.Response.WriteAsync("API SECRET not provided.");
             return;
         }

         var apiKey = _config.GetValue<string>("ApiConfiguration:ApiKey"); // Récupération de la clé API depuis la configuration
         var appsecret = _config.GetValue<string>("ApiConfiguration:AppSecret"); //Recuperation de Application Secret

         if (!apiKey.Equals(extractedApiKey) || !appsecret.Equals(extractedAppSecret))
         {
             context.Response.StatusCode = 401; // Unauthorized
             await context.Response.WriteAsync("Client non authorisé.");
             return;
         }

         await _next(context);
     }
 }
}

```


***Ajouter le middleware pour la vérification de la clé API***

Vous devez ajouter votre middleware ***ApiKeyMiddleware*** pour vérifier la clé API avant que la requête n'atteigne les contrôleurs. Voici comment vous pouvez modifier votre ***Program.cs*** :

```CSharp 

using Microsoft.AspNetCore.Authorization;

namespace WebApiKey
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           

            // Add services to the container.

            builder.Services.AddControllers();
            

            var app = builder.Build();


            app.UseMiddleware<ApiKeyMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

```
*** Configuration de appsettings.json ***
Assurez-vous que votre fichier ***appsettings.json*** est correctement configuré avec la clé API :

```json 
// appsettings.json

{
  "ApiConfiguration": {
    "ApiKey": "1234567890abcdef",
    "AppSecret": "mMzvY15g2pMdxVsvTpyCY5LdSAcPSTDKvCS/M09qUTnij2YfXvrX7virtL66FhSZ"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

***Ajout du contrôleur de test***:

```csharp 
using Microsoft.AspNetCore.Mvc;

namespace WebApiKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello, authenticated user!" });
        }
    }
}
```


***Points importants à vérifier :***
- Assurez-vous que ***appsettings.json*** est bien configuré et que le chemin d'accès est correctement spécifié dans Program.cs.
- Le middleware ***ApiKeyMiddleware*** doit être ajouté avant ***app.MapControllers()*** pour que chaque requête passe par la vérification de la clé API.
- Redémarrez votre application après avoir apporté ces modifications pour vous assurer que les configurations sont correctement chargées.

## Le test avec Postman 

Faites le test avec Postman

![L'interface Postman](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibaechir_api_key/1.png)


