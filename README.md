# Utilisation des Pre-scripts dans Postman

Les pre-scripts dans Postman sont des scripts JavaScript qui s'exécutent avant l'envoi de la requête. Ils sont utilisés pour configurer des variables, manipuler des données ou authentifier les requêtes.

- ***Ouvrir Postman.***
- ***Cliquer sur "Import"*** dans le coin supérieur gauche [définition collection](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-jtest-post-response/JsonPlaceHolder%20tasks.postman_collection.json).
- ***Sélectionner "Raw Text"*** et coller le JSON fourni.
- ***Cliquer sur "Continue"***, puis sur "Import".

# Ajouter des Tests Unitaires avec JavaScript "JTest"

Pour chaque requête dans votre collection, vous pouvez ajouter des tests en JavaScript dans l'onglet "Tests". Voici un exemple pour chaque requête.
Dans l'onglet ***"Scripts"*** de cette requête, ajoutez le script suivant dans la zone ***"prè-scripts"*** :

![Zone Scripts](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-jtest-post-response/3.png)

## Objectifs du Tutoriel
- Ajouter des pre-scripts pour chaque requête.
- Expérimenter la modification des en-têtes et des corps de requête.
- Générer des valeurs dynamiques pour les requêtes.

### 1. Ajouter un Pre-script pour la requête Get task by id=1
***Description :*** Ajouter un pre-script pour générer dynamiquement un ID de tâche.

***Pre-script :***

```javascript 
// Générer un ID aléatoire entre 1 et 10
const taskId = Math.floor(Math.random() * 10) + 1;
pm.variables.set("taskId", taskId);
``` 

***Tests :***
```javascript 
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});
```

### 2. Ajouter un Pre-script pour la requête Post data
***Description :*** Ajouter un pre-script pour générer dynamiquement un titre de tâche.

***Pre-script :***

``` javascript
// Générer un titre de tâche aléatoire
const titles = ["Task 1", "Task 2", "Task 3", "Task 4"];
const randomTitle = titles[Math.floor(Math.random() * titles.length)];
pm.variables.set("taskTitle", randomTitle);
```
***Corps de la requête :***

``` json
{
    "userId": 9,
    "id": 201,
    "title": "{{taskTitle}}",
    "completed": false
}
```
### Tests :

``` javascript
pm.test("Successful POST request", function () {
    pm.expect(pm.response.code).to.be.oneOf([200, 201]);
});
```

### 3. Ajouter un Pre-script pour la requête Update data
***Description :*** Ajouter un pre-script pour modifier dynamiquement l'état de complétion d'une tâche.

***Pre-script :***

```javascript

// Alterner l'état de complétion
const completed = Math.random() < 0.5;
pm.variables.set("completed", completed);

```
***Corps de la requête :***

``` json
{
    "userId": 9,
    "id": 201,
    "title": "ipsam aperiam voluptates qui",
    "completed": {{completed}}
}
```
***Tests :***

``` javascript

pm.test("Successful PUT request", function () {
    pm.expect(pm.response.code).to.be.oneOf([200, 201, 204]);
});
```

### 4. Ajouter un Pre-script pour la requête Delete data
***Description :*** Ajouter un pre-script pour vérifier qu'un ID est défini avant de supprimer une tâche.

***Pre-script :***

``` javascript

// Vérifier qu'un ID est défini
const taskId = pm.variables.get("taskId");
if (!taskId) {
    throw new Error("Task ID is not defined");
}
```

***Tests :***

``` javascript

pm.test("Successful DELETE request", function () {
    pm.expect(pm.response.code).to.be.oneOf([200, 202, 204]);
});
```

### 5. Ajouter un Pre-script pour la requête Get all tasks
***Description :*** Ajouter un pre-script pour définir un en-tête de requête personnalisé.

***Pre-script :***

``` javascript

// Définir un en-tête de requête personnalisé
pm.request.headers.add({
    key: "X-Custom-Header",
    value: "PostmanPreScriptTest"
});
```
***Tests:***

``` javascript

pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});
```


## Conclusion
Ce tutoriel vous a guidé à travers l'ajout de pre-scripts pour chaque requête dans une collection Postman. En utilisant des pre-scripts, vous pouvez :

- Générer des valeurs dynamiques.
- Préparer les données avant l'envoi de la requête.
- Configurer des en-têtes personnalisés.
- Vérifier et manipuler des variables globales et locales.



