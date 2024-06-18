# Importer la Collection dans Postman

- ***Ouvrir Postman.***
- ***Cliquer sur "Import"*** dans le coin supérieur gauche (définition collection)[].
- ***Sélectionner "Raw Text"*** et coller le JSON fourni.
- ***Cliquer sur "Continue"***, puis sur "Import".

# Ajouter des Tests Unitaires avec JavaScript "JTest"

Pour chaque requête dans votre collection, vous pouvez ajouter des tests en JavaScript dans l'onglet "Tests". Voici un exemple pour chaque requête.
Dans l'onglet ***"Scripts"*** de cette requête, ajoutez le script suivant dans la zone ***"Post response"*** :

### 1. Get task by id=1

![Zone Scripts]()

```javascript
// Test pour vérifier que le code de statut est 200
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

// Test pour vérifier la structure de la réponse
pm.test("Response has expected keys", function () {
    const jsonData = pm.response.json();
    pm.expect(jsonData).to.be.an('object');
    pm.expect(jsonData).to.have.property('id');
    pm.expect(jsonData).to.have.property('title');
    pm.expect(jsonData).to.have.property('completed');
});

// Test pour vérifier que le header `Content-Type` est présent
pm.test("Content-Type header is present", function () {
    pm.response.to.have.header("Content-Type");
});

```
### 2. Post data

Dans l'onglet "Tests" de cette requête, ajoutez le script suivant :
```javascript
// Test pour vérifier que le code de statut est 200 ou 201
pm.test("Successful POST request", function () {
    pm.expect(pm.response.code).to.be.oneOf([200, 201]);
});

// Test pour vérifier que le corps de la réponse contient l'ID créé
pm.test("Response contains new task ID", function () {
    const jsonData = pm.response.json();
    pm.expect(jsonData).to.be.an('object');
    pm.expect(jsonData).to.have.property('id');
});

// Test pour vérifier que le header `Content-Type` est présent
pm.test("Content-Type header is present", function () {
    pm.response.to.have.header("Content-Type");
});

```
### 3. Update data
Dans l'onglet "Tests" de cette requête, ajoutez le script suivant :

``` Javascript
// Test pour vérifier que le code de statut est 200, 201 ou 204
pm.test("Successful PUT request", function () {
    pm.expect(pm.response.code).to.be.oneOf([200, 201, 204]);
});

// Test pour vérifier que le corps de la réponse contient les données mises à jour
pm.test("Response contains updated task data", function () {
    const jsonData = pm.response.json();
    pm.expect(jsonData).to.be.an('object');
    pm.expect(jsonData).to.have.property('completed', true);
});

// Test pour vérifier que le header `Content-Type` est présent
pm.test("Content-Type header is present", function () {
    pm.response.to.have.header("Content-Type");
});

```
### 4. Delete data
``` javascript
Dans l'onglet "Tests" de cette requête, ajoutez le script suivant :
// Test pour vérifier que le code de statut est 200, 202 ou 204
pm.test("Successful DELETE request", function () {
    pm.expect(pm.response.code).to.be.oneOf([200, 202, 204]);
});

// Test pour vérifier que le corps de la réponse est vide
pm.test("Response body is empty", function () {
    pm.expect(pm.response.text()).to.be.empty;
});

// Test pour vérifier que le header `Content-Type` est présent
pm.test("Content-Type header is present", function () {
    pm.response.to.have.header("Content-Type");
});
```
### 5. Get all tasks
Dans l'onglet "Tests" de cette requête, ajoutez le script suivant :

``` javascript
// Test pour vérifier que le code de statut est 200
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});

// Test pour vérifier la structure de la réponse
pm.test("Response has expected keys", function () {
    const jsonData = pm.response.json();
    pm.expect(jsonData).to.be.an('array');
    if (jsonData.length > 0) {
        pm.expect(jsonData[0]).to.have.property('id');
        pm.expect(jsonData[0]).to.have.property('title');
        pm.expect(jsonData[0]).to.have.property('completed');
    }
});

// Test pour vérifier que le header `Content-Type` est présent
pm.test("Content-Type header is present", function () {
    pm.response.to.have.header("Content-Type");
});

```

### 6. La présence d'un header 

Supposons que vous souhaitiez vérifier la présence d'un header spécifique, par exemple, Authorization, dans une requête. Voici comment vous pouvez le faire dans Postman :

``` javacript
// Test pour vérifier la présence d'un header
pm.test("Request includes Authorization header", function () {
    pm.request.headers.has("Authorization");
});

```

## Exécution des tests dans Postman
Assurez-vous d'avoir configuré vos requêtes PUT, PATCH, DELETE dans votre collection Postman.
Ajoutez les tests correspondants dans l'onglet "Tests" pour chaque requête, comme indiqué ci-dessus.
Lancez l'exécution de votre collection à l'aide de la fonctionnalité "Runner" de Postman pour vérifier que tous les tests passent avec succès.
## Conclusion
En suivant ces exemples, vos étudiants seront en mesure d'écrire et de tester efficacement les opérations CRUD sur l'API jsonplaceholder.typicode.com/users à l'aide de Postman. Assurez-vous de les guider à travers chaque étape pour une compréhension complète des tests et des résultats obtenus.





