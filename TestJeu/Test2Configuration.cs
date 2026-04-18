using Jeu;

namespace TestJeu;

/// <summary>
/// Tests de lecture de la configuration
/// </summary>
[TestClass]
[DoNotParallelize]
public class TestConfiguration
{
    /// <summary>
    /// Tests de conversion en couleur d'une chaîne qui fonctionne
    /// </summary>
    [TestMethod]
    public void ConversionCouleurOK()
    {
        ConsoleColor couleur = Snake.ConvertirCouleur("Black", ConsoleColor.White);
        Assert.AreEqual(ConsoleColor.Black, couleur);
    }

    [TestMethod]
    public void ConversionCouleurInvalide()
    {
        ConsoleColor couleur = Snake.ConvertirCouleur("nul", ConsoleColor.White);
        Assert.AreEqual(ConsoleColor.White, couleur);
    }

    [TestMethod]
    public void ConversionCouleurCasse()
    {
        ConsoleColor couleur = Snake.ConvertirCouleur("black", ConsoleColor.White);
        Assert.AreEqual(ConsoleColor.Black, couleur);
    }
}