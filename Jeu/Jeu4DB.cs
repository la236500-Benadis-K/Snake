using System.Collections.Generic;
using MySqlConnector;

namespace Jeu;

public partial class Snake
{
    // Noms de base de données pour 
    // - la valeur par défaut est pour la production
    // - la valeur pour les tests doit être changée par les tests
    // Rappel: le nom DOIT comporter le numéro d'étudiant LAxxxxxx dans les deux cas !
    public static string DBNAME = "DbLA236500"; // Mettre son numéro d'étudiant

    //fonction pour se connecter à la db
    private static string GetConnectionString()
    {
        return $"Server=127.0.0.1;Database={DBNAME};Uid=root;Pwd=;";
    }

    /// <summary>
    /// Vérification d'un pseudo
    /// - Il ne peut être  null
    /// - sa longueur est entre LONGUEUR_MIN_PSEUDO et LONGUEUR_MAX_PSEUDO
    /// - Il contient uniquement des lettres ou un trait d'union
    /// </summary>
    /// <param name="pseudoAVerifier">Pseudo à vérifier</param>
    /// <returns>true si le pseudo est correct, false sinon</returns>
    public static bool VerifierPseudo(string? pseudoAVerifier)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - parcours des chaînes de caractères

        //vérifie que le pseudo n'est pas null
        if (pseudoAVerifier == null)
        {
            return false;
        }

        //si le pseudo ne contient pas entre 3 et 20 caractère on return false
        if (pseudoAVerifier.Length < LONGUEUR_MIN_PSEUDO || pseudoAVerifier.Length > LONGUEUR_MAX_PSEUDO)
        {
            return false;
        }


        foreach (char c in pseudoAVerifier)
        {
            //si le caractère n'est pas une lettre ou un trait d'union on return false
            if (!char.IsLetter(c) && c != '-')
            {

                return false;
            }
        }


