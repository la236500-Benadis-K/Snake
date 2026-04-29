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

        LARGEUR_TERRAIN = 30;
        HAUTEUR_TERRAIN = 20;
        GATEAU_DESSIN = "⬤ ";

        COULEUR_GATEAU = ConsoleColor.White;
        COULEUR_SERPENT = ConsoleColor.White;
        COULEUR_BORD = ConsoleColor.White;
        COULEUR_FOND = ConsoleColor.Black;
        COULEUR_TITRE = ConsoleColor.White;
        COULEUR_TETE_SERPENT = ConsoleColor.White;

        CalculerParametres();

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
        ChargerConfigurationParDefaut();

        try

        {
            //s'arrete si le fichier n'existe pas
            if (!File.Exists(nomFichier))
            {
                return;
            }



            string[] lignes = File.ReadAllLines(nomFichier);


            foreach (string ligne in lignes)
            {
                //si une ligne est vide ou ne contient pas de "=" on l'ignore avec le continue
                if (string.IsNullOrWhiteSpace(ligne) || !ligne.Contains("="))
                {
                    continue;
                }



                string[] partie = ligne.Split('=');
                if (partie.Length < 2)//si il y'a moins de 2 valeurs on ignore la ligne
                {
                    continue;

                }

                string cle = partie[0].Trim().ToUpper();
                string valeur = partie[1].Trim();

                switch (cle)
                {
                    //si les conversion échouent les valeurs par défaut sont utilisée
                    //on appelle ChargerConfigurationDefaut() au début
                    case "LARGEUR_JEU":

                        if (int.TryParse(valeur, out int l))
                        {
                            LARGEUR_TERRAIN = l;
                        }

                        break;

                    case "HAUTEUR_JEU":
                        if (int.TryParse(valeur, out int h))
                        {
                            HAUTEUR_TERRAIN = h;
                        }
                        break;

                    case "GATEAUX":
                        if (!string.IsNullOrEmpty(valeur))
                        {
                            GATEAU_DESSIN = valeur[0].ToString() + " ";
                        }

                        break;

                    //renvoie les couleurs par défaut
                    //si la conversion a échoué
                    case "COULEUR_SERPENT":
                        COULEUR_SERPENT = ConvertirCouleur(valeur, COULEUR_SERPENT);
                        break;

                    case "COULEUR_GATEAU":
                        COULEUR_GATEAU = ConvertirCouleur(valeur, COULEUR_GATEAU);
                        break;
                    case "COULEUR_TITRE":
                        COULEUR_TITRE = ConvertirCouleur(valeur, COULEUR_TITRE);
                        break;

                    case "COULEUR_TETE_SERPENT":
                        COULEUR_TETE_SERPENT = ConvertirCouleur(valeur, COULEUR_TETE_SERPENT);
                        break;

                    case "COULEUR_BORD":
                        COULEUR_BORD = ConvertirCouleur(valeur, COULEUR_BORD);
                        break;

                    case "COULEUR_FOND":
                        COULEUR_FOND = ConvertirCouleur(valeur, COULEUR_FOND);
                        break;
                }

            }

            CalculerParametres();

        }
        catch (Exception)
        {

        }
    }
}