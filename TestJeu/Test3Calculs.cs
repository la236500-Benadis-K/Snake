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
    /// On va vérifier que les paramètères d'une partie sont corrects
    /// </summary>
    [TestMethod]
    public void InitialiserPartieParametres()
    {
        //Arrange
        Snake.Partie partie = new();

        //Act
        Snake.InitialiserPartie(ref partie);

        //Assert
        Assert.AreEqual(Snake.VITESSE_MIN, partie.Vitesse);
        Assert.AreEqual(0, partie.Score);
        Assert.IsTrue(partie.PartieEnCours);
        Assert.IsFalse(partie.EnleverQueue);
        Assert.AreEqual(3, partie.Serpent.Count);

    }

    /// <summary>
    /// test de la direction haut
    /// on vérifie que le serpent commence vers le bas
    /// quand la direction va vers le haut
    /// </summary>
    [TestMethod]
    public void InitialiserPartieDirectionHaut()
    {
        //Arrange
        Snake.Partie partie = new();

        //Act
        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Haut);


        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        //Assert
        Assert.AreEqual(tete.y, Snake.HAUTEUR_TERRAIN - 3);
        Assert.AreEqual(corps.y, Snake.HAUTEUR_TERRAIN - 2);
        Assert.AreEqual(queue.y, Snake.HAUTEUR_TERRAIN - 1);
        Assert.AreEqual(tete.x, queue.x);
    }

    /// <summary>
    /// test de direction vers le bas
    /// on vérifie que le serpent va vers le bas
    /// </summary>
    [TestMethod]
    public void InitialiserPartieDirectionBas()
    {
        //Arrange
        Snake.Partie partie = new();

        //Act
        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Bas);


        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        //Assert
        Assert.AreEqual(2, tete.y);
        Assert.AreEqual(1, corps.y);
        Assert.AreEqual(0, queue.y);
        Assert.AreEqual(tete.x, queue.x);
    }

    /// <summary>
    /// test de direction vers la gauche
    /// on vérifie que le serpent va vers la gauche
    /// </summary>
    [TestMethod]
    public void InitialiserPartieDirectionGauche()
    {
        //Arrange
        Snake.Partie partie = new();

        //Act
        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Gauche);


        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        //Assert
        Assert.AreEqual(Snake.LARGEUR_TERRAIN - 3, tete.x);
        Assert.AreEqual(Snake.LARGEUR_TERRAIN - 2, corps.x);
        Assert.AreEqual(Snake.LARGEUR_TERRAIN - 1, queue.x);
        Assert.AreEqual(tete.y, queue.y);
    }

    /// <summary>
    /// test de direction vers la droite
    /// on vérifie que le serpent va vers la droite
    /// </summary>
    [TestMethod]
    public void InitialiserPartieDirectionDroite()
    {
        //Arrange
        Snake.Partie partie = new();

        //Act
        do
        {
            Snake.InitialiserPartie(ref partie);
        } while (partie.DirectionSerpent != Snake.Directions.Droite);


        Snake.CaseDeJeu tete = partie.Serpent[0];
        Snake.CaseDeJeu corps = partie.Serpent[1];
        Snake.CaseDeJeu queue = partie.Serpent[2];

        //Assert
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

    /// <summary>
    /// test de la vitesse
    /// on vérfie que la vitesse s'incrémente bien de 1 
    /// </summary>
    [TestMethod]
    public void VitesseInferieurAVitesseMax()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Vitesse = 1;

        //Act
        Snake.Accelerer(ref partie);

        //Assert
        Assert.AreEqual(2, partie.Vitesse);

    }

    /// <summary>
    /// test de vitesse
    /// on vérifie que la vitesse
    /// ne dépasse pas la limite de 100
    /// </summary>
    [TestMethod]
    public void VitesseEgalVitesseMax()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Vitesse = 100;

        //Act
        Snake.Accelerer(ref partie);

        //Assert
        Assert.AreEqual(100, partie.Vitesse);
    }

/// <summary>
/// test de caseOccupee
/// on test une case pour voir si
/// elle est occupée
/// </summary>
    [TestMethod]
    public void CaseOccupee()
    {
        //Arrange
        Snake.Partie partie = new();
        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(1, 1);

        //Act
        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, true);

        //Assert
        Assert.IsTrue(resultat);




    }

/// <summary>
/// on test si une case est vide
/// </summary>
    [TestMethod]
    public void CaseVide()
    {
        //Arrange
        Snake.Partie partie = new();
        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(11, 13);

        //Act
        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, true);

        //Assert
        Assert.IsFalse(resultat);
    }

