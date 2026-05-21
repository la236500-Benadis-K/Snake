using Jeu;
using MySqlConnector;

namespace TestJeu;

/// <summary>
/// Tests de la base de données
/// </summary>
[TestClass]
[DoNotParallelize]
public class TestDB
{
    static readonly string DBNAME_TEST = "DbTestLA236500"; // mettre son numéro d'étudiant

    [TestInitialize()]
    public void InitAllTest()
    {
        Snake.DBNAME = DBNAME_TEST;
    }

    /// <summary>
    /// Sert à remettre la DB de test à zéro avant la plupart des tests
    /// </summary>
    private static void InitTestDB()
    {
        bool resultat = Snake.EffacerDB(out string messageDerreur);
        Assert.IsTrue(resultat, "Effacer DB : " + messageDerreur);
        resultat = Snake.CreerDB(out messageDerreur);
        // A COMPLETER

        Assert.IsTrue(resultat, "Créer DB : " + messageDerreur);
    }

    /******************************************************
        TEST POUR CRÉER ET EFFACER LA DB
    ******************************************************/
    [TestMethod]
    public void CreerDBOK()
    {
        //Arrange & Act
        InitTestDB();

        //Assert
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void CreerDBErreur()
    {
        //Arrange
        Snake.DBNAME = "Db invalide";

        //Act
        bool resultat = Snake.CreerDB(out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    [TestMethod]
    public void CreerDBDeuxFois()
    {
        //Arrange & Act
        InitTestDB();
        bool resultat = Snake.CreerDB(out string messageDerreur);
        resultat = Snake.CreerDB(out messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }



    [TestMethod]
    public void EffacerDBOK()
    {
        //Arrange & Act
        InitTestDB();
        bool resultat = Snake.EffacerDB(out string messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void EffacerDBErreur()
    {
        //Arrange
        Snake.DBNAME = "Db invalide";

        //Act
        bool resultat = Snake.EffacerDB(out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    [TestMethod]
    public void EffacerDBDeuxFois()
    {
        //Arrange & Act
        InitTestDB();
        Snake.EffacerDB(out string messageDerreur);
        bool resultat = Snake.EffacerDB(out messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    /******************************************************
        TEST POUR VERIFIER LE PSEUDO
    ******************************************************/

    [TestMethod]
    public void VerifierPseudoNull()
    {
        //Arrange
        string pseudo = null;

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoTropCourt()
    {
        //Arrange
        string pseudo = "kh";

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoTropLong()
    {
        //Arrange
        string pseudo = "kheireddineBenadisHelha";

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Arrange
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoCaractereInvalide()
    {
        //Arrange
        string pseudo = "kh+ben";

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoEspace()
    {
        //Arrange
        string pseudo = "kh ben";

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoChiffre()
    {
        //Arrange
        string pseudo = "kh1273";

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Asssert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoValide()
    {
        //Arrange
        string pseudo = "kheireddine";

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Assert
        Assert.IsTrue(resultat);
    }

    [TestMethod]
    public void VerifierPseudoValideTraitUnion()
    {
        //Arrange
        string pseudo = "kh-ben";

        //Act
        bool resultat = Snake.VerifierPseudo(pseudo);

        //Assert
        Assert.IsTrue(resultat);
    }

    /******************************************************
        TEST POUR AJOUTERJOUEUR()
    ******************************************************/

    [TestMethod]
    public void AjouterJoueurPseudoInvalide()
    {
        //Arrange & Act
        InitTestDB();
        bool resultat = Snake.AjouterJoueur("kh", out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void AjouterJoueurOK()
    {
        //Arrange & Act
        InitTestDB();
        bool resultat = Snake.AjouterJoueur("kheireddine", out string messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void AjouterJoueurDejaExistant()
    {
        //Arrange & Act
        InitTestDB();
        Snake.AjouterJoueur("kheireddine", out string messageDerreur);
        bool resultat = Snake.AjouterJoueur("kheireddine", out messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void AjouterJoueurErreurDB()
    {
        //Arrange
        Snake.DBNAME = "db invalide";
        bool resultat = Snake.AjouterJoueur("kheireddine", out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    /******************************************************
            TEST POUR AJOUTERSCORE()
    ******************************************************/

    [TestMethod]
    public void AjouterScorePseudoInvalide()
    {
        //Arrange & Act 
        InitTestDB();
        bool resultat = Snake.AjouterScore("kh", 100, out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void AjouterScoreJoueurExistant()
    {
        //Arrange & Act
        InitTestDB();
        Snake.AjouterScore("kheireddine", 20, out string messageDerreur);
        bool resultat = Snake.AjouterScore("kheireddine", 25, out messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void AjouterScoreNouveauJoueur()
    {
        //Arrange & Act 
        InitTestDB();
        bool resultat = Snake.AjouterScore("kheireddine", 30, out string messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void AjouterScoreErreurDB()
    {
        //Arrange & Act
        Snake.DBNAME = "db invalide";
        bool resultat = Snake.AjouterScore("kheireddine", 30, out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    /******************************************************
            TEST POUR LIRESCORES()
    ******************************************************/

    [TestMethod]
    public void LireScoresListeVide()
    {
        //Arrange & Act
        InitTestDB();
        List<Snake.ScorePartie>? scores = Snake.LireScores(10, out string messageDerreur);

        //Assert
        Assert.IsNotNull(scores);
        Assert.AreEqual(0, scores.Count);
    }

    [TestMethod]
    public void LireScoresAvecScores()
    {
        //Arrange & Act
        InitTestDB();
        Snake.AjouterScore("kheireddine", 30, out string messageDerreur);
        Snake.AjouterScore("benadis", 20, out messageDerreur);
        List<Snake.ScorePartie>? scores = Snake.LireScores(10, out messageDerreur);

        //Assert
        Assert.IsNotNull(scores);
        Assert.AreEqual(2, scores.Count);
    }

    [TestMethod]
    public void LireScoresLimiteOK()
    {
        //Arrange & Act
        InitTestDB();
        Snake.AjouterScore("kheireddine", 30, out string messageDerreur);
        Snake.AjouterScore("benadis", 20, out messageDerreur);
        Snake.AjouterScore("helha", 25, out messageDerreur);
        List<Snake.ScorePartie>? scores = Snake.LireScores(2, out messageDerreur);

        //Assert
        Assert.IsNotNull(scores);
        Assert.AreEqual(2, scores.Count);
    }

    [TestMethod]
    public void LireScoresErreurDB()
    {
        //Arrange
        Snake.DBNAME = "db invalide";

        //Act
        List<Snake.ScorePartie>? scores = Snake.LireScores(10, out string messageDerreur);

        //Assert
        Assert.IsNull(scores);
    }

}