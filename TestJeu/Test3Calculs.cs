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
    }

    // A COMPLETER

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
}