        return true;
    }

    /// <summary>
    /// Efface la base de données. C'est principalement utilisé pour les tests unitaires, 
    /// afin de démarrer les tests avec une base de données sans contenu. 
    /// En production (vrai jeu), cela ne se fait qu'occasionnellement, 
    /// car on veut conserver les scores et les joueurs d'une manière permanente.
    /// </summary>
    /// <param name="messageDerreur">Pour renvoyer un texte explicatif s'il y a un erreur</param>
    /// <returns>Renvoie true si OK, false s'il y a une erreur</returns>
    public static bool EffacerDB(out string messageDerreur)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - utilisation de base de données
        // - gestion d'erreur
        // - out

        try
        {
            string connSansDB = $"Server=127.0.0.1;Uid=root;Pwd=;";
            using (MySqlConnection connexion = new MySqlConnection(connSansDB))
            {
                connexion.Open();
                string query = $@"DROP DATABASE IF EXISTS {DBNAME};";
                using (MySqlCommand cmd = new MySqlCommand(query, connexion))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            messageDerreur = "Base de données effacée avec succès.";
            return true;
        }
        catch (Exception e)
        {
            messageDerreur = "Erreur lors de l'effacement : " + e.Message;
            return false;
        }
    }

    /// <summary>
    /// Créer la base de données si elle n'existe pas
    /// C'est appelé au début de l'application et avant chaque test sur les bases de données
    /// </summary>
    /// <param name="messageDerreur">Pour renvoyer un texte explicatif s'il y a un erreur</param>
    /// <returns>Renvoie true si OK, false s'il y a une erreur</returns>
    public static bool CreerDB(out string messageDerreur)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - utilisation de base de données
        // - gestion d'erreur
        // - out

        try
        {
            // Connexion SANS DB pour créer la DB
            string connSansDB = $"Server=127.0.0.1;Uid=root;Pwd=;";
            using (MySqlConnection connexion = new MySqlConnection(connSansDB))
            {
                connexion.Open();
                string creerDB = $"CREATE DATABASE IF NOT EXISTS {DBNAME};";
                using (MySqlCommand cmd = new MySqlCommand(creerDB, connexion))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            using (MySqlConnection connexion = new MySqlConnection(GetConnectionString()))
            {
                connexion.Open();

                // Le @ devant les guillemets permet d'écrire sur plusieurs lignes en C#, c'est plus propre !
                string requette = @"
                    CREATE TABLE IF NOT EXISTS Joueur (
                        Id_joueur INT AUTO_INCREMENT PRIMARY KEY,
                        Pseudo VARCHAR(20) NOT NULL UNIQUE
                    );

                    CREATE TABLE IF NOT EXISTS Score (
                        Id_score INT AUTO_INCREMENT PRIMARY KEY,
                        Id_joueur INT NOT NULL,
                        Points INT NOT NULL,
                        CONSTRAINT fk_score_joueur FOREIGN KEY (Id_joueur) REFERENCES Joueur(Id_joueur) ON DELETE CASCADE
                    );";

                using (MySqlCommand cmd = new MySqlCommand(requette, connexion))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            messageDerreur = "Tables créées avec succès.";
            return true;
        }
        catch (Exception e)
        {
            messageDerreur = "Erreur lors de la création des tables : " + e.Message;
            return false;
        }
    }

    /// <summary>
    /// Renvoie l'identifiant d'un joueur s'il existe dans la DB ou -1 s'il n'existe pas
    /// C'est une sous-fonction, et en cas d'exception, c'est l'appelant qui la gèrera
    /// </summary>
    /// <param name="connexion">Connexion à la DB (provient de la fonction appelante)</param>
    /// <param name="pseudo">Pseudo du joueur</param>
    /// <returns>Renvoie l'ID du joureur (clé primaire) ou -1 s'il n'existe pas</returns>
    private static int LireIDJoueur(MySqlConnection connexion, string pseudo)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - utilisation de base de données
        // - out

        string requette = "SELECT Id_joueur FROM Joueur WHERE Pseudo = @pseudo";

        using (MySqlCommand commande = new MySqlCommand(requette, connexion))

        {
            commande.Parameters.AddWithValue("@pseudo", pseudo);

            object resultat = commande.ExecuteScalar();

            if (resultat == null)
            {
                return -1;
            }

            return Convert.ToInt32(resultat);

        }


    }

    /// <summary>
    /// Ajoute un nouveau joueur dans la base de donnée, si les paramètres sont valides
    /// et si le pseudo n'existe pas déjà
    /// 
    /// Utilise les fonctions suivantes :
    /// - VerifierPseudo
    /// - LireIDJoueur pour s'assurer qu'il n'existe pas déjà
    /// </summary>
    /// <param name="pseudo">Le pseudo du joueur à ajouter</param>
    /// <param name="messageDerreur">Pour renvoyer un texte explicatif s'il y a un erreur</param>
    /// <returns>Renvoie true si le joueur est ajouté ou false et un message d'erreur s'il existait déjà</returns>
    public static bool AjouterJoueur(string? pseudo, out string messageDerreur)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - VerifierPseudo()
        // - LireIDJoueur()

        // MATIERE A UTILISER
        // - utilisation de base de données
        // - gestion d'erreur
        // - out



        //vérifie le pseudo
        if (!VerifierPseudo(pseudo))
        {
            messageDerreur = "pseudo invalide";
            return false;
        }

        try
        {
            using (MySqlConnection connexion = new MySqlConnection(GetConnectionString()))
            {
                connexion.Open();

                //regarde si le joueur est dans la db
                int idJoueur = LireIDJoueur(connexion, pseudo);

                if (idJoueur != -1)
                {
                    messageDerreur = $"Le joueur '{pseudo}' existe déjà.";
                    return false;
                }

                //on l'ajoute dans la table
                string requete = "INSERT INTO Joueur (Pseudo) VALUES (@pseudo)";

                using (MySqlCommand cmd = new MySqlCommand(requete, connexion))
                {
                    cmd.Parameters.AddWithValue("@pseudo", pseudo);
                    cmd.ExecuteNonQuery();
                }
            }

            messageDerreur = "Joueur ajouté dans la table";
            return true;
        }
        catch (Exception e)
        {
            messageDerreur = "Erreur lors de l'ajout du joueur : " + e.Message;
            return false;
        }
    }

    /// <summary>
    /// Ajoute un score à la base de données
    /// 
    /// Utilise:
    /// - LireIDJoueur pour vérifier que le joueur existe et obtenir son ID
    /// </summary>
    /// <param name="pseudo">Pseudos du joueur</param>
    /// <param name="points">Points obtenus</param>
    /// <param name="messageDerreur">Pour renvoyer un texte explicatif s'il y a un erreur</param>
    /// <returns>Renvoie true si OK, false s'il y a une erreur</returns>
    public static bool AjouterScore(string pseudo, int points, out string messageDerreur)
    {
        // A COMPLETER

        // FONCTION(S) A UTILISER: 
        // - VerifierPseudo()
        // - LireIDJoueur()
        // - AjouterJoueur()

        // MATIERE A UTILISER
        // - utilisation de base de données
        // - gestion d'erreur
        // - out

        // vérifie le pseudo
        if (!VerifierPseudo(pseudo))
        {
            messageDerreur = "Le pseudo est invalide.";
            return false;
        }

        try
        {
            using (MySqlConnection connexion = new MySqlConnection(GetConnectionString()))
            {
                connexion.Open();

                //regarde si le joueur existe déjà
                int idJoueur = LireIDJoueur(connexion, pseudo);

                //si le joueur n'existe pas on le crée
                if (idJoueur == -1)
                {
                    
                    connexion.Close();

                    //si l'ajout du joueur ne fonctionne pas on return false
                    if (!AjouterJoueur(pseudo, out messageDerreur))
                    {
                        return false;
                    }

                    // on récupère l'id du joueur
                    connexion.Open();
                    idJoueur = LireIDJoueur(connexion, pseudo);
                }

                // on ajoute le score dans la table Score
                string requete = "INSERT INTO Score (Id_joueur, Points) VALUES (@idJoueur, @points)";

                using (MySqlCommand cmd = new MySqlCommand(requete, connexion))
                {
                    cmd.Parameters.AddWithValue("@idJoueur", idJoueur);
                    cmd.Parameters.AddWithValue("@points", points);
                    cmd.ExecuteNonQuery();
                }
            }

            messageDerreur = "Score ajouté dans la table";
            return true;
        }
        catch (Exception e)
        {
            messageDerreur = "Erreur lors de l'enregistrement du score : " + e.Message;
            return false;
        }

    }

    /// <summary>
    /// Renvoie une liste de meilleurs scores
    /// </summary>
    /// <param name="nombreDeScores">Nombre maximum de scores à renvoyer</param>
    /// <param name="messageDerreur">Pour renvoyer un texte explicatif s'il y a un erreur</param>
    /// <returns>Une Liste typée de structures ScorePartie</returns>
    public static List<ScorePartie>? LireScores(int nombreDeScores, out string messageDerreur)
    {
        // A COMPLETER

        // MATIERE A UTILISER
        // - utilisation de base de données
        // - gestion d'erreur
        // - out
        // - création et remplissage d'une liste de structures ScorePartie

        throw new NotImplementedException();
    }
}
