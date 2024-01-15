## LANCEMANT DU PROJET

Pour effectuer le lancement ou run l’application. il suffit d’effectuer  les étapes suivantes :
-	Build de l’image grâce au docker file. Il suffit de se placer dans le projet et lancer cette commande pour créer l’image : docker build -t api-big-data .

-	Lancer le Run de l’image ce qui va créer un conteneur et l’exposé avec la commande suivante : docker run --name  api-container -p 70:71 -d api-big-data
