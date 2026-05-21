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
    
    /// <summary>
    /// sert à créer la DB
    /// </summary>
    [TestMethod]
    public void CreerDBOK()
    {
        //Arrange & Act
        InitTestDB();

        //Assert
        Assert.IsTrue(true);
    }

    /// <summary>
    /// on rentre un nom de db invalide
    /// </summary>
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

    /// <summary>
    /// on essaye de créer la DB deux foix
    /// </summary>
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


/// <summary>
/// on efface la DB
/// </summary>
    [TestMethod]
    public void EffacerDBOK()
    {
        //Arrange & Act
        InitTestDB();
        bool resultat = Snake.EffacerDB(out string messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    /// <summary>
    /// on met un nom de DB invalide
    /// </summary>
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

    /// <summary>
    /// on essaye d'effacer la DB deux fois
    /// </summary>
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

    /// <summary>
    /// sert à vérifier le pseudo
    /// on met un pseudo null
    /// </summary>
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

    /// <summary>
    /// on met un pseudo trop court
    /// </summary>
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

    /// <summary>
    /// on met un pseudo trop long
    /// </summary>
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

    /// <summary>
    /// on met un pseudo
    /// avec un caractère invalide
    /// </summary>
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

    /// <summary>
    /// on met un pseudo
    /// avec un espace
    /// </summary>
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

    /// <summary>
    /// on met un pseudo avec un chiffre
    /// </summary>
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

    /// <summary>
    /// on met un pseudo valide
    /// </summary>
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

    /// <summary>
    /// on met un pseudo avec un trait d'union
    /// </summary>
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

    /// <summary>
    /// sert à ajouter un joueur
    /// on essaye d'ajouter un joueur
    /// avec un pseudo invalide
    /// </summary>
    [TestMethod]
    public void AjouterJoueurPseudoInvalide()
    {
        //Arrange & Act
        InitTestDB();
        bool resultat = Snake.AjouterJoueur("kh", out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
    }

    /// <summary>
    /// on ajoute un joueur
    /// avec un pseudo valide
    /// </summary>
    [TestMethod]
    public void AjouterJoueurOK()
    {
        //Arrange & Act
        InitTestDB();
        bool resultat = Snake.AjouterJoueur("kheireddine", out string messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    /// <summary>
    /// on essaye d'entrer un joueur déjà existent
    /// </summary>
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

    /// <summary>
    /// on essaye d'entrer un joueur
    /// dans un db invalide
    /// </summary>
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

    /// <summary>
    /// sert à ajouter un score
    /// on essaye d'ajouter un score
    /// avec un pseudo invalide
    /// </summary>
    [TestMethod]
    public void AjouterScorePseudoInvalide()
    {
        //Arrange & Act 
        InitTestDB();
        bool resultat = Snake.AjouterScore("kh", 100, out string messageDerreur);

        //Assert
        Assert.IsFalse(resultat);
    }

    /// <summary>
    /// on rentre un joueur déjà existant
    /// </summary>
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

    /// <summary>
    /// on enregistre un score pour un nouveau joueur
    /// </summary>
    [TestMethod]
    public void AjouterScoreNouveauJoueur()
    {
        //Arrange & Act 
        InitTestDB();
        bool resultat = Snake.AjouterScore("kheireddine", 30, out string messageDerreur);

        //Assert
        Assert.IsTrue(resultat, messageDerreur);
    }

    /// <summary>
    /// on essaye d'enregistrer un score
    /// dans une db invalide
    /// </summary>
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

    /// <summary>
    /// on met une liste vide
    /// </summary>
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

    /// <summary>
    /// test lireScores
    /// on vérifie que la liste de scores
    /// n'est pas vide
    /// </summary>
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

    /// <summary>
    /// test pour lire les scores
    /// on vérifie que la limite est respectée 
    /// </summary>
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

    /// <summary>
    /// test pour lire les scores
    /// on met un nom de DB invalide 
    /// </summary>
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