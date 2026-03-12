using Jeu;

// Ceci est la fonction principale main() implicitement déclarée
// qui est le point d'entrée du programme
try
{
    // Initialiser le jeu en créant une nouvelle structure qui servira pour chaque partie jouée
    Snake.Partie partie = Snake.InitialiserJeu(); 
    // Affichage du menu principal.
    // L'affichage des scores, règles, etc. se fait sans sortir de cette fonction
    // et on en sort soit pour démarrer une partie (true) soit pour quitter le jeu (false)
    // Donc tant que le menu principal renvoie true, on joue une nouvelle partie !
    while (Snake.MenuPrincipal())
    {
        // Initialiser une nouvelle partie
        Snake.InitialiserPartie(ref partie);
        // Dessine le jeu complet à l'écran 
        Snake.DessinerJeuDepart(partie);
        // Tant que la partie est en cours, boucle sur les étapes de calcul 
        // et mise à jour du dessin du jeu 
        while (partie.PartieEnCours)
        {
            // Mémorise le moment de début du calcul
            Snake.MemoriserTempsDebutCalculs(ref partie);
            // Lit si un déplacement est demandé au clavier ou pas
            Snake.LireDeplacementAuClavier(ref partie);
            // Avance ou agrandit le serpent, ou fin de partie (partie.PartieEnCours devient false) si collision
            Snake.AvancerSerpent(ref partie);
            // Dessine les changements (déplacement du serpent, etc.)
            Snake.DessinerChangementsDuJeu(partie);
            // Enlève la queue si elle a dû être effacée à l'écran 
            // (il faut l'enlever après l'avoir effacée car on a besoin de ses coordonnées pour l'effacer)
            Snake.EnleverQueue(ref partie);
            // Attend en fonction 
            // - de la vitesse 
            // - de la durée de calcul et d'affichage 
            // en utilisant la mesure du temps avant le calcul
            Snake.AttendreSelonLaVitesse(partie);
        }
        // Affiche "Game Over", demande le pseudo du joueur et sauve le score en DB
        Snake.TerminerPartie(partie); 
    }
}
finally
{
    // Dialogue d'au revoir
    Snake.TerminerJeu(); 
}
