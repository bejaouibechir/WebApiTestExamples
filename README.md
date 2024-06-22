# Tester la présence d'un cookie

# Les Managed cookies 

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
### Exemple de test dans Postman

- **URL:** URL de votre application ASP.NET Core locale ou déployée.
- **Méthode:** GET, POST, ou toute autre méthode que votre middleware doit intercepter.
- **Cookies:** Assurez-vous que le cookie my-cookie avec la valeur my-cookie-value est configuré.

![figure 1](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-cookie/2.png)  
![figure 2](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-cookie/1.png)  
       

### Vérification côté postman 

- Allez à l'onglet ***Scripts*** de votre requête.
- Ajoutez le script suivant dans la zone ***préscript*** pour vérifier la présence et la valeur du cookie


![figure 3](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-cookie/3.png)  

***Script de Pré-requête:***

```javascript
// Script de pré-requête pour vérifier la présence et la valeur d'un cookie

// Afficher un message dans la console avant l'envoi de la requête
console.log("Vérification du cookie avant l'envoi de la requête.");

// Accéder aux cookies de la requête
const cookieValue = pm.cookies.get('key');

if (!cookieValue) {
    console.log("Le cookie 'key' est manquant.");
} else if (cookieValue !== 'value') {
    console.log("Le cookie 'key' a une valeur incorrecte : " + cookieValue);
} else {
    console.log("Le cookie 'key' est présent avec la bonne valeur.");
}

```
***Script de Test:***

``` javascript
// Script de test pour vérifier la présence et la valeur d'un cookie dans la réponse

// Afficher un message dans la console après la réception de la réponse
console.log("Vérification du cookie après la réception de la réponse.");

// Récupérer tous les cookies de la réponse
const cookies = pm.cookies;

// Vérifier si le cookie 'my-cookie' est présent
pm.test("Presence of 'my-cookie'", function () {
    const isCookiePresent = cookies.has('key');
    console.log("Présence du cookie 'key' : " + isCookiePresent);
    pm.expect(isCookiePresent).to.be.true;
});

// Vérifier la valeur du cookie 'key'
pm.test("Value of 'my-cookie'", function () {
    if (cookies.has('key')) {
        const cookieValue = cookies.get('key');
        console.log("Valeur du cookie 'key' : " + cookieValue);
        pm.expect(cookieValue).to.eql('value');
    } else {
        console.log("Le cookie 'key' n'est pas présent.");
        pm.fail("Le cookie 'key' est manquant.");
    }
});

```

# Les sync cookies 

### Étapes pour installer Postman Interceptor
#### Installer l'extension Postman Interceptor dans Chrome
- Ouvrez Google Chrome.
- Allez sur le Chrome Web Store.
- Recherchez "Postman Interceptor".
- Cliquez sur "Ajouter à Chrome" pour installer l'extension.
- Confirmez l'ajout de l'extension en cliquant sur "Ajouter l'extension".

Voici le lien direct vers l'extension dans le Chrome Web Store : Postman Interceptor

#### Configurer Postman Interceptor
Activez Postman Interceptor :

Allez dans ***View*** > ***Show Postman Console*** ou utilisez le raccourci ***Cmd + Alt + C (Mac)*** ou ***Ctrl + Alt + C (Windows/Linux)*** pour ouvrir la console Postman.
Ensuite, allez dans ***File*** > ***Settings (ou cliquez sur l'icône d'engrenage)*** pour ouvrir les paramètres de Postman.
Dans l'onglet Settings, trouvez l'option Interceptor et activez-la.

***Connectez Postman Interceptor :***

Dans Postman, allez dans la barre de menu et cliquez sur l'icône Interceptor (un bouclier avec une flèche).
Cliquez sur ***Connect***.

Configurer la synchronisation des cookies :

Une fois connecté, vous pouvez configurer Postman pour capturer les cookies depuis votre navigateur Chrome.

- Allez dans l'onglet Cookies dans votre requête Postman et activez Sync Cookies si ce n'est pas déjà fait.
Utilisation de Postman Interceptor
Capturer les cookies de votre navigateur

- Ouvrez l'application web dans Google Chrome où les cookies sont définis (par exemple, après vous être connecté à un site).
- Assurez-vous que l'extension Postman Interceptor est active (vérifiez que l'icône de l'extension dans la barre d'outils Chrome est active).
Postman capturera automatiquement les cookies de votre navigateur et les synchronisera avec vos requêtes.
Envoyer des requêtes avec les cookies capturés

- Créez ou sélectionnez une requête dans Postman.
- Vérifiez les cookies synchronisés en cliquant sur l'onglet Cookies dans votre requête.
- Envoyez la requête comme d'habitude. Les cookies capturés seront inclus automatiquement dans la requête.

***Résumé***

- Installez Postman Interceptor depuis le Chrome Web Store.
- Activez et connectez Postman Interceptor dans Postman.
- Utilisez Postman Interceptor pour capturer et synchroniser les cookies depuis votre navigateur Chrome avec vos requêtes dans Postman.
  
En suivant ces étapes, vous pourrez facilement installer et utiliser Postman Interceptor pour gérer les cookies et tester vos API de manière plus efficace.


 