/// <summary>
/// on vérifie si la case testée
/// contient la queue
/// </summary>
    [TestMethod]
    public void testerQueueTrue()
    {
        //Arrange
        Snake.Partie partie = new();
        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(1, 1);

        //Act
        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, true);

        //Assert
        Assert.IsTrue(resultat);
    }

    [TestMethod]
    public void testerQueueFalse()
    {
        //Arrange
        Snake.Partie partie = new();
        List<Snake.CaseDeJeu> caseOccupee = new();
        caseOccupee.Add(new Snake.CaseDeJeu(1, 1));
        Snake.CaseDeJeu caseAtester = new Snake.CaseDeJeu(1, 1);

        //Act
        bool resultat = Snake.VerifierCasePasVide(caseOccupee, caseAtester, false);

        //Assert
        Assert.IsFalse(resultat);
    }

    /// <summary>
    /// test demi tour du serpent
    /// on vérifie que le serpent ne peux pas
    /// faire demi-tour du haut vers le bas
    /// </summary>
    [TestMethod]
    public void TestDemiTourHautBas()
    {
        //Arrange
        Snake.Partie partie = new();
        Snake.Directions ancienneDirection = Snake.Directions.Haut;
        Snake.Directions nouvelleDirection = Snake.Directions.Bas;

        //Act
        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        //Arrange
        Assert.AreEqual(ancienneDirection, resultat);
    }


    /// <summary>
    /// test demi tour du serpent
    /// on vérifie que le serpent ne peux pas
    /// faire demi-tour de la gauche vers la droite
    /// </summary>
    [TestMethod]
    public void TestDemiTourGaucheDroite()
    {
        //Arrange
        Snake.Partie partie = new();
        Snake.Directions ancienneDirection = Snake.Directions.Gauche;
        Snake.Directions nouvelleDirection = Snake.Directions.Droite;

        //Act
        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        //Arrange
        Assert.AreEqual(ancienneDirection, resultat);
    }

    /// <summary>
    /// test demi tour du serpent
    /// on vérifie que le serpent ne peux pas
    /// faire demi-tour du bas vers le haut
    /// </summary>
    [TestMethod]
    public void TestDemiTourBasHaut()
    {
        //Arrange
        Snake.Partie partie = new();
        Snake.Directions ancienneDirection = Snake.Directions.Bas;
        Snake.Directions nouvelleDirection = Snake.Directions.Haut;

        //Act
        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        //Assert
        Assert.AreEqual(ancienneDirection, resultat);
    }

    /// <summary>
    /// test demi tour du serpent
    /// on vérifie que le serpent ne peux pas
    /// faire demi-tour de la droite vers la gauche
    /// </summary>
    [TestMethod]
    public void TestDemiTourDroiteGauche()
    {
        //Arrange
        Snake.Partie partie = new();
        Snake.Directions ancienneDirection = Snake.Directions.Droite;
        Snake.Directions nouvelleDirection = Snake.Directions.Gauche;

        //Act
        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        //Assert
        Assert.AreEqual(ancienneDirection, resultat);
    }

/// <summary>
/// test de direction valide
/// </summary>
    [TestMethod]
    public void TestDirectionValide()
    {
        //Arrange
        Snake.Partie partie = new();
        Snake.Directions ancienneDirection = Snake.Directions.Haut;
        Snake.Directions nouvelleDirection = Snake.Directions.Droite;

        //Act
        Snake.Directions resultat = Snake.CalculerNouvelleDirection(ancienneDirection, nouvelleDirection);

        //Assert
        Assert.AreEqual(nouvelleDirection, resultat);
    }

/// <summary>
/// test pour enlever la queue
/// on vérifie qu'on enlève la queue
/// quand le serpent avance mais ne mange pas
/// </summary>
    [TestMethod]
    public void EnleverQueueTrue()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();
        partie.Serpent.Add(new Snake.CaseDeJeu(1, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));
        partie.EnleverQueue = true;

        //Act
        Snake.EnleverQueue(ref partie);

        //Assert
        Assert.AreEqual(2, partie.Serpent.Count);

    }

/// <summary>
/// on enlève pas la queue
/// quand le serpent mange un gateau
/// </summary>
    [TestMethod]
    public void EnleverQueueFalse()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();
        partie.Serpent.Add(new Snake.CaseDeJeu(1, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));
        partie.EnleverQueue = false;

        //Act
        Snake.EnleverQueue(ref partie);

        //Assert
        Assert.AreEqual(3, partie.Serpent.Count);

    }

