# Création et Test d'un Serveur Mock avec Postman

## Objectifs
- Créer une collection Postman pour effectuer des opérations CRUD sur les utilisateurs (users) en utilisant un serveur mock.
- Configurer et tester un serveur mock avec Postman.

## Création de la Collection
- Cliquez sur le bouton New dans le coin supérieur gauche de l'écran.
- Sélectionnez **Collection**.
- Donnez un nom à la collection, par exemple, Mock Server Users.
- Cliquez sur Create pour finaliser la création de la collection.

## Ajouter des Requêtes CRUD

- Créez des requêtes similaires à celles décrites dans le tutoriel précédent :
  - **Get All Users** (GET **/users**)
  - **Get User by ID** (GET **/users/:id**)
  - **Create User** (POST **/users**)
  - **Update User** (PUT **/users/:id**)
  - **Delete User** (DELETE **/users/:id**)

## Création d'un Serveur Mock

- Dans Postman, allez dans la section **Mock Servers**.
- Cliquez sur **New Mock Server**.
- Donnez un nom au serveur mock, par exemple, **Mock Server for Users**.
- Sélectionnez la collection **Mock Server Users** créée précédemment.
- Sélectionnez **Save the responses** pour sauvegarder les réponses.
- Cliquez sur **Create Mock Server.
- Notez l'URL du serveur mock générée par Postman. Par exemple,*https://a04706d6-7e9c-47ed-b465-291b5be17ebb.mock.pstmn.io*

## Modifier les URL des Requêtes 

- Dans la collection Mock Server Users, modifiez les URL des requêtes pour utiliser l'URL du serveur mock obtenue précédemment. Par exemple, remplacez https://jsonplaceholder.typicode.com par l'URL de votre serveur mock :
  - Get All Users : https://mockserver.postman.com/mock/.../users
  - Get User by ID : https://mockserver.postman.com/mock/.../users/:id
  - Create User : https://mockserver.postman.com/mock/.../users
  - Update User : https://mockserver.postman.com/mock/.../users/:id
  - Delete User : https://mockserver.postman.com/mock/.../users/:id

## Définir les Réponses Mock 

- Pour chaque requête dans la collection, définissez une réponse mock.
- Par exemple, pour Get All Users, ajoutez une réponse mock :
  ``` charp 
   [
    {
      "id": 1,
      "name": "John Doe",
      "username": "johndoe",
      "email": "johndoe@example.com"
    },
    {
      "id": 2,
      "name": "Jane Doe",
      "username": "janedoe",
      "email": "janedoe@example.com"
    }
  ]

  ```

## Sauvegarder les Réponses Mock 

- Pour chaque requête, allez dans l'onglet **Examples** et ajoutez un nouvel exemple.
- Donnez un nom à l'exemple (par exemple, **Get All Users Example**), définissez la réponse et sauvegardez.

##  Tester le Serveur Mock

- Sélectionnez chaque requête dans la collection Mock Server Users et cliquez sur le bouton Send.
- Vérifiez que les réponses sont celles définies dans les exemples mock.
- Pour la requête **Get All Users**, vous devriez voir la liste des utilisateurs définie dans l'exemple.
- Pour la requête **Get User by ID**, vous devriez voir les détails de l'utilisateur correspondant à l'ID spécifié dans l'exemple.
- Pour la requête **Create User**, vous devriez voir les détails du nouvel utilisateur créé comme défini dans l'exemple.
- Pour la requête **Update User**, vous devriez voir les détails de l'utilisateur mis à jour comme défini dans l'exemple.
- Pour la requête **Delete User**, vous devriez voir une réponse indiquant que l'utilisateur a été supprimé comme défini dans l'exemple.


