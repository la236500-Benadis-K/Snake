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
    static readonly string DBNAME_TEST = "DbTestLAxxxxxx"; // mettre son numéro d'étudiant

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
    }


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
}