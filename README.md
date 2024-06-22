# Créer un espace de travail Workspace

## Création d'un Workspace

- Ouvrir Postman : Lancez l'application Postman.
- Accéder aux Workspaces : Cliquez sur l'icône "Workspaces" en haut à gauche de l'écran.
- Créer un nouveau Workspace :
     - Cliquez sur le bouton "Create Workspace".
     - Remplissez les détails du Workspace :
       - ***Name :*** Donnez un nom au Workspace, par exemple, ***Demo Workspace***.
       - ***Summary*** : Ajoutez une brève description.
       - ***Visibility*** : Sélectionnez le type de Workspace ***(Personal, Team, Public)***.
  
### Comprendre les différents types de Workspaces

- **Personal Workspace :** Accessible uniquement par vous.
- **Team Workspace :** Accessible par les membres de votre équipe Postman.
- **Public Workspace :** Accessible par toute la communauté Postman.

###  Inviter des collaborateurs

**Accéder au Workspace :** Allez dans le Workspace que vous venez de créer.

**Inviter des collaborateurs :**

Cliquez sur le bouton **Invite**.
Entrez les adresses e-mail des personnes que vous souhaitez inviter.
Choisissez le rôle pour chaque collaborateur **(Admin, Editor, Viewer)**.

## Gérer les autorisations sous les Workspaces

**Comprendre les rôles :**

- Admin : Peut gérer le Workspace, les collections, et les membres.
- Editor : Peut modifier les collections et les environnements.
- Viewer : Peut uniquement voir les collections et les environnements.

**Attribuer des rôles :**

- Dans l'onglet **Manage Roles**, vous pouvez attribuer ou modifier les rôles des membres du Workspace.
- Cliquez sur le nom du membre, puis sélectionnez le rôle approprié.

## Découvrir les niveaux de visibilité basés sur les permissions

**Niveaux de visibilité :**

- Les **Admins** peuvent voir et modifier tous les aspects du Workspace.
- Les **Editors** peuvent voir et modifier les collections et les environnements, mais ne peuvent pas gérer les membres du Workspace.
- Les **Viewers** ne peuvent que consulter les collections et les environnements sans les modifier.

# Démonstration pratique
# TP : Gestion des Workspaces dans Postman

Pour rendre cette démonstration interactive, vous pouvez suivre ces étapes 

## Objectifs
- Créer et configurer un Workspace dans Postman.
- Inviter un collaborateur à rejoindre le Workspace.
- Comprendre et gérer les autorisations des membres du Workspace.
- Explorer les niveaux de visibilité et de permissions.

## Pré-requis
- Deux comptes Postman avec les emails suivants :
    - admin@xyz.com (Administrateur)
    - guest@xyz.com (Collaborateur invité)

## Étapes du TP

### Création du Workspace par l'administrateur

### Connexion à Postman :
- Connectez-vous à Postman avec le compte **admin@xyz.com**

### Création d'un nouveau Workspace :
- Cliquez sur l'icône "Workspaces" en haut à gauche de l'écran.
- Cliquez sur le bouton "Create Workspace".
- Remplissez les détails :
    - **Name :** Demo Workspace
    - **Summary :** Workspace de démonstration pour le TP
    - **Visibility :** Sélectionnez Team
### Enregistrer le Workspace :
- Cliquez sur "Create Workspace" pour finaliser la création.

### Invitation du collaborateur:
- Dans le **Demo Workspace**, cliquez sur le bouton "Invite".
- Entrez l'adresse e-mail **guest@xyz.com**.
- Sélectionnez le rôle **Viewer**.
- Cliquez sur **Invite**.
- 
### Notification par e-mail :
- Vérifiez que le collaborateur reçoit une notification d'invitation par e-mail et l'accepte.

### Gestion des autorisations

**Modification des rôles (par l'administrateur) :**

- Allez dans le ***Demo Workspace.***
- Cliquez sur "Manage Roles" (Gérer les rôles).
- Changez le rôle de ***guest@xyz.com*** de ***Viewer** à ***Editor***.
- Confirmez la modification.

### Exploration des niveaux de visibilité

- Exploration des permissions (par le collaborateur) :
  - Connectez-vous à Postman avec le compte guest@xyz.com.
  - Accédez au Demo Workspace.
  - Essayez de créer une nouvelle collection et d'ajouter des requêtes.
  
- Vérification des permissions :
  - Notez que guest@xyz.com peut créer et modifier des collections et des requêtes, mais ne peut pas gérer les membres du Workspace.

### Résultats attendus
- Les étudiants comprendront comment créer un Workspace et inviter des collaborateurs.
- Ils sauront attribuer et modifier des rôles au sein d'un Workspace.
- Ils découvriront les différences entre les rôles Admin, Editor, et Viewer.
- Ils seront capables de gérer les autorisations et les niveaux de visibilité dans Postman.
