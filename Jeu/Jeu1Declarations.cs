namespace Jeu;

public partial class Snake
{
    // ********************************************* //
    // ************** ENUMERATIONS ***************** //
    // ********************************************* //

    // Quatre directions possibles pour les déplacements du serpent
    public enum Directions
    {
        Haut,
        Bas,
        Gauche,
        Droite
    }

    // ********************************************* //
    // *************** STRUCTURES ****************** //
    // ********************************************* //

    /// <summary>
    /// Structure pour stocker une coordonnée de case dans le jeu
    /// </summary>
    public struct CaseDeJeu
    {
        // A COMPLETER
        int x;
        int y;


        // Constructeur de la structure
        public CaseDeJeu(int x, int y) : this()
        {
            // A COMPLETER
            this.x = x;
            this.y = y;
        }

    }

    /// <summary>
    /// Structure pour stocker un résultat de partie
    /// (pseudo du joueur et points de la partie)
    /// </summary>
    public struct ScorePartie
    {
        public string pseudo;
        public int scores;
    }

    /// <summary>
    /// Tous les paramètres d'une partie sont stockés dans cette structure
    /// Dans le code, une variable de type Partie est utilisée pour passer 
    /// tous les paramètres en une seul fois.
    /// S'il faut modifier les paramètres dans une fonction, 
    /// la variable est passée par référence (ref)
    /// pour ne pas perdre le changement effectué dans la fonction
    /// </summary>
    public struct Partie
    {
        // Liste des anneaux du serpent (anneau = case à l'écran), dans l'ordre de la tête à la queue
        // A COMPLETER

        // Indicateur de la queue du serpent à enlever après l'avoir effacée
        // Algorithme = 
        // - avancer la tête
        // - effacer la queue sauf si cookie mangé car alors le serpent grandit
        // - enlever la queue de la liste sauf si cookie mangé
        // A COMPLETER

        // Indicateur de la queue du serpent à effacer à l'affichage
        // Algorithme = écrire un espace pour effacer la queue, sauf si la tête prend la place de la queue
        // A COMPLETER

        // Position du gâteau à attraper
        // A COMPLETER

        // Direction de déplacement du serpent
        // A COMPLETER

        // Vitesse du jeu. 
        // Le jeu accélère quand le serpent avance et redevient lent après avoir mangé un gâteau.
        // A COMPLETER

        // Score d'une partie (nombre de gâteaux attrapés)
        // A COMPLETER

        // Mesure du temps de la partie
        // A COMPLETER

        // Mesure du temps de calcul pour l'affichage
        // A COMPLETER

        // Indique que le jeu (programme principal) est en cours
        // Quand il devient false, on quitte complètement le jeu
        // A COMPLETER

        // Indique qu'une partie est en cours
        // Un jeu peut comporter plusieurs parties et  
        // il faut revenir au menu principal du jeu entre les parties
        public bool PartieEnCours;
    }

    // ********************************************* //
    // *************** CONSTANTES ****************** //
    // ********************************************* //
    // Caractères pour la bordure autour du jeu (pour les calculs et l'affichage) 
    // Exemples de possibilités : ▐ ▌ ▄ ▀ ▗ ▖ ▝ ▘
    // A COMPLETER
    const string COIN_HAUT_DROIT = "▝";
    const string COINT_HAUT_GAUCHE = "▘";
    const string BORD_DROIT = "▐";
    const string BORD_GAUCHE = "▌";
    const string COIN_BAS_DROIT = "▗";
    const string COIN_BAS_GAUCHE = "▖";
    const string BORD_HAUT = "▀";
    const string BORD_BAS = "▄";


    // Dessins de anneaux du serpent
    // Attention: chaque anneaux utilise 2 caractères de large pour que ce soit carré, 
    // et ça doit se raccorder dans tous les sens, ce qui limite les choix...
    // Choix pour les dessins █ ▓ ▒ ░ ▐ ▌ ⚌ ╱ ╲ ⧹ ⧸ ≻ ≺ ╯ ╮ ▕ ─ ▶ ◀ ◢ ◣ ◥ ◤ ⸦ ⸧
    // A COMPLETER

    // Constantes pour la vitesse minimum et maximum (de 1 à 100)
    // A COMPLETER
    const int VITESSE_MIN = 1;
    const int VITESSE_MAX = 100;

    // Constantes pour les longueurs de pseudos des joueurs (de 3 à 20)
    // A COMPLETER
    const int LONGUEUR_MIN_PSEUDO = 3;
    const int LONGUEUR_MAX_PSEUDO = 20;

    // ********************************************* //
    // ************* CONFIGURATION ***************** //
    // ********************************************* //
    // Ce sont les valeurs de configuration du jeu
    // Recommendation: les déclarer "public static"
    // - public pour les tester
    // - static parce qu'elles sont uniques pour le jeu
    // Ce ne sont pas des constantes mais elles sont utilisables dans tout le code, 
    // donc le nom des variables est en majuscule pour le montrer
    // et éviter que les modifie par erreur

    // Dimensions du terrain de jeu (largeur et hauteur)
    // A COMPLETER

    // Caractères des gâteaux à manger (au minimum un dessin de gâteau)
    // Exemple: ⬤
    // A COMPLETER

    // Couleurs du jeu
    // A COMPLETER

    // Valeur dérivées de la configuration
    // Les dimensions "ECRAN" utilise les caractères de l'écran, et tiennent donc
    // compte du fait qu'une case de jeu fait 2 caractères de large à l'écran
    // A COMPLETER
}