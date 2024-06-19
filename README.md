# Exemple d'envoi de requêtes 

Utilisez le serveur fictif https://jsonplaceholder.typicode.com/todos dans cet exemple pour envoyer des requêtes

## Get: 
Lancez ces deux requêtes et observez les réponses envoyées

- https://jsonplaceholder.typicode.com/todos
- https://jsonplaceholder.typicode.com/todos?id=1

## POST:

Pour ajouter un nouveau élément dans la liste des tâches choisissez ***raw***  >  ***Body***  >  ***Json*** 

### Envoyer les données avec le formulaire (form-data ou x-www-form-urlencoded) 
**Les données:**
- userId: 9,
- id: 201,
- title: "ipsam aperiam voluptates qui",
- completed: false

![Passer les données via le formulaire]()

### Envoyer les données via format json / text
``` json
{
    "userId": 9,
    "id": 201,
    "title": "ipsam aperiam voluptates qui",
    "completed": false
}
```

### Envoyer les données via javascript

``` javascript
fetch("https://jsonplaceholder.typicode.com/todos", {
  method: "POST",
  body: JSON.stringify({
    userId: 9,
    id: 201,
    title: "ipsam aperiam voluptates qui",
    completed: false
  }),
  headers: {
    "Content-type": "application/json; charset=UTF-8"
  }
})
  .then((response) => response.json())
  .then((json) => console.log(json));
```
### Envoyer les données en format html

``` html 
<form action="https://jsonplaceholder.typicode.com/todos" method="post">
    <input type="hidden" name="userId" value="9">
    <input type="hidden" name="id" value="201">
    <input type="hidden" name="title" value="ipsam aperiam voluptates qui">
    <input type="hidden" name="completed" value="false">
    <input type="submit" value="Envoyer">
</form>
```

### Envoyer les données en format xml

```xml 
<request>
    <userId>9</userId>
    <id>209</id>
    <title>ipsam aperiam voluptates qui</title>
    <completed>false</completed>
</request>
```

## Les requêtes en GaphQL

Requêtez **https://graphqlzero.almansi.me/api**  avec **Postman**

voilà des exmeples de requêtes que j'ai testé et qui fonctionnent 

### Requêter tout les utilisateurs:

``` graphql
query {
  users {
    data {
      id
      name
      email
    }
  }
}
```
### Requêter tout un seul utilisateur dont id est 1:

``` graphql
query {
  user(id: 1) {
    id
    name
    email
  }
}
```
### Requête avec une variable 

``` graphql
query GetUserByID($userId: Int!) {
  user(id: $userId) {
    id
    name
    email
  }
}
```







