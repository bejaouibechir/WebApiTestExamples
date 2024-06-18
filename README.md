# Étapes pour configurer les tests Newman dans Azure DevOps avec ngrok et Postman

## Prérequis :
- Un projet de Web API .NET Core 8.0 hébergé dans Azure DevOps.[Lien privé](https://bechirbejaoui.visualstudio.com/JWTProject/_git/JWTSolution)
- Utilisation de ngrok pour exposer l'API localement.[ngrok](https://ngrok.com/download)
- Collections et environnements configurés dans Postman pour les tests d'API.

## Étapes :
### Définir l'URL de ngrok dans l'environnement Postman :
Exportez votre collection et votre environnement depuis Postman en incluant la variable baseUrl avec l'URL ngrok dans 
le projet au niveau de la racine de la solution


