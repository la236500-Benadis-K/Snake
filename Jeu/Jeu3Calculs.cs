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
        CultureInfo.CurrentCulture = new CultureInfo("fr-BE");
        ChargerConfigurationParDefaut();

        Console.BackgroundColor = COULEUR_FOND;
        Console.ForegroundColor = COULEUR_SERPENT;

        Console.Clear();
        Console.CursorVisible = false;
        CreerDB(out string messageErreur);
        Partie partie = new();
        return partie;

        //throw new NotImplementedException();
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


        // On génère des coordonnées aléatoires 
        // jusqu'à trouver une case qui n'est pas occupée par le serpent
        do
        {
            partie.PositionGateau.x = Random.Shared.Next(0, LARGEUR_TERRAIN);

            partie.PositionGateau.y = Random.Shared.Next(0, HAUTEUR_TERRAIN);

        } while (VerifierCasePasVide(partie.Serpent, partie.PositionGateau, true));

        // Si la liste des gateaux n'est pas vide
        //  on en sélectionne un au hasard
        if (LISTE_GATEAUX.Count > 0)
        {
            int indexAleatoire = Random.Shared.Next(0, LISTE_GATEAUX.Count);

            GATEAU_DESSIN = LISTE_GATEAUX[indexAleatoire];
        }
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

        partie.Vitesse = VITESSE_MIN;
        partie.Score = 0;
        partie.TempsPartie = DateTime.Now;
        partie.PartieEnCours = true;
        partie.EnleverQueue = false;


        //on tire une directions au hasard dans l'enum de direction 
        partie.DirectionSerpent = (Directions)Random.Shared.Next(0, 4);

        switch (partie.DirectionSerpent)
        {
            // Le serpent est placé sur le bord opposé à sa direction
            // Il est initialisé avec 3 case : la tête et deux anneaux pour le corps
            case Directions.Haut:
                int x = Random.Shared.Next(0, LARGEUR_TERRAIN);

                partie.Serpent = new List<CaseDeJeu>();
                partie.Serpent.Add(new CaseDeJeu(x, HAUTEUR_TERRAIN - 3)); //la tête
                partie.Serpent.Add(new CaseDeJeu(x, HAUTEUR_TERRAIN - 2)); //Corps
                partie.Serpent.Add(new CaseDeJeu(x, HAUTEUR_TERRAIN - 1)); //queue collée au bord opposé
                break;

            case Directions.Bas:
                x = Random.Shared.Next(0, LARGEUR_TERRAIN);

                partie.Serpent = new List<CaseDeJeu>();
                partie.Serpent.Add(new CaseDeJeu(x, 2));
                partie.Serpent.Add(new CaseDeJeu(x, 1));
                partie.Serpent.Add(new CaseDeJeu(x, 0));
                break;

            case Directions.Droite:
                int y = Random.Shared.Next(0, HAUTEUR_TERRAIN);


                partie.Serpent = new List<CaseDeJeu>();
                partie.Serpent.Add(new CaseDeJeu(2, y));
                partie.Serpent.Add(new CaseDeJeu(1, y));
                partie.Serpent.Add(new CaseDeJeu(0, y));
                break;

            case Directions.Gauche:
                y = Random.Shared.Next(0, HAUTEUR_TERRAIN);

                partie.Serpent = new List<CaseDeJeu>();
                partie.Serpent.Add(new CaseDeJeu(LARGEUR_TERRAIN - 3, y));
                partie.Serpent.Add(new CaseDeJeu(LARGEUR_TERRAIN - 2, y));
                partie.Serpent.Add(new CaseDeJeu(LARGEUR_TERRAIN - 1, y));
                break;
        }

        AjouterGateau(ref partie);
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

        switch (ancienneDirection)
        {
            //vérifie qu'ont ne fais pas demi tour, si c'est le cas on renvoie l'ancienne direction
            // par EX: si on va vers le haut et veut aller vers le bas ça retourne l'ancienne direction qui est le haut car on ne peut pas faire demi-tour
            case Directions.Haut:

                if (nouvelleDirection == Directions.Bas)
                {
                    return ancienneDirection;
                }
                break;

            case Directions.Bas:
                if (nouvelleDirection == Directions.Haut)
                {
                    return ancienneDirection;
                }
                break;

            case Directions.Droite:
                if (nouvelleDirection == Directions.Gauche)
                {
                    return ancienneDirection;
                }
                break;

            case Directions.Gauche:
                if (nouvelleDirection == Directions.Droite)
                {
                    return ancienneDirection;
                }
                break;
        }

        //return la nouvelle direction si elle est valide 
        return nouvelleDirection;
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

        int limite;

        if (testerLaQueue)
        {
            // test toute la liste avec la queue pour voir si le serpend se mord quand il avance 
            limite = casesOccupees.Count;
        }
        else

        {
            // pour tester toute la liste sans la queue pour voir si une case est vide pour le gateau 
            limite = casesOccupees.Count - 1;
        }


        for (int i = 0; i < limite; i++)
        {
            //pour vérifier si la case occupée est égale à la case qui est testée 
            if (casesOccupees[i].x == caseATester.x && casesOccupees[i].y == caseATester.y)
            {
                return true; // case occupée
            }
        }

        return false; // case vide 
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

        CaseDeJeu nouvelleTete = new CaseDeJeu();

        switch (partie.DirectionSerpent)
        {
            case Directions.Haut:
                nouvelleTete.x = partie.Serpent[0].x;
                nouvelleTete.y = partie.Serpent[0].y - 1; // on remonte d'une ligne car on va vers le haut 
                break;                                    // on passe de la ligne 20 à 19
            case Directions.Bas:
                nouvelleTete.x = partie.Serpent[0].x;
                nouvelleTete.y = partie.Serpent[0].y + 1; // on descend d'une ligne car on va vers le bas 
                break;                                    // on passe de la ligne 0 à 1
            case Directions.Droite:
                nouvelleTete.x = partie.Serpent[0].x + 1;// on décalle d'une colonne à droite
                nouvelleTete.y = partie.Serpent[0].y;
                break;
            case Directions.Gauche:
                nouvelleTete.x = partie.Serpent[0].x - 1;// on décalle d'une colonne vers la gauche
                nouvelleTete.y = partie.Serpent[0].y;
                break;
        }

        // on vérifie si la tête percute le terrain, si oui on termine la partie
        if (nouvelleTete.x < 0 || nouvelleTete.x >= LARGEUR_TERRAIN || nouvelleTete.y < 0 ||
        nouvelleTete.y >= HAUTEUR_TERRAIN)
        {
            partie.PartieEnCours = false;
            return;
        }

        // on vérifie si le serpent percute son corps, si oui on termine la partie 
        else if (VerifierCasePasVide(partie.Serpent, nouvelleTete, false))
        {
            partie.PartieEnCours = false;
            return;
        }

        //mémorise la position actuelle de la queue
        partie.EffacerQueue = partie.Serpent[partie.Serpent.Count - 1];

        // si le serpent mange un gateau
        if (nouvelleTete.x == partie.PositionGateau.x && nouvelleTete.y == partie.PositionGateau.y)
        {
            partie.Serpent.Insert(0, nouvelleTete);// on ajoute une nouvelle tête à l'index 0
            partie.Score++;
            partie.Vitesse = VITESSE_MIN;
            AjouterGateau(ref partie);
            partie.EnleverQueue = false;
        }

        else
        {
            partie.Serpent.Insert(0, nouvelleTete);
            partie.EnleverQueue = true;//on supprime l'ancienne queue 
            Accelerer(ref partie);//le serpent accélère
        }

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

        if (partie.EnleverQueue)
        {
            partie.Serpent.RemoveAt(partie.Serpent.Count - 1);
        }
    }

    /// <summary>
    /// Fonction pour accélerer, c'est-à-dire augmenter la vitesse
    /// La vitesse est limitée à VITESSE_MAX
    /// </summary>
    public static void Accelerer(ref Partie partie)
    {
        // A COMPLETER

        if (partie.Vitesse < VITESSE_MAX)
        {
            partie.Vitesse++;
        }
    }
}