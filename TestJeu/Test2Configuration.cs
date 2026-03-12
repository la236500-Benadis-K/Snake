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
        // A COMPLETER
    }

    // A COMPLETER
}