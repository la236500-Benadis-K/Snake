using System.Diagnostics;
using System.Diagnostics.Tracing;

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
        int centre = ((Console.WindowWidth + texte.Length) / 2);
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

        ConsoleKey touche;

        do
        {
            touche = Console.ReadKey(true).Key;
        }
        while (touche != ConsoleKey.Enter);
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
        Console.ForegroundColor = COULEUR_TITRE;

        Console.Clear();
        Console.WriteLine();
        AfficherTexteCentre("██████╗ ██╗   ██╗████████╗██╗  ██╗ █████╗ ███╗  ██╗");
        AfficherTexteCentre("██╔══██╗╚██╗ ██╔╝╚══██╔══╝██║  ██║██╔══██╗████╗ ██║");
        AfficherTexteCentre("██████╔╝ ╚████╔╝    ██║   ███████║██║  ██║██╔██╗██║");
        AfficherTexteCentre("██╔═══╝   ╚██╔╝     ██║   ██╔══██║██║  ██║██║╚████║");
        AfficherTexteCentre("██║        ██║      ██║   ██║  ██║╚█████╔╝██║ ╚███║");
        AfficherTexteCentre("╚═╝        ╚═╝      ╚═╝   ╚═╝  ╚═╝ ╚════╝ ╚═╝  ╚══╝");
        Console.WriteLine();
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

        Partie partie = InitialiserJeu();
        LireConfiguration("./Config/grillePetite.config");
        InitialiserPartie(ref partie);
        EffacerEtAfficherGrandTitre();




        string message = "Appuyez sur une touche pour commencer...";
        int posX = (LARGEUR_ECRAN / 2) - (message.Length / 2);
        if (posX < 0) posX = 0;




        int posY = Console.CursorTop + 2;



        bool texteVisible = true;



        // le texte alterne entre le magenta et le noir
        // qui donne l'illusion que le texte clignotte

        while (!Console.KeyAvailable)

        {

            Console.SetCursorPosition(posX, posY);



            // quand le texteVisible est à true le texte est en magenta
            // quand il est à false il est en noir
            Console.ForegroundColor = texteVisible ? COULEUR_SERPENT : COULEUR_FOND;

            AfficherTexteCentre(message);



            texteVisible = !texteVisible;

            Thread.Sleep(400);

        }




        Console.ReadKey(true);



        ChargerConfigurationParDefaut();

        Console.Clear();
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


        EffacerEtAfficherGrandTitre();

        Console.SetCursorPosition(0, Console.WindowHeight / 2);
        AfficherTexteCentre("Au revoir !");
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
        if (!_splashScreenDejaAffiche)
        {
            SplashScreen();
            _splashScreenDejaAffiche = true;
        }

        do
        {
            EffacerEtAfficherGrandTitre();
            Console.WriteLine();

            AfficherTexteCentre("Menu");
            Console.WriteLine();

            AfficherTexteCentre("1. Jouer une partie".PadRight(27));
            AfficherTexteCentre("2. Afficher l'aide".PadRight(27));
            AfficherTexteCentre("3. Afficher les scores".PadRight(27));
            AfficherTexteCentre("4. Changer la configuration".PadRight(27));
            AfficherTexteCentre("Q. Quitter le jeu".PadRight(27));


            ConsoleKey touche;
            touche = Console.ReadKey(true).Key;

            switch (touche)
            {
                case ConsoleKey.D1:

                    return true;


                case ConsoleKey.D2:

                    AfficherAide(false);
                    break;

                case ConsoleKey.D3:

                    AfficherScores();
                    break;

                case ConsoleKey.D4:

                    ChangerConfiguration();
                    break;

                case ConsoleKey.Q:
                    TerminerJeu();
                    return false;

            }

        }
        while (true);




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

        EffacerEtAfficherGrandTitre();
        AfficherTexteCentre(@"Le but du jeu est de faire avancer un serpent python en lui faisant manger
des gâteaux qui le font grandir pour atteindre la plus grande taille
possible. La vitesse de déplacement augmente régulièrement et ne redevient
lente que lorsque le serpent mange un gâteau.");
        Console.WriteLine();

        AfficherTexteCentre(@"Le but du jeu est de faire avancer un serpent python en lui faisant manger
des gâteaux qui le font grandir pour atteindre la plus grande taille
possible. La vitesse de déplacement augmente régulièrement et ne redevient
lente que lorsque le serpent mange un gâteau.");
        Console.WriteLine();

        AfficherTexteCentre(@"Les commandes de déplacement sont les flèches du clavier.
La partie se termine si le serpent cogne un bord ou se mord lui-même.");
        Console.WriteLine();

        AfficherTexteCentre(@"À la fin d'une partie, on peut donner son pseudo pour sauver son score.
On peut également visualiser les meilleurs scores et changer la configuration du jeu (taille et couleurs)");
        Console.WriteLine();

        AfficherTexteCentre("Enfoncez ENTER pour revenir au menu...");

        AttendreTouche();

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

        /****************************************************************** 
            une fois que l'utilisateur enfonce une touche 
            les modifications s'appliquent et le switch sert 
            à exécuter le fichier en fonction de la touche qui y correspond
        *******************************************************************/

        EffacerEtAfficherGrandTitre();
        AfficherTexteCentre("Configurations");
        Console.WriteLine();
        AfficherTexteCentre("1. Noir et blanc".PadRight(21));
        AfficherTexteCentre("2. Cyan".PadRight(21));
        AfficherTexteCentre("3. Grille plus petite".PadRight(21));
        Console.WriteLine();


        ConsoleKeyInfo touche = Console.ReadKey(true);


        switch (touche.Key)
        {
            case ConsoleKey.D1:
                ChargerConfigurationParDefaut();
                Console.BackgroundColor = COULEUR_FOND;
                Console.ForegroundColor = COULEUR_SERPENT;
                Console.Clear();
                break;
            case ConsoleKey.D2:
                LireConfiguration("Config/exemple.config");
                Console.BackgroundColor = COULEUR_FOND;
                Console.ForegroundColor = COULEUR_SERPENT;
                Console.Clear();
                break;
            case ConsoleKey.D3:
                LireConfiguration("Config/grillePetite.config");
                Console.BackgroundColor = COULEUR_FOND;
                Console.ForegroundColor = COULEUR_SERPENT;
                Console.Clear();
                break;



            default:

                break;
        }
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
        //━┃╋
        int largeurCol1 = 6;
        int largeurCol2 = 15;

        EffacerEtAfficherGrandTitre();

        string ligneEntete = "Points".PadRight(largeurCol1) + "┃ " + "Pseudo".PadRight(largeurCol2);
        string ligneCol1 = "".PadRight(largeurCol1, '━');
        string ligneCol2 = "".PadRight(largeurCol2 + 1, '━');
        string separateur = ligneCol1 + "╋" + ligneCol2;



        List<ScorePartie>? scores = LireScores(10, out string messageErreur);

        if (scores == null || scores.Count == 0)
        {
            AfficherTexteCentre("Aucun score enregistré.");
        }
        else
        {
            AfficherTexteCentre(ligneEntete);
            AfficherTexteCentre(separateur);
            foreach (ScorePartie score in scores)
            {
                string ligne = score.points.ToString().PadRight(largeurCol1) + "┃ " + score.pseudo.PadRight(largeurCol2);
                AfficherTexteCentre(ligne);
            }
        }

        AttendreTouche();


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

        Console.SetCursorPosition(0, HAUTEUR_ECRAN / 2);
        AfficherTexteCentre(" ██████   █████  ███    ███ ███████      ██████  ██    ██ ███████ ██████  ");
        AfficherTexteCentre("██       ██   ██ ████  ████ ██          ██    ██ ██    ██ ██      ██   ██ ");
        AfficherTexteCentre("██   ███ ███████ ██ ████ ██ █████       ██    ██ ██    ██ █████   ██████  ");
        AfficherTexteCentre("██    ██ ██   ██ ██  ██  ██ ██          ██    ██  ██  ██  ██      ██   ██ ");
        AfficherTexteCentre(" ██████  ██   ██ ██      ██ ███████      ██████    ████   ███████ ██   ██ ");


        string pseudo;
        bool saisieValide = false;

        const string MESSAGE = "Pseudo (3 à 20 lettres) ou ENTER pour rester anonyme: ";
        // pour positioner le texte à l'écran
        // en fonction de la largeur de l'écran 
        int posX = (LARGEUR_ECRAN / 2) - (MESSAGE.Length / 2);
        if (posX < 0)
        {
            posX = 0;
        }


        int posY = HAUTEUR_ECRAN + 3;
        if (posY >= Console.BufferHeight)
        {
            posY = Console.BufferHeight - 1;
        }

        do
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(MESSAGE);
            pseudo = Console.ReadLine();

            if (pseudo == "")
            {
                pseudo = "Anonyme";
                saisieValide = true;
            }

            else if (VerifierPseudo(pseudo))
            {
                saisieValide = true;
            }

        } while (!saisieValide);

        ScorePartie scorePartie = new ScorePartie();
        scorePartie.points = partie.Score;
        scorePartie.pseudo = pseudo;
        AjouterScore(scorePartie.pseudo, scorePartie.points, out string messageErreur);
        AttendreTouche();

    }

    /// <summary>
    /// Affiche le score, la durée de la partie et la vitesse en haut de l'écran
    /// </summary>
    /// <param name="partie">structure de la partie qui contient les informations à afficher</param>
    /// <param name="largeurMargeGauche">largeur de la marge de gauche de l'affichage (décalage pour centrer)</param>
    public static void AfficherScoreCourant(Partie partie, int largeurMargeGauche)
    {
        string score = $"Score : {partie.Score}";
        string vitesse = $"Vitesse : {partie.Vitesse}";

        TimeSpan temps = DateTime.Now - partie.TempsPartie;
        string duree = $"Durée : {temps.Seconds:D2}";

        
        string texte = score.PadRight(LARGEUR_ECRAN / 3)
                     + vitesse.PadRight(LARGEUR_ECRAN / 3)
                     + duree.PadRight(LARGEUR_ECRAN / 3);


        Console.SetCursorPosition(largeurMargeGauche, MARGE_HAUT - 1);
        Console.Write(texte);
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

        Console.Clear();

        MARGE_GAUCHE = (Console.WindowWidth - (LARGEUR_ECRAN + 2)) / 2;
        MARGE_HAUT = (Console.WindowHeight - (HAUTEUR_TERRAIN + 2)) / 2;
        if (MARGE_GAUCHE < 0)
        {
            MARGE_GAUCHE = 0;
        }

        if (MARGE_HAUT < 0)
        {
            MARGE_HAUT = 0;
        }
        Console.ForegroundColor = COULEUR_BORD;

        // Ligne haut
        Console.SetCursorPosition(MARGE_GAUCHE, MARGE_HAUT);
        Console.Write(COIN_HAUT_GAUCHE);
        Console.Write("".PadLeft(LARGEUR_ECRAN, BORD_HAUT));
        Console.Write(COIN_HAUT_DROIT);

        // Côtés gauche et droit
        for (int i = 0; i < HAUTEUR_TERRAIN; i++)
        {
            Console.SetCursorPosition(MARGE_GAUCHE, i + 1 + MARGE_HAUT);
            Console.Write(BORD_GAUCHE + "".PadLeft(LARGEUR_ECRAN) + BORD_DROIT);
        }

        // Ligne bas
        Console.SetCursorPosition(MARGE_GAUCHE, HAUTEUR_TERRAIN + 1 + MARGE_HAUT);
        Console.Write(COIN_BAS_GAUCHE);
        Console.Write("".PadLeft(LARGEUR_ECRAN, BORD_BAS));
        Console.Write(COIN_BAS_DROIT);

        // serpent
        for (int i = 0; i < partie.Serpent.Count; i++)
        {
            bool tete;

            if (i == 0)
            {
                tete = true;
            }
            else
            {
                tete = false;
            }

            DessinerAnneau(partie.Serpent[i], tete, partie.DirectionSerpent);
        }


        DessinerGateau(partie.PositionGateau);
        AfficherScoreCourant(partie, MARGE_GAUCHE);

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



        string dessin = DESSIN_CORPS;
        int colonne = caseADessiner.x * 2 + 1 + MARGE_GAUCHE;
        int ligne = caseADessiner.y + 1 + MARGE_HAUT;

        Console.SetCursorPosition(colonne, ligne);

        if (caseDeTete)
        {
            Console.ForegroundColor = COULEUR_TETE_SERPENT;
            switch (direction)
            {
                case Directions.Haut:
                    dessin = DESSIN_TETE_HAUT;
                    break;

                case Directions.Bas:
                    dessin = DESSIN_TETE_BAS;
                    break;
                case Directions.Droite:
                    dessin = DESSIN_TETE_DROITE;
                    break;
                case Directions.Gauche:
                    dessin = DESSIN_TETE_GAUCHE;
                    break;
            }
        }

        else
        {
            Console.ForegroundColor = COULEUR_SERPENT;
        }


        Console.Write(dessin);




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
        Console.ForegroundColor = COULEUR_GATEAU;

        string gateau_dessin = GATEAU_DESSIN;
        int colonne = caseADessiner.x * 2 + 1 + MARGE_GAUCHE;
        int ligne = caseADessiner.y + 1 + MARGE_HAUT;

        Console.SetCursorPosition(colonne, ligne);
        Console.Write(gateau_dessin);


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

        int colonne = caseAEffacer.x * 2 + 1 + MARGE_GAUCHE;//*2 car un anneau fais 2 caractères
        int ligne = caseAEffacer.y + 1 + MARGE_HAUT;//+1 pour pas spawn dans le mur
        Console.SetCursorPosition(colonne, ligne);
        Console.Write("  ");
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

        //on dessine la nouvelle tete index 0
        DessinerAnneau(partie.Serpent[0], true, partie.DirectionSerpent);

        //on dessine un anneau pour remplacer la tête
        DessinerAnneau(partie.Serpent[1], false, partie.DirectionSerpent);

        //si il ne mange pas 
        if (partie.EnleverQueue)
        {
            EffacerQueue(partie.EffacerQueue);//on avance en effacant la queue de la dernière position
        }
        else
        {
            DessinerGateau(partie.PositionGateau);// il a mangé donc on re dessine un gateau
        }
        AfficherScoreCourant(partie, MARGE_GAUCHE);

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
        partie.TempsAffichage = Environment.TickCount;
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
        int delai = 150 - partie.Vitesse;

        if (delai < 10)
        {
            delai = 10;
        }

        int tempsEcoule = Environment.TickCount - partie.TempsAffichage;
        delai = delai - tempsEcoule;

        if (delai < 0)
        {
            delai = 0;
        }
        Thread.Sleep(delai);

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

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo touche = Console.ReadKey(true);
            Directions nouvelleDirection = partie.DirectionSerpent;

            switch (touche.Key)
            {
                case ConsoleKey.UpArrow:
                    nouvelleDirection = Directions.Haut;
                    break;
                case ConsoleKey.DownArrow:
                    nouvelleDirection = Directions.Bas;
                    break;
                case ConsoleKey.LeftArrow:
                    nouvelleDirection = Directions.Gauche;
                    break;
                case ConsoleKey.RightArrow:
                    nouvelleDirection = Directions.Droite;
                    break;
            }
            partie.DirectionSerpent = CalculerNouvelleDirection(partie.DirectionSerpent, nouvelleDirection);
        }
    }
}