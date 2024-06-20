# Préparation du service 
Nous sommes supposé utiliser une application Web API net core 8.0

## Créer un nouveau projet Web API

**Ouvrir Visual Studio :** Lancez Visual Studio et créez un nouveau projet.

**Sélectionner le modèle :** Choisissez le modèle "ASP.NET Core Web Application".

**Configurer le projet :** Donnez un nom à votre projet, sélectionnez la version la plus récente de .NET Core (par exemple, .NET 8.0), et choisissez le modèle "API" dans les options de projet.

Copiez ce contenu dans le fichier **.csproj** du projet et compilez le

``` xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Authentication" Version="2.2.0" />
    <PackageReference Include="Microsoft.Extensions.Options" Version="8.0.2" />
  </ItemGroup>

</Project>

```
Cela ajoutera une référence à une dépendance nécessaire *Microsoft.AspNetCore.Authentication*

Ajouter une nouvelle classe au projet 

``` CSharp
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserService _userService;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IUserService userService)
        : base(options, logger, encoder, clock)
    {
        _userService = userService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

        bool isAuthenticated = false;
        string username = string.Empty;
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
            username = credentials[0];
            var password = credentials[1];
            isAuthenticated = await _userService.ValidateCredentialsAsync(username, password);
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }

        if (!isAuthenticated)
            return AuthenticateResult.Fail("Invalid Username or Password");

        var claims = new[] { new Claim(ClaimTypes.Name, username) };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}

```

Nous aurons besoin également à un service dont la définition est la suivante

***IUserService:***

``` CSharp 

public interface IUserService
{
    Task<bool> ValidateCredentialsAsync(string username, string password);
}

```

***UserService:***

``` CSharp 
  public class UserService : IUserService
  {
      private readonly Dictionary<string, string> _users = new()
  {
      { "user1", "password1" },
      { "user2", "password2" }
  };
  
      public Task<bool> ValidateCredentialsAsync(string username, string password)
      {
          return Task.FromResult(_users.Any(u => u.Key == username && u.Value == password));
      }
  }

```
La classe program.cs doit rassembler à ce code: 

```CSharp
using Microsoft.AspNetCore.Authentication;

namespace WebAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();


            builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("BasicAuth", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddAuthenticationSchemes("BasicAuthentication");
                });
            });

            builder.Services.AddSingleton<IUserService, UserService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

```
Pour le test il faut ajouter le contrôleur **TestController** dans le dossier **Controllers**

``` CSharp
using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "BasicAuth")]
        public IActionResult Get()
        {
            return Ok("You are authenticated");
        }
    }


```

## Exposer le service en public à l'aide de ngrock

- Créez un compte s'il vous n'avez pas de compte 
- Ouvrez une session  ngrok 
- Recuperez votre token de session et executez la commande suivante une fois authentifié ***ngrok config add-authtoken <clé de token>***
- Executez la commande ***ngrok http https://localhost:port***
- Recuperez le lien qui expose le service en public

## Tester le service
Choissiez le mode d'authentification Basic et entrez les paramètres d'accès et tester la requête

Changer le login ou le mot de passe et re testez

Dans la zone Headers de la requête essayez de cliquer sur l'oeuil pour voir en clair l'entête **Authorization**

Copiez le code de l'entête et décodez le au niveau de l'un des sites qui décodent les chaines à base64 









# Authentification Basic

**Nouvelle requête :** Créez une nouvelle requête en cliquant sur le bouton "Nouvelle requête" en haut à gauche de l'interface de Postman.
**Définir la méthode HTTP :** Choisissez la méthode HTTP que vous souhaitez tester (GET, POST, etc.) dans le menu déroulant à côté de l'URL.
**Entrer l'URL :** Entrez l'URL du service ou de l'API que vous souhaitez tester dans le champ d'URL.


## Configurer l'authentification Basic

**Ouvrir les paramètres d'authentification :** Cliquez sur l'onglet "Authorization" situé sous la barre d'URL dans l'interface de Postman.

**Sélectionner le type d'authentification :** Dans le menu déroulant "Type", sélectionnez "Basic Auth".

**Entrer les informations d'identification :** Remplissez les champs "Nom d'utilisateur" et "Mot de passe" avec les informations d'authentification requises par le service que vous testez, par exemple 
*user1* et *password1*.

## Envoyer la requête:

**Vérifier les paramètres :** Assurez-vous que tous les paramètres de votre requête sont corrects, y compris l'URL, la méthode HTTP et les paramètres d'authentification.

**Envoyer la requête :** Cliquez sur le bouton "Send" (Envoyer) pour envoyer la requête à l'URL spécifiée avec les informations d'authentification Basic.

## Vérifier la réponse

**Observer la réponse :** Postman affichera la réponse du serveur dans la fenêtre inférieure de l'interface. Assurez-vous de vérifier que la réponse correspond à ce que vous attendiez.

**Gérer les erreurs :** Si la requête échoue, vérifiez les détails de l'erreur dans la fenêtre de réponse de Postman et ajustez les paramètres si nécessaire.