/// <summary>
/// test pour ajouter un gâteau
/// on vérifie que la case où va apparaître le gateau
/// est vide
/// </summary>
    [TestMethod]
    public void AjouterGateauCaseVide()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();
        partie.Serpent.Add(new Snake.CaseDeJeu(1, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(3, 3));

        //Act
        Snake.AjouterGateau(ref partie);

        //Assert
        Assert.IsFalse(Snake.VerifierCasePasVide(partie.Serpent, partie.PositionGateau, true));


    }
    /*************************************************
                Test AvancerSerpent()
    **************************************************/
    
    /// <summary>
    /// test de collision
    /// on verifie que la partie s'arrête quand
    /// le serpent fonce dans le mur du haut
    /// </summary>
    [TestMethod]
    public void AvancerSerpentCollisionMurHaut()
    {

        //Arrange
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();
        partie.Serpent.Add(new Snake.CaseDeJeu(5, 0));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, 2));
        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Haut;//on le fais avancer vers le haut 
        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        //Act
        Snake.AvancerSerpent(ref partie);

        //Assert
        Assert.IsFalse(partie.PartieEnCours);// il cogne le bord donc le jeu s'arrête
    }

    /// <summary>
    /// test de collision
    /// on verifie que la partie s'arrête quand
    /// le serpent fonce dans le mur du bas
    /// </summary>
    [TestMethod]
    public void AvancerSerpentCollisionMurBas()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();
        partie.Serpent.Add(new Snake.CaseDeJeu(5, Snake.HAUTEUR_TERRAIN - 1));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, Snake.HAUTEUR_TERRAIN - 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(5, Snake.HAUTEUR_TERRAIN - 3));
        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Bas;
        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        //Act
        Snake.AvancerSerpent(ref partie);

        //Assert
        Assert.IsFalse(partie.PartieEnCours);
    }

    /// <summary>
    /// test de collision
    /// on verifie que la partie s'arrête quand
    /// le serpent fonce dans le mur de droite
    /// </summary>
    [TestMethod]
    public void AvancerSerpentCollisionMurDroite()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();
        partie.Serpent.Add(new Snake.CaseDeJeu(Snake.LARGEUR_TERRAIN - 1, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(Snake.LARGEUR_TERRAIN - 2, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(Snake.LARGEUR_TERRAIN - 3, 2));
        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Droite;
        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        //Act
        Snake.AvancerSerpent(ref partie);

        //Assert
        Assert.IsFalse(partie.PartieEnCours);//cogne le bord donc le jeu s'arrête
    }

    /// <summary>
    /// test de collision
    /// on verifie que la partie s'arrête quand
    /// le serpent fonce dans le mur de gauche
    /// </summary>
    [TestMethod]
    public void AvancerSerpentCollisionMurGauche()
    {
        //Arrange
        Snake.Partie partie = new();
        partie.Serpent = new List<Snake.CaseDeJeu>();

        partie.Serpent.Add(new Snake.CaseDeJeu(0, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(1, 2));
        partie.Serpent.Add(new Snake.CaseDeJeu(2, 2));

        partie.PartieEnCours = true;
        partie.DirectionSerpent = Snake.Directions.Gauche;
        partie.PositionGateau = new Snake.CaseDeJeu(10, 5);

        //Act
        Snake.AvancerSerpent(ref partie);

        //Assert
        Assert.IsFalse(partie.PartieEnCours);//cogne le bord donc le jeu s'arrête
    }

    /// <summary>
    /// test de collision
    /// on verifie que la partie s'arrête quand
    /// le serpent se mord lui même
    /// </summary>
    [TestMethod]
    public void AvancerSerpentCollisionLuiMeme()
    {
        //Arrange
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

        //Act
        Snake.AvancerSerpent(ref partie);

        //Assert
        Assert.IsFalse(partie.PartieEnCours);//colision donc le jeu s'arrête
    }

    /// <summary>
    /// test de gâteau
    /// on verifie que le serpent grandit
    /// que le score s'incrémente
    /// qu'on enlève pas la queue
    /// et que la vitesse se réinitialise
    /// quand il mange un gâteau
    /// </summary>
    [TestMethod]
    public void AvancerSerpentMangeGateau()
    {
        //Arrange
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

        //Act
        Snake.AvancerSerpent(ref partie);

        //Assert
        Assert.AreEqual(5, partie.Score);//le score s'incrémente
        Assert.AreEqual(Snake.VITESSE_MIN, partie.Vitesse);//la vitesse retombe à la vitesse minimal
        Assert.AreEqual(5, partie.Serpent.Count);//1 anneau s'ajoute à la liste serpent 
        Assert.IsFalse(partie.EnleverQueue);//on enlève pas la queue car le serpent grandi 


    }

    /// <summary>
    /// on vérifie que les valeurs restent les même
    /// que la queue s'enlève
    /// et que la vitesse accélère quand le serpent ne mange pas de gâteau
    /// </summary>
    [TestMethod]
    public void AvancerSerpentMangePasGateau()
    {
        //Arrange
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

        //Act
        Snake.AvancerSerpent(ref partie);

        //Assert
        Assert.AreEqual(26, partie.Vitesse);//vitesse s'incrémente
        Assert.AreEqual(4, partie.Score);//score ne bouge pas
        Assert.IsTrue(partie.EnleverQueue);//on enlève la queue pour que le serpent garde la meme taille
                                           // vu qu'on ajoute une nouvelle tête à chaque fois qu'il avance 
    }



}