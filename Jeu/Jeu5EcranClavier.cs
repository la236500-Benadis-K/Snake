using System.Diagnostics;

namespace Jeu;

public partial class Snake
{
    // ********************************************* //
    // **** METHODES POUR L'AFFICHAGE A L'ECRAN **** //
    // ********************************************* //

    /// <summary>
    /// Affiche une ligne de texte centrée à l'écran
    /// </summary>
    public static void AfficherTexteCentre(string texte)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - padding de chaînes de caractères
        int centre = ((64 + texte.Length) / 2);
        Console.WriteLine(texte.PadLeft(centre));
    }


    /// <summary>
    /// Attend qu'on enfonce une touche
    /// Si des touches ont été préalablement enfoncées, elles sont ignorées
    /// </summary>
    public static void AttendreTouche()
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - lecture de clavier de la Console
    }

    /// <summary>
    /// Effacer l'écran, affiche le nom du jeu en grand avec les couleur de titre et de fond
    /// </summary>
    public static void EffacerEtAfficherGrandTitre()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - AfficherTexteCentre

        // MATIERE A UTILISER
        // - affichage à la Console
    }


    // Affiche un écran d'accueil
    public static void SplashScreen()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - InitialiserJeu()
        // - LireConfiguration()
        // - InitialiserPartie()
        // - EffacerEtAfficherGrandTitre()

        // MATIERE A UTILISER
        // - affichage à la Console

        // BONUS POSSIBLES
        // - affichage d'un écran d'accueil animé
        // - ambiance sonore
    }

    /// <summary>
    /// Dialogue de fin de jeu. 
    /// Efface l'écran et affiche un message d'au revoir
    /// puis remet les couleurs aux valeurs par défaut
    /// Ne pas utiliser en tests unitaires
    /// </summary>
    public static void TerminerJeu()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - EffacerEtAfficherGrandTitre()
        // - AfficherTexteCentre()

        // MATIERE A UTILISER
        // - affichage à la Console
    }


    /// <summary>
    /// Dialogue principal
    /// Affiche le menu principal et les options du jeu
    /// On reste dans cette fonction (et les fonctions qu'elle appelle)  
    /// sauf pour démarrer une partie ou pour quitter le jeu
    /// Ne pas utiliser en tests unitaires
    /// </summary>
    /// <returns>true s'il faut jouer une partie, false s'il faut quitter le jeu</returns>
    public static bool MenuPrincipal()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - EffacerEtAfficherGrandTitre()
        // - AfficherTexteCentre()

        // MATIERE A UTILISER
        // - affichage à la Console
        // - lecture de touches du clavier de la Console
        // - switch

        throw new NotImplementedException();
    }

    /// <summary>
    /// Affichage de l'aide
    /// Ne pas utiliser en tests unitaires
    /// </summary>
    /// <param name="bonus">Inidique si le bonus est activé ou pas</param>
    public static void AfficherAide(bool bonus)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - EffacerEtAfficherGrandTitre()
        // - AttendreTouche()

        // MATIERE A UTILISER
        // - affichage à la Console
    }

    /// <summary>
    /// Changement de la configuration du jeu (taille, couleur...)
    /// Ces paramètres sont des variables globales déclarées dans le module "Declaration"
    /// Ne pas utiliser en tests unitaires
    /// </summary>
    public static void ChangerConfiguration()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - EffacerEtAfficherGrandTitre()
        // - AfficherTexteCentre()
        // - LireConfiguration()

        // MATIERE A UTILISER
        // - affichage à la Console
        // - lecture de touches du clavier de la Console
        // - switch
    }

    /// <summary>
    /// Affichage des meilleurs scores
    /// Ne pas utiliser en tests unitaires
    /// </summary>
    public static void AfficherScores()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - EffacerEtAfficherGrandTitre()
        // - LireScores()
        // - AttendreTouche()

        // MATIERE A UTILISER
        // - affichage à la Console
        // - utilisation d'une Liste de Structures
        // - switch
    }


    /// <summary>
    /// Affiche la fin de partie (Game Over), demande le pseudo du joueur et sauve son score
    /// A ne pas utiliser en tests unitaires
    /// </summary>
    /// <param name="partie">structure de la partie qui contient les informations sur la partie (score)</param>
    public static void TerminerPartie(Partie partie)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - AjouterScore()
        // - AttendreTouche()

        // MATIERE A UTILISER
        // - affichage à la Console
        // - positionnement du curseur de la console
    }

    /// <summary>
    /// Affiche le score, la durée de la partie et la vitesse en haut de l'écran
    /// </summary>
    /// <param name="partie">structure de la partie qui contient les informations à afficher</param>
    /// <param name="largeurMargeGauche">largeur de la marge de gauche de l'affichage (décalage pour centrer)</param>
    public static void AfficherScoreCourant(Partie partie, int largeurMargeGauche)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - affichage à la Console
        // - positionnement du curseur de la console
        // - manipulation de chaînes de caractères (padding...)
    }

    /// <summary>
    /// Dessine le jeu complet à l'écran
    /// A ne pas utiliser en tests unitaires
    /// </summary>
    public static void DessinerJeuDepart(Partie partie)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - AfficherScoreCourant()
        // - DessinerAnneau()
        // - DessinerGateau()

        // MATIERE A UTILISER
        // - affichage à la Console
        // - positionnement du curseur de la console
    }


    /// <summary>
    /// Dessine un anneau du serpent
    /// La position à l'écran doit tenir compte du fait que les cases de jeu occupent deux cases à l'écran
    /// et que le jeu est dans un cadre centré à l'écran
    /// </summary>
    /// <param name="caseADessiner">Case de jeu à dessiner</param>
    public static void DessinerAnneau(CaseDeJeu caseADessiner, bool caseDeTete, Directions direction)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - affichage à la Console
        // - positionnement du curseur de la console
    }

    /// <summary>
    /// Dessine un gâteau
    /// La position à l'écran doit tenir compte du fait que les cases de jeu occupent deux cases à l'écran
    /// et que le jeu est dans un cadre centré à l'écran
    /// </summary>
    /// <param name="caseADessiner">Case de jeu à dessiner</param>
    public static void DessinerGateau(CaseDeJeu caseADessiner)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - affichage à la Console
        // - positionnement du curseur de la console
    }

    /// <summary>
    /// Efface la queue du serpent en dessinant des cases vide (espaces)
    /// La position à l'écran doit tenir compte du fait que les cases de jeu occupent deux cases à l'écran
    /// et que le jeu est dans un cadre centré à l'écran
    /// </summary>
    /// <param name="caseAEffacer">Case de jeu à effacer</param>
    public static void EffacerQueue(CaseDeJeu caseAEffacer)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - affichage à la Console
        // - positionnement du curseur de la console
    }

    /// <summary>
    /// Mise à jour le dessin du jeu à l'écran sans tout redessiner pour que cela soit plus rapide
    /// Donc, on dessine la nouvelle tête et on efface la queue
    /// A ne pas utiliser en tests unitaires
    /// </summary>
    public static void DessinerChangementsDuJeu(Partie partie, bool bonus = true)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - AfficherScoreCourant()
        // - DessinerAnneau()
        // - DessinerGateau()
        // - EffacerQueue()

        // MATIERE A UTILISER
        // - affichage à la Console
        // - positionnement du curseur de la console

        // BONUS POSSIBLE
        // - ambiance sonore
    }

    /// <summary>
    /// Commence le comptage du temps pour calculer et afficher un déplacement
    /// Le résultat est mémorisé dans un des champs de la structure Partie
    /// Ne pas utiliser en tests unitaires
    /// </summary>
    public static void MemoriserTempsDebutCalculs(ref Partie partie)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - ref
    }

    /// <summary>
    /// Fonction qui met en attente le joueur en fonction de la vitesse (avec Thread.Sleep)
    /// La fonction calcule l'intervalle en millisecondes depuis de début du temps de calcul
    /// et soustrait cette valeur au temps d'attente sans toutefois avoir un temps d'attente négatif
    /// Ne pas utiliser en tests unitaires
    /// </summary>
    public static void AttendreSelonLaVitesse(Partie partie)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - Thread.Sleep
    }


    /// <summary>
    /// Lit s'il y a une entrée au clavier et applique le changement correspondant
    /// Attention: si une touche est maintenue enfoncée, elle n'est lue qu'une fois
    /// A ne pas utiliser en tests unitaires
    /// </summary>
    public static void LireDeplacementAuClavier(ref Partie partie)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - CalculerNouvelleDirection()

        // MATIERE A UTILISER
        // - Lecture des touches au clavier
    }
}