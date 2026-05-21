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
        //Act
        ConsoleColor couleur = Snake.ConvertirCouleur("Black", ConsoleColor.White);

        //Assert
        Assert.AreEqual(ConsoleColor.Black, couleur);
    }

    /// <summary>
    /// Tests de conversion en couleur d'une chaîne invalide
    /// </summary>
    [TestMethod]
    public void ConversionCouleurInvalide()
    {
        //Act
        ConsoleColor couleur = Snake.ConvertirCouleur("nul", ConsoleColor.White);

        //Arrange
        Assert.AreEqual(ConsoleColor.White, couleur);
    }

    /// <summary>
    /// Tests de conversion en couleur de casse
    /// </summary>
    [TestMethod]
    public void ConversionCouleurCasse()
    {
        //Act
        ConsoleColor couleur = Snake.ConvertirCouleur("black", ConsoleColor.White);

        //Arrange
        Assert.AreEqual(ConsoleColor.Black, couleur);
    }


    /*****************************************************
        Test CalculerParametres()
    *****************************************************/
    /// <summary>
    /// calcul la largeur de l'écran
    /// par rapport à la taille du terrain
    /// </summary>
    [TestMethod]
    public void CalculerParametresLargeur()
    {
        //Arrange
        Snake.LARGEUR_TERRAIN = 30;

        //Act
        Snake.CalculerParametres();

        //Assert
        Assert.AreEqual(60, Snake.LARGEUR_ECRAN);
    }

    /// <summary>
    /// calcul la hauteur de l'écran 
    /// par rapport à la largeur de l'écran
    /// </summary>
    [TestMethod]
    public void CalculerParametresHauteur()
    {
        //Arrange
        Snake.HAUTEUR_TERRAIN = 20;

        //Act
        Snake.CalculerParametres();

        //Assert
        Assert.AreEqual(20, Snake.HAUTEUR_ECRAN);
    }


    /*****************************************************
         Test ChargerConfigurationParDefaut()
    *****************************************************/

    /// <summary>
    /// charge les configurations 
    /// par défaut
    /// </summary>
    [TestMethod]
    public void ChargerConfigurationParDefautOK()
    {
        //Arrange
        Snake.LARGEUR_TERRAIN = 10;
        Snake.HAUTEUR_TERRAIN = 5;
        Snake.COULEUR_FOND = ConsoleColor.Red;

        //Act
        Snake.ChargerConfigurationParDefaut();

        //Assert
        Assert.AreEqual(30, Snake.LARGEUR_TERRAIN);
        Assert.AreEqual(20, Snake.HAUTEUR_TERRAIN);
        Assert.AreEqual(ConsoleColor.Black, Snake.COULEUR_FOND);
        Assert.AreEqual(60, Snake.LARGEUR_ECRAN);
    }

    /*****************************************************
         Test LireConfiguration()
    *****************************************************/



    [TestInitialize]
    public void Setup()
    {
        Snake.ChargerConfigurationParDefaut();
    }

    /// <summary>
    /// Test que les configurations sont corrects 
    /// </summary>
    [TestMethod]
    public void TestConfigOK()
    {

        //Arrange
        string chemin = "../../../Config/configurationOK.config";

        //Act
        Snake.LireConfiguration(chemin);

        //Assert
        Assert.AreEqual(29, Snake.LARGEUR_TERRAIN);
        Assert.AreEqual(19, Snake.HAUTEUR_TERRAIN);
        Assert.AreEqual(ConsoleColor.DarkRed, Snake.COULEUR_SERPENT);
        Assert.AreEqual(ConsoleColor.Yellow, Snake.COULEUR_TETE_SERPENT);
        Assert.AreEqual("✪ ", Snake.GATEAU_DESSIN);
    }

    /// <summary>
    /// La largeur est remise par défaut  
    /// car elle dépasse la limite défini dans calculerParametre()
    /// ConvertirCouleur échoue et garde la couleur par défaut
    /// </summary>
    [TestMethod]
    public void TestConfigErreursValeurs()
    {

        //Arrange
        string chemin = "../../../Config/configurationErreursValeurs.config";

        //Act
        Snake.LireConfiguration(chemin);

        //Assert
        Assert.AreEqual(30, Snake.LARGEUR_TERRAIN);
        Assert.AreEqual(ConsoleColor.White, Snake.COULEUR_SERPENT);
        Assert.AreEqual(ConsoleColor.White, Snake.COULEUR_GATEAU);
    }

    /// <summary>
    /// La largeur est remise par défaut  
    /// car elle dépasse la limite défini dans calculerParametre()
    /// </summary>
    [TestMethod]
    public void TestConfigErreursCles()
    {
        //Arrange
        string chemin = "../../../Config/configurationErreursCles.config";

        //Act
        Snake.LireConfiguration(chemin);

        //Assert
        Assert.AreEqual(30, Snake.LARGEUR_TERRAIN); // largeur remise à 30
        Assert.AreEqual(ConsoleColor.White, Snake.COULEUR_SERPENT);
        Assert.AreEqual(ConsoleColor.Black, Snake.COULEUR_FOND);
    }

    /// <summary>
    /// La hauteur est remise par défaut  
    /// car la ligne est ignorée dans le fichier
    /// </summary>
    [TestMethod]
    public void TestLireConfigurationLignesIncorrecte()
    {
        //Arrange
        string chemin = "../../../Config/configurationLigneVideOuIncorrecte.config";
        Snake.ChargerConfigurationParDefaut();

        //Act
        Snake.LireConfiguration(chemin);


        //Assert
        Assert.AreEqual(29, Snake.LARGEUR_TERRAIN);
        Assert.AreEqual(Snake.HAUTEUR_TERRAIN, Snake.HAUTEUR_TERRAIN);
        Assert.AreEqual(ConsoleColor.DarkRed, Snake.COULEUR_SERPENT);
    }


    /// <summary>
    /// Vérifie que la fonction LireConfiguration() utilise la configuration par défaut 
    /// quand un fichier inexistant est donné
    /// </summary>

    [TestMethod]
    public void TestLireConfigurationFichierInexistant()
    {

        // Arrange
        Snake.ChargerConfigurationParDefaut();
        int largeurAttendue = Snake.LARGEUR_TERRAIN;
        string fichierInexistant = "../../../Config/fichierInexistant.config";

        // Act
        Snake.LireConfiguration(fichierInexistant);

        //Assert
        Assert.AreEqual(largeurAttendue, Snake.LARGEUR_TERRAIN);
    }


}