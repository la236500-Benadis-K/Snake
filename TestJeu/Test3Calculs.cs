using Jeu;

namespace TestJeu;

/// <summary>
/// Tests de calculs (position, déplacements, collisions, points, gâteaux mangés...)
/// </summary>
[TestClass]
[DoNotParallelize]
public class TestCalcul
{
    /// <summary>
    /// Tests de l'initialisation de la partie
    /// On va vérifier que les paramtères d'une partie sont corrects
    /// </summary>
    [TestMethod]
    public void InitialiserPartieParametres()
    {
        Snake.Partie partie = new();
        Snake.InitialiserPartie(ref partie);
        // Vérification des paramètres
        // A COMPLETER
        Assert.AreEqual(Snake.VITESSE_MIN, partie.Vitesse);
        Assert.AreEqual(0, partie.Score);
        Assert.IsTrue(partie.PartieEnCours);
        Assert.IsFalse(partie.EnleverQueue);
        Assert.AreEqual(3, partie.Serpent.Count);

    }

    [TestMethod]
    public void InitialiserPartieDirectionHaut()
    {
        Snake.Partie partie = new();


        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Haut);

        // On vérifie le placement
        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        Assert.AreEqual(tete.y, Snake.HAUTEUR_TERRAIN - 3);
        Assert.AreEqual(corps.y, Snake.HAUTEUR_TERRAIN - 2);
        Assert.AreEqual(queue.y, Snake.HAUTEUR_TERRAIN - 1);
        Assert.AreEqual(tete.x, queue.x);
    }

    [TestMethod]
    public void InitialiserPartieDirectionBas()
    {
        Snake.Partie partie = new();


        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Bas);

        // On vérifie le placement
        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        Assert.AreEqual(2, tete.y);
        Assert.AreEqual(1, corps.y);
        Assert.AreEqual(0, queue.y);
        Assert.AreEqual(tete.x, queue.x);
    }

    [TestMethod]
    public void InitialiserPartieDirectionGauche()
    {
        Snake.Partie partie = new();


        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Gauche);

        // On vérifie le placement
        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        Assert.AreEqual(Snake.LARGEUR_TERRAIN - 3, tete.x);
        Assert.AreEqual(Snake.LARGEUR_TERRAIN - 2, corps.x);
        Assert.AreEqual(Snake.LARGEUR_TERRAIN - 1, queue.x);
        Assert.AreEqual(tete.y, queue.y);
    }

    [TestMethod]
    public void InitialiserPartieDirectionDroite()
    {
        Snake.Partie partie = new();


        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Droite);

        // On vérifie le placement
        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        Assert.AreEqual(2, tete.x);
        Assert.AreEqual(1, corps.x);
        Assert.AreEqual(0, queue.x);
        Assert.AreEqual(tete.y, queue.y);
    }
    /**************************************************
        Tests InitialiserJeu()
    **************************************************/

    /// <summary>
    /// On vérifie que la culture est correcte
    /// </summary>
    [TestMethod]
    public void TestInitialiserJeuReturnPartieEtChangeCulture()
    {


        // Act
        Snake.Partie partie = Snake.InitialiserJeu();

        // Assert
        Assert.IsNotNull(partie);
        Assert.AreEqual("fr-BE", System.Globalization.CultureInfo.CurrentCulture.Name);
    }

    /// <summary>
    /// On vérifie que les configurations par défaut sont chargées
    /// </summary>
    [TestMethod]
    public void TestInitialiserJeuChargeConfigurationParDefaut()
    {
        // Arrange
        Snake.LARGEUR_TERRAIN = 20;
        Snake.COULEUR_BORD = ConsoleColor.Yellow;

        // Act
        Snake.InitialiserJeu();

        // Assert
        Assert.AreEqual(30, Snake.LARGEUR_TERRAIN);
        Assert.AreEqual(ConsoleColor.White, Snake.COULEUR_BORD);
    }

    [TestMethod]
    public void VitesseInferieurAVitesseMax()
    {
        Snake.Partie partie = new();

        partie.Vitesse = 1;

        Snake.Accelerer(ref partie);
        Assert.AreEqual(2, partie.Vitesse);

    }

    [TestMethod]
    public void VitesseEgalVitesseMax()
    {
        Snake.Partie partie = new();

        partie.Vitesse = 100;

        Snake.Accelerer(ref partie);
        Assert.AreEqual(100, partie.Vitesse);
    }


    [TestMethod]
    public void CaseOccupee()
    {
        Snake.Partie partie = new();

        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(1, 1);

        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, true);

        Assert.IsTrue(resultat);




    }

    [TestMethod]
    public void CaseVide()
    {
        Snake.Partie partie = new();

        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(11, 13);

        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, true);

        Assert.IsFalse(resultat);
    }


    [TestMethod]
    public void testerQueueTrue()
    {
        Snake.Partie partie = new();

        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(1, 1);

        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, true);

        Assert.IsTrue(resultat);
    }

    [TestMethod]
    public void testerQueueFalse()
    {
        Snake.Partie partie = new();

        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(1, 1);

        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, false);

        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void TestDemiTourHautBas()
    {
        Snake.Partie partie = new();

        Snake.Directions ancienneDirection = Snake.Directions.Haut;
        Snake.Directions nouvelleDirection = Snake.Directions.Bas;

        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        Assert.AreEqual(ancienneDirection, resultat);
    }


    [TestMethod]
    public void TestDemiTourGaucheDroite()
    {
        Snake.Partie partie = new();

        Snake.Directions ancienneDirection = Snake.Directions.Gauche;
        Snake.Directions nouvelleDirection = Snake.Directions.Droite;

        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        Assert.AreEqual(ancienneDirection, resultat);
    }

    [TestMethod]
    public void TestDemiTourBasHaut()
    {
        Snake.Partie partie = new();

        Snake.Directions ancienneDirection = Snake.Directions.Bas;
        Snake.Directions nouvelleDirection = Snake.Directions.Haut;

        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        Assert.AreEqual(ancienneDirection, resultat);
    }

    [TestMethod]
    public void TestDemiTourDroiteGauche()
    {
        Snake.Partie partie = new();

        Snake.Directions ancienneDirection = Snake.Directions.Droite;
        Snake.Directions nouvelleDirection = Snake.Directions.Gauche;

        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        Assert.AreEqual(ancienneDirection, resultat);
    }


    [TestMethod]
    public void TestDirectionValide()
    {
        Snake.Partie partie = new();

        Snake.Directions ancienneDirection = Snake.Directions.Haut;
        Snake.Directions nouvelleDirection = Snake.Directions.Droite;

        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        Assert.AreEqual(nouvelleDirection, resultat);
    }

    [TestMethod]
    public void EnleverQueueTrue()
    {
        Snake.Partie partie = new();

        partie.Serpent = new List<Snake.CaseDeJeu>();

        partie.Serpent.Add(new Snake.CaseDeJeu(1, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));

        partie.EnleverQueue = true;

        Snake.EnleverQueue(ref partie);
        Assert.AreEqual(2, partie.Serpent.Count);

    }

    [TestMethod]
    public void EnleverQueueFalse()
    {
        Snake.Partie partie = new();

        partie.Serpent = new List<Snake.CaseDeJeu>();

        partie.Serpent.Add(new Snake.CaseDeJeu(1, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));

        partie.EnleverQueue = false;

        Snake.EnleverQueue(ref partie);
        Assert.AreEqual(3, partie.Serpent.Count);

    }

    [TestMethod]
    public void AjouterGateauCaseVide()
    {
        Snake.Partie partie = new();

        partie.Serpent = new List<Snake.CaseDeJeu>();

        partie.Serpent.Add(new Snake.CaseDeJeu(1, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));

        Snake.AjouterGateau(ref partie);
        Assert.IsFalse(Snake.VerifierCasePasVide(partie.Serpent, partie.PositionGateau, true));


    }
    /*************************************************
                Test AvancerSerpent()
    **************************************************/
    [TestMethod]
    public void AvancerSerpentCollisionMurHaut()
    {

        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();

        //on place le serpent avec la tete qui regarde vers le haut
        partie.Serpent.Add(new Snake.CaseDeJeu(5, 0));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, 2));

        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Haut;//on le fais avancer vers le haut 

        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        Snake.AvancerSerpent(ref partie);

        Assert.IsFalse(partie.PartieEnCours);// il cogne le bord donc le jeu s'arrête
    }

    [TestMethod]
    public void AvancerSerpentCollisionMurBas()
    {
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();

        //serpent tout en bas
        partie.Serpent.Add(new Snake.CaseDeJeu(5, Snake.HAUTEUR_TERRAIN - 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, Snake.HAUTEUR_TERRAIN - 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, Snake.HAUTEUR_TERRAIN - 3));

        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Bas; // va vers le bas

        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        Snake.AvancerSerpent(ref partie);

        Assert.IsFalse(partie.PartieEnCours);//le jeu s'arrête quand il cogne
    }

    [TestMethod]
    public void AvancerSerpentCollisionMurDroite()
    {
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();

        //serpent tout à droite
        partie.Serpent.Add(new Snake.CaseDeJeu(Snake.LARGEUR_TERRAIN - 1, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(Snake.LARGEUR_TERRAIN - 2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(Snake.LARGEUR_TERRAIN - 3, 2));

        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Droite; //va vers la droite

        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        Snake.AvancerSerpent(ref partie);

        Assert.IsFalse(partie.PartieEnCours);//cogne le bord donc le jeu s'arrête
    }

    [TestMethod]
    public void AvancerSerpentCollisionMurGauche()
    {
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();

        //serpent tout à gauche
        partie.Serpent.Add(new Snake.CaseDeJeu(0, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(1, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));

        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Gauche; //va à gauche 

        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        Snake.AvancerSerpent(ref partie);

        Assert.IsFalse(partie.PartieEnCours);//cogne le bord donc le jeu s'arrête
    }

    [TestMethod]
    public void AvancerSerpentCollisionLuiMeme()
    {
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();

        //serpent en forme de C
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 3));//va cogner l'anneau qui se trouve à cette case car il va aller vers le bas
        partie.Serpent.Add(new Snake.CaseDeJeu(1, 3));

        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Bas;

        Snake.AvancerSerpent(ref partie);

        Assert.IsFalse(partie.PartieEnCours);//colision donc le jeu s'arrête
    }

    [TestMethod]
    public void AvancerSerpentMangeGateau()
    {
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();

        partie.Score = 4;
        partie.Vitesse = 25;

        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 3));

        partie.PositionGateau = new Snake.CaseDeJeu(1, 2);//on place un gâteau sur la prochaine case 
                                                          //où la tête du serpent va attérir car on le déplace vers la gauche
        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Gauche;

        Snake.AvancerSerpent(ref partie);

        Assert.AreEqual(5, partie.Score);//le score s'incrémente
        Assert.AreEqual(Snake.VITESSE_MIN, partie.Vitesse);//la vitesse retombe à la vitesse minimal
        Assert.AreEqual(5, partie.Serpent.Count);//1 anneau s'ajoute à la liste serpent 
        Assert.IsFalse(partie.EnleverQueue);//on enlève pas la queue car le serpent grandi 


    }

    [TestMethod]
    public void AvancerSerpentMangePasGateau()
    {
        Snake.Partie partie = new();

        partie.Serpent = new List<Snake.CaseDeJeu>();
        partie.Score = 4;
        partie.Vitesse = 25;

        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 3));

        partie.PositionGateau = new Snake.CaseDeJeu(10, 2);

        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Haut;

        Snake.AvancerSerpent(ref partie);

        Assert.AreEqual(26, partie.Vitesse);//vitesse s'incrémente
        Assert.AreEqual(4, partie.Score);//score ne bouge pas
        Assert.IsTrue(partie.EnleverQueue);//on enlève la queue pour que le serpent garde la meme taille
                                           // vu qu'on ajoute une nouvelle tête à chaque fois qu'il avance 
    }



}