# Étapes pour configurer les tests Newman dans Azure DevOps avec ngrok et Postman

## Prérequis :
- Un projet de Web API .NET Core 8.0 hébergé dans Azure DevOps.[Lien privé](https://bechirbejaoui.visualstudio.com/JWTProject/_git/JWTSolution)
- Utilisation de ngrok pour exposer l'API localement.[ngrok](https://ngrok.com/download)
- Collections et environnements configurés dans Postman pour les tests d'API.

## Étapes :
### Définir l'URL de ngrok dans l'environnement Postman :
Exportez votre collection et votre environnement depuis Postman en incluant la variable baseUrl avec l'URL ngrok dans 
le projet au niveau de la racine de la solution

[collection.json](https://github.com/bejaouibechir/WebApiTestExamples/blob/main/postman_collection.json)
[environment.json](https://github.com/bejaouibechir/WebApiTestExamples/blob/main/postman_environment.json)

![Structure du projet](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-newman-inaction/images/1.png)

### Configurer le pipeline Azure DevOps :

Utilisez le pipeline Azure DevOps pour restaurer, construire et exécuter les tests avec Newman :

[Le fichier de pipeline](https://github.com/bejaouibechir/WebApiTestExamples/blob/main/pipline.yaml)

### Exécution et vérification :

Assurez-vous que votre API .NET Core est correctement exposée via ngrok au moment de l'exécution des tests.
*** ngrok http <adresse de base de l'api> ***
Vérifiez que Newman utilise correctement l'adresse de base pour accéder à votre API dans le pipeline Azure DevOps.

Analysez les résultats des tests Newman pour détecter et résoudre les éventuelles erreurs.

![Pipeline en cour d'execution](https://github.com/bejaouibechir/WebApiTestExamples/blob/bejaouibechir-newman-inaction/images/2.png)




