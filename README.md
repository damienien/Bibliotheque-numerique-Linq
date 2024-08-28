- Projet créé par : CHOQUET Damien
- Classe : M1 IL
- École : IPI

# Bibliothèque Numérique

Ce projet est une application console en .NET Core qui permet de gérer une bibliothèque numérique. Il utilise LINQ pour effectuer des recherches, des tris et des manipulations de données sur des fichiers JSON et XML représentant des livres et des membres de la bibliothèque.

## Fonctionnalités

- **Rechercher des livres par auteur** : Permet de rechercher des livres par le nom de l'auteur.
- **Rechercher des membres majeurs** : Affiche tous les membres de la bibliothèque ayant plus de 18 ans.
- **Trier les livres par date de publication** : Trie les livres en fonction de leur date de publication.
- **Trouver les livres empruntés par des membres majeurs** : Recherche les livres empruntés par des membres majeurs.

## Prérequis

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) ou version ultérieure.

## Installation

1. **Cloner le dépôt :**

   ```bash
   git clone https://github.com/votre-utilisateur/votre-depot.git
   cd votre-depot
   ```

2. **Restaurer les packages NuGet :**
	
	Dans le répertoire du projet, exécutez :
	```bash
	dotnet restore
	```

3. **Construire le projet :**
	```bash
	dotnet build
	```

## Utilisation

1. **Lancer l'application :**
	```bash
	dotnet run
	```

2. **Naviguer dans le menu:**

L'application présente un menu avec les options suivantes :
- `1` : Rechercher des livres par auteur.
- `2` : Rechercher des membres majeurs.
- `3` : Trier les livres par date de publication.
- `4` : Trouver les livres empruntés par des membres majeurs.
- `0`: Quitter l'application.

## Fichier de données

Le projet utilise deux fichiers de données :

- **`books.json`** : Contient la liste des livres.
- **`members.xml`** : Contient la liste des membres.

Ces fichiers sont automatiquement copiés dans le répertoire de sortie lors de la compilation. Ils doivent être présents à la racine du projet.

### Exemple de 'book.json'
```
[
  {
    "Id": 1,
    "Title": "1984",
    "Author": "George Orwell",
    "PublishedDate": "1949-06-08",
    "MemberId": 1
  },
  {
    "Id": 2,
    "Title": "Brave New World",
    "Author": "Aldous Huxley",
    "PublishedDate": "1932-01-01",
    "MemberId": 2
  }
]
```

### Exemple de "member.xml"
```
<?xml version="1.0" encoding="utf-8" ?>
<Members>
  <Member>
    <Id>1</Id>
    <Name>John Doe</Name>
    <Age>30</Age>
  </Member>
  <Member>
    <Id>2</Id>
    <Name>Jane Smith</Name>
    <Age>25</Age>
  </Member>
</Members>
```