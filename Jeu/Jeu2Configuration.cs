using System.Globalization;

namespace Jeu;

public partial class Snake
{
    /// <summary>
    /// Convertit une chaîne de caractère en couleur de la Console
    /// La valeur par défaut est utilisée en cas d'erreur
    /// </summary>
    /// <param name="chaine">Couleur sous forme d'une chaîne de caractères</param>
    /// <param name="defaut">Couleur par défaut</param>
    /// <returns>Couleur de Console</returns>
    public static ConsoleColor ConvertirCouleur(string chaine, ConsoleColor defaut)
    {
        // A COMPLETER

        if (Enum.TryParse(chaine, true, out ConsoleColor couleur))
        {
            return couleur;
        }
        return defaut;
    }

    /// <summary>
    /// Calcule les valeurs des paramètres qui dépendent de la configuration
    /// Cette fonction est appelée lors qu'une configuration a été lue depuis un fichier,
    /// de façon à mettre à jour les autres paramètres dépendant de la configuration
    /// Par exemple: l'image du gâteau est initialisée avec le première image de gâteau lue depuis la configuration
    /// </summary>
    public static void CalculerParametres()
    {
        // A COMPLETER
        LARGEUR_ECRAN = LARGEUR_TERRAIN * 2;
        HAUTEUR_ECRAN = HAUTEUR_TERRAIN;
    }

    /// <summary>
    /// Remplit les paramètres avec la configuration par défaut
    /// Cette fonction est appelée afin d'obtenir des valeurs par défaut pour tous les paramètres
    /// - au début de jeu
    /// - lorsqu'une configuration ne peut pas être lue depuis un fichier (exception)
    /// </summary>
    public static void ChargerConfigurationParDefaut()
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - CalculerParametres()
    }

    /// <summary>
    /// Lit la configuration dans un fichier
    /// et change les paramètres du jeu correspondant à ce qui est lu
    /// (dimension du jeu, couleur, etc.)
    /// 
    /// En cas d'erreur, on utilise les valeurs par défaut
    /// 
    /// Exemple de fichier de configuration:
    /// LARGEUR_JEU=30
    /// HAUTEUR_JEU=20
    /// GATEAUX=⬤⚉✪☻◆◉
    /// COULEUR_SERPENT=DarkRed
    /// COULEUR_GATEAU=Cyan
    /// COULEUR_TITRE=White
    /// COULEUR_BORD=Gray
    /// COULEUR_FOND=Black
    /// 
    /// </summary>
    /// <param name="nomFichier">Nom de fichier contenant la configuration</param>
    public static void LireConfiguration(string nomFichier)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - ChargerConfigurationParDefaut()
        // - CalculerParametres()

        // MATIERE A UTILISER
        // - lecture des lignes du fichier 
        // - découpage d'une ligne pour extraire la clé et la valeur
        // - switch
    }
}