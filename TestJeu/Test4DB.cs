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

    // A COMPLETER
}