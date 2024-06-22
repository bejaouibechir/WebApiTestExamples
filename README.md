# Création d'une Collection pour les Opérations CRUD sur les Users avec Postman et JSONPlaceholder

## Objectifs

- Créer une collection dans Postman pour effectuer des opérations **CRUD (Create, Read, Update, Delete)** sur les utilisateurs **(users)** en utilisant l'API mock de JSONPlaceholder.

## Création de la Collection

### Ajouter une Requête GET (Read) pour Récupérer tous les Utilisateurs :

- Dans la collection **JSONPlaceholder Users**, cliquez sur le bouton **Add a request**.
- Nommez la requête **Get All Users**.
- Définissez la méthode sur **GET**.
- Entrez l'URL suivante : **https://jsonplaceholder.typicode.com/users**.
- Cliquez sur **Save** pour enregistrer la requête.

## Ajouter une Requête GET (Read) pour Récupérer un Utilisateur par ID :
- Cliquez sur le bouton **Add a request**.
- Nommez la requête **Get User by ID**.
- Définissez la méthode sur **GET**.
- Entrez l'URL suivante : **https://jsonplaceholder.typicode.com/users/1** (remplacez **1** par n'importe quel ID valide).
- Cliquez sur Save.

## Ajouter une Requête POST (Create) pour Créer un Nouvel Utilisateur :

- Cliquez sur le bouton **Add a request**.
-* Nommez la requête **Create User**.
- Définissez la méthode sur **POST**.
- Entrez l'URL suivante : **https://jsonplaceholder.typicode.com/users**.
- Allez dans l'onglet **Body** et sélectionnez raw puis **JSON**.
- Entrez le JSON suivant :

``` json
{
  "name": "John Doe",
  "username": "johndoe",
  "email": "johndoe@example.com"
}
```
- Cliquez sur Save.

## Ajouter une Requête PUT (Update) pour Mettre à Jour un Utilisateur :

- Cliquez sur le bouton **Add a request**.
- Nommez la requête **Update User**.
- Définissez la méthode sur **PUT**.
- Entrez l'URL suivante : **https://jsonplaceholder.typicode.com/users/1** (remplacez **1** par l'ID de l'utilisateur à mettre à jour).
- Allez dans l'onglet **Body** et sélectionnez raw puis **JSON**.
- Entrez le JSON suivant :
``` json
  {
    "name": "John Doe Updated",
    "username": "johndoeupdated",
    "email": "johndoeupdated@example.com"
  }

```
- Cliquez sur **Save**.

## Ajouter une Requête DELETE pour Supprimer un Utilisateur:

- Cliquez sur le bouton **Add a request**.
- Nommez la requête **Delete User**.
- Définissez la méthode sur **DELETE**.
- Entrez l'URL suivante : **https://jsonplaceholder.typicode.com/users/1** (remplacez **1** par l'ID de l'utilisateur à supprimer).
- Cliquez sur **Save**.

## Exécuter les Requêtes :

- Sélectionnez chaque requête dans la collection **JSONPlaceholder Users** et cliquez sur le bouton **Send**.
- Observez les réponses renvoyées par l'API JSONPlaceholder.

## Vérifier les Réponses :

- Pour la requête Get All Users, vous devriez voir une liste de tous les utilisateurs. (Code de réponse 200 OK)
- Pour la requête Get User by ID, vous devriez voir les détails de l'utilisateur correspondant à l'ID spécifié. (Code de réponse 200 OK)
- Pour la requête Create User, vous devriez voir les détails du nouvel utilisateur créé. (Code de réponse 201 OK)
- Pour la requête Update User, vous devriez voir les détails de l'utilisateur mis à jour. (Code de réponse 200 OK)
- Pour la requête Delete User, vous devriez voir une réponse indiquant que l'utilisateur a été supprimé (remarque : JSONPlaceholder ne supprime pas réellement les données). (Code de réponse 204 OK)




