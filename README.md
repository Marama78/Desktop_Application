# Assistant Code source

Après de nombreux projets. Il m'était difficile de replonger dans la relecture des lignes de codes.

Donc j'étais un peu frustré de ne pas pouvoir recycler mes codes.

Malgré la documentation technique que j'avais rédigé, je me retrouvais très facilement dans le désordre.

J'ai donc décidé de coder un éditeur de texte qui me permet de ranger un peu tout çà.

//--------------------------------------------
l'idée :

Je me suis inspiré d'un livre et de sa table des matières. L'utilisateur créé des "livres" dans lesquels il créé des "classeurs" pour enfin y rédiger des "pages".

Le programme a été développé sous visual studio 2019 en C# avec WPF desktop.

Celà m'a coûté 1 mois  de formation et de développement tout compris.

Depuis qu'il est fonctionnel, je peux enfin recycler tout mes codes sources et y accéder en quelques clics.

//---------------------------------------------
Pour la gestion des données, j'ai refusé d'utiliser mySQL. 
Parce que je n'y comprend rien (pour l'instant) et je trouve que c'est un peu trop compliqué.
J'ai donc organisé mes propres données avec des fichiers .txt et .odt (déguisés en .ini , .dat)

voici en gros la structure de ma base de données fait maison:

------------------------------------------------------------------------------------------------
.../data/

Le dossier est généré automatiquement et il contient toute les données du programme.

------------------------------------------------------------------------------------------------
.../data/initiate.ini

Ce fichier contient les 'clés' et la liste des livres. La grammaire est la suivante : 
    {clé book} + '|' + {nom du livre}
    
le programme gère des clés unique pour trois familles : 
    les 'books' {clé book},
    les 'classeurs' {clé classeur}
    et les 'pages' {clé page}
Donc les clés ne doivent pas être identiques.

------------------------------------------------------------------------------------------------
.../data/data_book_ {clé classeur} .dat

Ce fichier est créé automatiquement à chaque fois que l'on créé un nouveau BOOK.
C'est un simple fichier .txt déguisé en .dat
son rôle est d'enregistrer tout les classeur qui sont attachés à un book spécifique.

la grammaire:
  {clé classeur} + '|' + nom du classeur
  
la clé du classeur est composé de la clé du book et d'une itération:

  {clé book} + '_' + {iteration}
------------------------------------------------------------------------------------------------
.../data/data_book_ {clé book}/ ...

Ce dossier va contenir les noms de tous les classeurs qui sont attachés au 1 book spécifique et tout les documents de chacune des pages

------------------------------------------------------------------------------------------------
.../data/   data_book_ {clé book}   /   classeur_{clé classeur}.dat

Ce document est généré automatiquement à chaque fois que l'on créé un nouveau classeur.
Son rôle est d'enregistrer toutes les pages du classeur.

grammaire :
    {clé page} + '|' + nom de la page + '|' + chemin d'accès vers le contenu de la page
    
la clé de la page est composée de la clé du classeur et d'une itération

    {clé classeur} + '_' + {iteration}

------------------------------------------------------------------------------------------------
.../data/   data_book_ {clé book}   /   classeur_{clé book} / ...

Ce dossier est généré automatiquement à chaque fois qu'une nouvelle page est demandée.
Son rôle est de contenir tout les fichiers qui doivent s'afficher lorsque l'on active une page du classeur

------------------------------------------------------------------------------------------------
.../data/   data_book_ {clé book}   /   classeur_{clé book} / document_ + {clé page} + .dat

Ce document est généré automatiquement. Son rôle est d'enregistrer le contenu d'une page (texte et images)

------------------------------------------------------------------------------------------------
.../data/   user_key.dat

Ce document est généré automatiquement lorsque l'on supprime un document. L'idée est d'y enregistrer la clé qui a été détruite.

Jusqu'à présent, à chaque nouvelle pages, j'obtient une itération nouvelle. 
J'ai donc voulu recycler les clés des pages qui ont été supprimées.

Donc à chaque nouvelle page, le programme va y lire les lignes.
Si des clés sont disponibles, le programme va les réutiliser pour les nouvelles pages (en prenant soin de l'effacer au préalable).

-------------------------------------------------------------------------------------------------
Merci d'avoir pris la peine de lire jusqu'au bout
bonne journée
