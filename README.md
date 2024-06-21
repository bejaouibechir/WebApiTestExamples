# Middleware ASP.NET Core pour vérifier le header

Pour démontrer comment une application ASP.NET Core 8.0 peut intercepter une requête pour vérifier l'existence d'un header spécifique (nommé my-header avec la valeur my-header-value), voici un exemple complet qui inclut le middleware ASP.NET Core et un test Postman pour vérification.

Tout d'abord, nous allons créer un middleware personnalisé dans ASP.NET Core qui intercepte chaque requête entrante et vérifie la présence du header requis.

``` csharp
// Middleware pour vérifier l'existence du header
public class HeaderValidationMiddleware
{
    private readonly RequestDelegate _next;

    public HeaderValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Vérifier si le header requis est présent et a la bonne valeur
        if (context.Request.Headers.TryGetValue("my-header", out var headerValues))
        {
            if (headerValues.Contains("my-header-value"))
            {
                // Header et valeur valides, continuer la requête
                await _next(context);
                return;
            }
        }

        // Header invalide, retourner une réponse 400 Bad Request
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Header 'my-header' with value 'my-header-value' is required.");
    }
}

// Extension méthode pour ajouter le middleware à la pipeline
public static class HeaderValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseHeaderValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HeaderValidationMiddleware>();
    }
}

```
## Configuration de l'application ASP.NET Core

Dans ***Program.cs***, ajoutez le middleware à la pipeline de requête la zone des middleware ajouter
``` csharp
 app.UseHeaderValidation();
```


 ## Exemple de test avec Postman

 Utilisez Postman pour envoyer une requête avec le header requis pour vérifier que le middleware fonctionne correctement.

- URL: URL de votre application ASP.NET Core locale ou déployée.
- Méthode: POST, GET, ou toute autre méthode que votre middleware doit intercepter.
- Headers:
      - Key: my-header
      - Value: my-header-value

  Assurez-vous que la requête envoyée depuis Postman contient ce header avec la bonne valeur. Le middleware devrait laisser passer la requête si le header est correctement défini.

## Script de pré-requête dans Postman

Ajoutez le script de pré-requête suivant dans votre requête Postman :

```javascript 
// Vérifier la présence et la valeur du header 'my-header'
const headerValue = pm.request.headers.get('my-header');

if (!headerValue) {
    console.log("Header 'my-header' est nécessaire dans la requête.");
    throw new Error("Header 'my-header' est manquant.");
} else if (headerValue !== 'my-header-value') {
    console.log("Header 'my-header' doit avoir la valeur 'my-header-value'.");
    throw new Error("Header 'my-header' a une valeur incorrecte.");
} else {
    console.log("Header 'my-header' est présent avec la bonne valeur.");
}

```
![Définition des prèscript dans postman](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-header/1.png)


### Ajouter le header dans la requête Postman

Assurez-vous que votre requête Postman contient le header my-header avec la valeur my-header-value

- Key: my-header
- Value: my-header-value

### Exécution des tests
Lorsque vous exécutez votre requête Postman, le script de pré-requête vérifiera la présence et la valeur du header my-header avant d'envoyer la requête. Si le header est absent ou incorrect, une erreur sera générée et la requête ne sera pas envoyée. Si le header est correct, la requête sera envoyée, et les tests vérifieront la réponse pour s'assurer que le header attendu est présent et que le statut de la réponse est 200.

 
