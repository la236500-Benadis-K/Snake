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
        InitTestDB();
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void CreerDBErreur()
    {
        Snake.DBNAME = "Db invalide";
        bool resultat = Snake.CreerDB(out string messageDerreur);
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    [TestMethod]
    public void CreerDBDeuxFois()
    {
        InitTestDB();
        bool resultat = Snake.CreerDB(out string messageDerreur);
        resultat = Snake.CreerDB(out messageDerreur);
        Assert.IsTrue(resultat, messageDerreur);
    }



    [TestMethod]
    public void EffacerDBOK()
    {
        InitTestDB();
        bool resultat = Snake.EffacerDB(out string messageDerreur);
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void EffacerDBErreur()
    {
        Snake.DBNAME = "Db invalide";
        bool resultat = Snake.EffacerDB(out string messageDerreur);
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    [TestMethod]
    public void EffacerDBDeuxFois()
    {
        InitTestDB();
        Snake.EffacerDB(out string messageDerreur);
        bool resultat = Snake.EffacerDB(out messageDerreur);
        Assert.IsTrue(resultat, messageDerreur);
    }

    /******************************************************
        TEST POUR VERIFIER LE PSEUDO
    ******************************************************/

    [TestMethod]
    public void VerifierPseudoNull()
    {

        string pseudo = null;

        bool resultat = Snake.VerifierPseudo(pseudo);


        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoTropCourt()
    {
        string pseudo = "kh";

        bool resultat = Snake.VerifierPseudo(pseudo);

        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoTropLong()
    {
        string pseudo = "kheireddineBenadisHelha";

        bool resultat = Snake.VerifierPseudo(pseudo);

        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoCaractereInvalide()
    {
        string pseudo = "kh+ben";

        bool resultat = Snake.VerifierPseudo(pseudo);

        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoEspace()
    {
        string pseudo = "kh ben";

        bool resultat = Snake.VerifierPseudo(pseudo);

        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoChiffre()
    {
        string pseudo = "kh1273";

        bool resultat = Snake.VerifierPseudo(pseudo);

        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void VerifierPseudoValide()
    {
        string pseudo = "kheireddine";

        bool resultat = Snake.VerifierPseudo(pseudo);

        Assert.IsTrue(resultat);
    }

    [TestMethod]
    public void VerifierPseudoValideTraitUnion()
    {
        string pseudo = "kh-ben";

        bool resultat = Snake.VerifierPseudo(pseudo);

        Assert.IsTrue(resultat);
    }

    /******************************************************
        TEST POUR AJOUTERJOUEUR()
    ******************************************************/

    [TestMethod]
    public void AjouterJoueurPseudoInvalide()
    {
        InitTestDB();
        bool resultat = Snake.AjouterJoueur("kh", out string messageDerreur);
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void AjouterJoueurOK()
    {
        InitTestDB();
        bool resultat = Snake.AjouterJoueur("kheireddine", out string messageDerreur);
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void AjouterJoueurDejaExistant()
    {
        InitTestDB();
        Snake.AjouterJoueur("kheireddine", out string messageDerreur);
        bool resultat = Snake.AjouterJoueur("kheireddine", out messageDerreur);
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void AjouterJoueurErreurDB()
    {
        Snake.DBNAME = "db invalide";
        bool resultat = Snake.AjouterJoueur("kheireddine", out string messageDerreur);
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    /******************************************************
            TEST POUR AJOUTERSCORE()
    ******************************************************/

    [TestMethod]
    public void AjouterScorePseudoInvalide()
    {
        InitTestDB();
        bool resultat = Snake.AjouterScore("kh", 100, out string messageDerreur);
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void AjouterScoreJoueurExistant()
    {
        InitTestDB();
        Snake.AjouterScore("kheireddine", 20, out string messageDerreur);
        bool resultat = Snake.AjouterScore("kheireddine", 25, out messageDerreur);
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void AjouterScoreNouveauJoueur()
    {
        InitTestDB();
        bool resultat = Snake.AjouterScore("kheireddine", 30, out string messageDerreur);
        Assert.IsTrue(resultat, messageDerreur);
    }

    [TestMethod]
    public void AjouterScoreErreurDB()
    {
        Snake.DBNAME = "db invalide";
        bool resultat = Snake.AjouterScore("kheireddine", 30, out string messageDerreur);
        Assert.IsFalse(resultat);
        Snake.DBNAME = DBNAME_TEST;
    }

    /******************************************************
            TEST POUR LIRESCORES()
    ******************************************************/

    [TestMethod]
    public void LireScoresListeVide()
    {
        InitTestDB();
        List<Snake.ScorePartie>? scores = Snake.LireScores(10, out string messageDerreur);
        Assert.IsNotNull(scores);
        Assert.AreEqual(0, scores.Count);
    }

    [TestMethod]
    public void LireScoresAvecScores()
    {
        InitTestDB();
        Snake.AjouterScore("kheireddine", 30, out string messageDerreur);
        Snake.AjouterScore("benadis", 20, out messageDerreur);
        List<Snake.ScorePartie>? scores = Snake.LireScores(10, out messageDerreur);
        Assert.IsNotNull(scores);
        Assert.AreEqual(2, scores.Count);
    }

    [TestMethod]
    public void LireScoresLimiteOK()
    {
        InitTestDB();
        Snake.AjouterScore("kheireddine", 30, out string messageDerreur);
        Snake.AjouterScore("benadis", 20, out messageDerreur);
        Snake.AjouterScore("helha", 25, out messageDerreur);
        List<Snake.ScorePartie>? scores = Snake.LireScores(2, out messageDerreur);
        Assert.IsNotNull(scores);
        Assert.AreEqual(2, scores.Count);
    }

    [TestMethod]
    public void LireScoresErreurDB()
    {
        Snake.DBNAME = "db invalide";
        List<Snake.ScorePartie>? scores = Snake.LireScores(10, out string messageDerreur);
        Assert.IsNull(scores);
    }

}