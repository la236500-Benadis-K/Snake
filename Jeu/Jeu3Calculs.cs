using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Jeu;

public partial class Snake
{
    // ********************************************* //
    // ******* METHODES SANS CLAVIER NI ECRAN ****** //
    // ********************************************* //
    // ******** A vérifier en tests unitaires ****** //
    // ********************************************* //

    /// <summary>
    /// Initialisation du jeu en fonction, en créant une nouvelle partie
    /// en changeant la configuration par défaut
    /// et en créant la base de données si nécessaire
    /// </summary>
    public static Partie InitialiserJeu()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - ChargerConfigurationParDefaut()
        // - CreerDB()
        // Partie partie = new();

        // MATIERE A UTILISER
        // - mettre la culture à fr-BE

        throw new NotImplementedException();
    }

    /// <summary>
    /// Ajouter un nouveau gateau sur le jeu, dans une case vide tirée au hasard
    /// en vérifiant qu'elle n'est pas déjà occupée par le serpent
    /// Le dessin du gâteau est tiré au hasard dans la liste des dessins de la configuration
    /// </summary>
    public static void AjouterGateau(ref Partie partie)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - VerifierCasePasVide()
        // - Partie partie = new();

        // MATIERE A UTILISER
        // - nombres aléatoires
        // - initialiser une Structure CaseDeJeu
    }

    /// <summary>
    /// Initialise le jeu avant de jouer une partie :
    /// - Direction initiale du serpent tirée au hasard
    /// - Position initiale du serpent (sur un bord à l'inverse de la direction)
    /// - Vitesse initiale du serpent
    /// - Gâteau initial
    /// - Mémorisation de la date et heure de début de partie
    /// - Indication que la partie est en cours
    /// </summary>
    public static void InitialiserPartie(ref Partie partie)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - VerifierCasePasVide()
        // - AjouterGateau()

        // MATIERE A UTILISER
        // - nombres aléatoires
        // - switch
        // - remplir une structure Partie
        // - ref
    }

    /// <summary>
    /// Calcule la nouvelle direction du serpent selon 
    /// - la nouvelle direction demandée
    /// - la direction actuelle
    /// Dans le cas d'une tentative de faire demi-tour, la direction est renvoyée inchangée
    /// car le serpent peut uniquement avancer tout droit ou tourner à gauche ou à droite par rapport à sa direction
    /// </summary>
    /// <param name="nouvelleDirection">Nouvelle direction</param>
    public static Directions CalculerNouvelleDirection(Directions ancienneDirection, Directions nouvelleDirection)
    {
        // A COMPLETER

        throw new NotImplementedException();
    }

    /// <summary>
    /// Vérification qu'une cellule n'est pas vide
    /// Renvoie true si la cellule passée en paramètre est déjà occupée par le serpent
    /// Il ya deux situations où c'est utilisé :
    /// - Dans le cas du serpent qui avance. Note : s'il rejoint sa queue, il ne la mord pas car elle avance aussi
    /// - Mais dans le cas du placement d'un nouveau gâteau : on exclut de placer la gâteau là où est la queue
    /// Le paramètre testLaQueue sert donc à indiquer s'il faut tester la queue  (premier cas) ou pas (deuxième cas)
    /// </summary>
    /// <param name="caseATester">La case de l'écran qu'il faut tester</param>
    /// <param name="testerLaQueue">Indique s'il faut tester la queue (true) ou pas (false)</param>
    /// <returns>true si elle n'est pas vide</returns>
    public static bool VerifierCasePasVide(List<CaseDeJeu> casesOccupees, CaseDeJeu caseATester, bool testerLaQueue)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - parcours de liste

        throw new NotImplementedException();
    }

    /// <summary>
    /// Fait avancer et accélérer le serpent
    /// Cette fonction va également détecter si le serpent entre en collision avec un mur ou avec lui-même
    /// - En cas de collision, la partie se termine
    /// - S'il y a un gâteau dans sa direction, le serpent va grandir: on ajoute une case en tête
    ///   et la vitesse redevient la vitesse minimale
    /// - Sinon, il avance: on avance la tête et on indique que la queue devra être enlevée 
    ///   après l'avoir effacée, et la vitese augmente en appelant la fonction Accelerer() !
    /// La fonction va donc mettre à jour les indicateurs de partie en cours, de queue à effacer, etc.
    /// </summary>
    public static void AvancerSerpent(ref Partie partie)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - VerifierCasePasVide()
        // - AjouterGateau()
        // - Accelerer()

        // MATIERE A UTILISER
        // - switch
        // - remplir une structure Partie
        // - ref
    }

    /// <summary>
    /// La queue est enlevée, sauf si le serpent a grandi en mangeant un gâteau,
    /// ce qui est indiquée par le paramètre QueueAEnlever dans partie
    /// </summary>
    public static void EnleverQueue(ref Partie partie)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - suppression d'un élément d'une liste
    }

    /// <summary>
    /// Fonction pour accélerer, c'est-à-dire augmenter la vitesse
    /// La vitesse est limitée à VITESSE_MAX
    /// </summary>
    public static void Accelerer(ref Partie partie)
    {
        // A COMPLETER
    }
}