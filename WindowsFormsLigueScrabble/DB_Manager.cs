using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.X509;
using System.Text.RegularExpressions;


namespace WindowsFormsLigueScrabble
{
    internal class DB_Manager
    {
        string maConnexionString = "Server=localhost;Database=Ligue_Scrabble;Uid=SU_Scrabble;Pwd=ABCD";
        public int AjouterJoueurDansBD(Joueur nouveauJoueur)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Joueur (Code_Joueur, nom, pseudo, Fqcsf, Hide_Name) VALUES (@Code_Joueur, @Nom, @Pseudo, @Fqcsf, @CacherNom)", sqlConnexion))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@Code_Joueur", nouveauJoueur.CodeJoueur));
                            cmd.Parameters.Add(new MySqlParameter("@Nom", nouveauJoueur.Nom));
                            cmd.Parameters.Add(new MySqlParameter("@Pseudo", nouveauJoueur.Pseudo));
                            if (nouveauJoueur.Fqcsf.Replace(" ", "") == "" || nouveauJoueur.Fqcsf == null) cmd.Parameters.Add(new MySqlParameter("@FQCSF", DBNull.Value));
                            else cmd.Parameters.Add(new MySqlParameter("@FQCSF", nouveauJoueur.Fqcsf));
                            //cmd.Parameters.Add(new MySqlParameter("@NoFqcsf", nouveauJoueur.Fqcsf));
                            cmd.Parameters.Add(new MySqlParameter("@CacherNom", nouveauJoueur.CacherNom));

                        lignesAffectees = cmd.ExecuteNonQuery();
                        }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }
        public List<Joueur> ListerJoueursDansBD(string orderBy)
        {
            List<Joueur> joueurs = new List<Joueur>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Joueur " + orderBy, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Joueur monJoueur = new Joueur();
                                monJoueur.IdJoueur = (int)reader["Id_Joueur"];
                                monJoueur.CodeJoueur = (string)reader["Code_Joueur"];
                                monJoueur.Nom = (string)reader["Nom"];
                                monJoueur.Pseudo = (reader["Pseudo"].GetType() == typeof(DBNull)) ? " " : (string)reader["Pseudo"];
                                monJoueur.Fqcsf = (reader["FQCSF"].GetType() == typeof(DBNull)) ? " " : (string)reader["FQCSF"];
                                int cacherNom = (reader["hide_Name"].GetType() == typeof(DBNull)) ? 0 : (int)reader["hide_Name"];
                                monJoueur.CacherNom = cacherNom == 0 ? false : true;
                                joueurs.Add(monJoueur);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return joueurs;
                }
            }
            catch (Exception) { throw; }
        }

        internal int AjouterRencontreDansBD(Rencontre newRencontre)
        {
            //Créer une nouvelle session (recontre) avec seulement une date et heure
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int idNouvelleSession = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO session (Date_Session) VALUES (@Date_Session); SELECT LAST_INSERT_ID();", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Date_Session", newRencontre.DateNouvelle));
                        var idCree = cmd.ExecuteScalar().ToString();
                       bool ok = int.TryParse(idCree, out idNouvelleSession);
                    }
                    sqlConnexion.Close();

                    return idNouvelleSession;
                }
            }
            catch (Exception) { throw; }
        }
        internal List<Rencontre> ListerRencontresSeules(string orderBy)
        {
            // Dans la BD :    rencontre -> session

            List<Rencontre> rencontres = new List<Rencontre>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Session " + orderBy, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Rencontre maRencontre = new Rencontre();
                                maRencontre.IdSession = (int)reader["Id_Session"];
                                maRencontre.DateNouvelle = (DateTime)reader["Date_Session"];
                                maRencontre.DateDeJeu = (DateTime)reader["Date_Session"];
                                rencontres.Add(maRencontre);
                            }
                        }
                        sqlConnexion.Close();
                        return rencontres;
                    }
                }
            }
            catch (Exception) { throw; }
        }
        internal List<RencontresDataGrid> ListerRencontresDansBD(string orderBy)
        {
            // Affiche la compilation Session, Table, Partie, Nombre de joueurs
            // À compléter ultérieurement, afficher Gagnant et son pointage et si la partie est homologuée

            string commande_Lister_Session_Table_Game =
            "SELECT Session.*, _Table.No_Table, Game.*, _Table.Id_Table " +
            "FROM session " +
            "LEFT JOIN Session_Table_Game  as stj ON stj.Id_Session = session.Id_Session " +
            "LEFT JOIN _Table ON stj.Id_Table = _Table.Id_Table " +
            "LEFT JOIN Game ON stj.Id_Joute = Game.Id_Joute ";

            List<RencontresDataGrid> sessions = new List<RencontresDataGrid>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                List<string> listeJoueursDansJoute = new List<string>();

                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(commande_Lister_Session_Table_Game + orderBy, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RencontresDataGrid maSession = new RencontresDataGrid();
                                int idSession = (int)reader["Id_Session"];
                                DateTime dateSession = (DateTime)reader["Date_Session"];
                                Rencontre maRencontre = new Rencontre();
                                maRencontre.IdSession = idSession;
                                maRencontre.DateNouvelle = dateSession;
                                maRencontre.DateDeJeu = dateSession;
                                maSession.Session = maRencontre;
                                maSession.Id_Ronde = (reader["Id_Joute"].GetType() == typeof(DBNull)) ? 0 : (int)reader["Id_Joute"];
                                maSession.Ronde = (reader["No_Ronde"].GetType() == typeof(DBNull)) ? 0 : (int)reader["No_Ronde"];
                                maSession.Id_Table = (reader["Id_Table"].GetType() == typeof(DBNull)) ? 0 : (int)reader["Id_Table"];
                                maSession.Table = (reader["No_Table"].GetType() == typeof(DBNull)) ? 0 : (int)reader["No_Table"];
                                listeJoueursDansJoute.Clear();
                                string playerOne = (reader["PlayerOne"].GetType() == typeof(DBNull)) ? "" : (string)reader["PlayerOne"];
                                if (playerOne != "") listeJoueursDansJoute.Add(playerOne);
                                string playerTwo = (reader["PlayerTwo"].GetType() == typeof(DBNull)) ? "" : (string)reader["PlayerTwo"];
                                if (playerTwo != "") listeJoueursDansJoute.Add(playerOne);
                                string playerThree = (reader["PlayerThree"].GetType() == typeof(DBNull)) ? "" : (string)reader["PlayerThree"];
                                if (playerThree != "") listeJoueursDansJoute.Add(playerOne);
                                string playerFour = (reader["PlayerFour"].GetType() == typeof(DBNull)) ? "" : (string)reader["PlayerFour"];
                                if (playerFour != "") listeJoueursDansJoute.Add(playerOne);
                                maSession.NombreJoueurs = listeJoueursDansJoute.Count;
                                sessions.Add(maSession);
                            }
                        }
                        sqlConnexion.Close();
                        return sessions;
                    }
                }
            }
            catch (Exception) { throw; }
        }

        internal int ModifierJoueurDansBD(Joueur nouveauJoueur)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Joueur SET Code_Joueur = @Code_Joueur, Nom = @Nom, Pseudo = @Pseudo, FQCSF = @FQCSF, hide_Name = @CacherNom  " +
                        "WHERE ID_Joueur = @Id_joueur", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Id_Joueur", nouveauJoueur.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Code_Joueur", nouveauJoueur.CodeJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Nom", nouveauJoueur.Nom));
                        cmd.Parameters.Add(new MySqlParameter("@Pseudo", nouveauJoueur.Pseudo));
                        if (nouveauJoueur.Fqcsf.Replace(" ", "") == "" || nouveauJoueur.Fqcsf == null) cmd.Parameters.Add(new MySqlParameter("@FQCSF", DBNull.Value));
                        else cmd.Parameters.Add(new MySqlParameter("@FQCSF", nouveauJoueur.Fqcsf));
                        cmd.Parameters.Add(new MySqlParameter("@CacherNom", nouveauJoueur.CacherNom));

                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int ModifierRencontreDansBD(Rencontre newRencontre, int modifier)
        {
            // Dans la BD :    rencontre -> session

            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Session SET Date_Session = @New_Date where Date_Session = @Old_Date WHERE Id_Session = @Id_Session", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Id_Session", newRencontre.IdSession));
                        cmd.Parameters.Add(new MySqlParameter("@New_Date", newRencontre.DateNouvelle));
                        cmd.Parameters.Add(new MySqlParameter("@Old_Date", newRencontre.DateDeJeu));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int SupprimerJoueurDansBD(int Id_Joueur)
        {
            // Attention :  supprimer un joueur avec scores va faire planter
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Joueur WHERE ID_Joueur = @ID_Joueur", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@ID_Joueur", Id_Joueur));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int SupprimerRencontreDansBD(int Id_Rencontre, int noTable, int noPartie)
        {
            //Supprimer une rencontre sans joueurs
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    // Suprimer le lien Session_Table_Game
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Session_Table_Game WHERE ID_Joute = @ID_Joute AND Id_Session = @ID_Session AND Id_Table = @Id_Table", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@ID_Joute", noPartie));
                        cmd.Parameters.Add(new MySqlParameter("@ID_Table", noTable));
                        cmd.Parameters.Add(new MySqlParameter("@ID_Session", Id_Rencontre));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    // Supprimer la partie
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Game WHERE ID_Joute = @ID_Joute", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@ID_Joute", noPartie));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    List<int> nbSession = ListerRencontresId("");
                    int nbMatch = 0;
                    foreach (int id in nbSession)
                    {
                        if(id == Id_Rencontre) nbMatch++;
                    }
                    if (nbMatch == 0)                    
                    {
                        using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Session WHERE ID_Session = @ID_Session", sqlConnexion))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@ID_Session", Id_Rencontre));
                            lignesAffectees = cmd.ExecuteNonQuery();
                        }
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        private List<int> ListerRencontresId(string orderBy)
        {
            List<int> idsSessions = new List<int>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT id_session FROM Session_Table_Game ", sqlConnexion))
                    {

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idSession = (int)reader["Id_Session"];
                                idsSessions.Add(idSession);
                            }
                        }
                    }

                    sqlConnexion.Close();
                    return idsSessions;
                }
            }
            catch (Exception) { throw; }
        }

        internal List<Table> ListerTablesDansBD(string orderBy)
        {
            List<Table> tables = new List<Table>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM _table " + orderBy, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Table maTable = new Table();
                                maTable.IDTable = (int)reader["Id_Table"];
                                maTable.NoTable = (int)reader["No_Table"];
                                maTable.ReglesTable = (string)reader["Regles"];
                                tables.Add(maTable);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return tables;
                }
            }
            catch (Exception) { throw; }
        }

        internal List<Partie> ListerPartiesDansBD(Partie partie, string orderBy)
        {
            List<Partie> parties = new List<Partie>();
            try
            {
                string maCommandeCRUD;
                if (partie == null) maCommandeCRUD = "SELECT * FROM game ";
                else maCommandeCRUD = "SELECT * FROM game WHERE Id_Joute = @Id_Joute ";
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(maCommandeCRUD + orderBy, sqlConnexion))
                    {
                        if (partie != null) cmd.Parameters.Add(new MySqlParameter("@Id_Joute", partie.IdPartie));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Partie maPartie = new Partie();
                                maPartie.IdPartie = (int)reader["Id_Joute"];
                                maPartie.NoPartie = (int)reader["No_Ronde"];
                                maPartie.Idjoueur1 = reader["Id_PlayerOne"] == DBNull.Value ? 0 : (int)reader["Id_PlayerOne"];
                                maPartie.Idjoueur2 = reader["Id_PlayerTwo"] == DBNull.Value ? 0 : (int)reader["Id_PlayerTwo"];
                                maPartie.Idjoueur3 = reader["Id_PlayerThree"] == DBNull.Value ? 0 : (int)reader["Id_PlayerThree"];
                                maPartie.Idjoueur4 = reader["Id_PlayerFour"] == DBNull.Value ? 0 : (int)reader["Id_PlayerFour"];


                                parties.Add(maPartie);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return parties;
                }
            }
            catch (Exception) { throw; }
        }

        internal List<LiensSessionTablePartie> ListerLiensSessionTablePartie(string orderBy)
        {
            List<LiensSessionTablePartie> liensExistants = new List<LiensSessionTablePartie>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Session_Table_Game " + orderBy, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LiensSessionTablePartie monLien = new LiensSessionTablePartie();
                                monLien.IdSession = (int)reader["Id_Session"];
                                monLien.IdTable = (int)reader["Id_Table"];
                                monLien.IdPartie = (int)reader["Id_Joute"];
                                liensExistants.Add(monLien);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return liensExistants;
                }
            }
            catch (Exception) { throw; }
        }

        internal int CreerLiens_Session_Table_Partie(int id_rencontre, int idTable, int idPartie)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Session_Table_Game VALUES (@Id_Session, @Id_Table, @Id_Joute)", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Id_Session", id_rencontre));
                        cmd.Parameters.Add(new MySqlParameter("@Id_Table", idTable));
                        cmd.Parameters.Add(new MySqlParameter("@Id_Joute", idPartie));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int CreerNouvellePartie(int noPartie)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                int idPartieCree;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Game (No_Ronde) VALUES (@No_Ronde); SELECT LAST_INSERT_ID();", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@No_Ronde", noPartie));
                        lignesAffectees = cmd.ExecuteNonQuery();
                        var idCree = cmd.ExecuteScalar().ToString();
                        bool ok = int.TryParse(idCree, out idPartieCree);
                    }
                    sqlConnexion.Close();
                    return idPartieCree;
                }
            }
            catch (Exception) { throw; }
        }

        internal int AjouterNouvelleTable(int noTable, string regles)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int idTableCree;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO _Table (No_Table, Regles) VALUES (@No_Table, @Regles); SELECT LAST_INSERT_ID();", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@No_Table", noTable)); 
                        cmd.Parameters.Add(new MySqlParameter("@Regles", regles));
                        var idCree = cmd.ExecuteScalar().ToString();
                        bool ok = int.TryParse(idCree, out idTableCree);
                    }
                    sqlConnexion.Close();
                    return idTableCree;
                }
            }
            catch (Exception) { throw; }
        }

        internal int AjouterJoueursDansJoute(int id_Joute, int no_Joute, List<Joueur> joueursAJouter)
        {
            // On sait qu'il y a trois joueurs minimum et c'est déjà vérifié
            Joueur playerOne = joueursAJouter[0];
            Joueur playerTwo = joueursAJouter[1];
            Joueur playerThree = joueursAJouter[2];
            Joueur playerFour = new Joueur();
            if (joueursAJouter.Count == 4) playerFour = joueursAJouter[3];
            else playerFour = null;

            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Game SET " 
                        + "PlayerOne = @PlayerOne, " 
                        + "PlayerTwo = @PlayerTwo, " 
                        + "PlayerThree = @PlayerThree, " 
                        + "PlayerFour = @PlayerFour, "
                        + "Id_PlayerOne = @Id_PlayerOne, "
                        + "Id_PlayerTwo = @Id_PlayerTwo, "
                        + "Id_PlayerThree = @Id_PlayerThree, "
                        + "Id_PlayerFour = @Id_PlayerFour "
                        + "WHERE Id_Joute = @Id_Joute AND No_Ronde = @No_Joute ", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@No_Joute", no_Joute));
                        cmd.Parameters.Add(new MySqlParameter("@Id_Joute", id_Joute));
                        cmd.Parameters.Add(new MySqlParameter("@PlayerOne", playerOne.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@PlayerTwo", playerTwo.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@PlayerThree", playerThree.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Id_PlayerOne", playerOne.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Id_PlayerTwo", playerTwo.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Id_PlayerThree", playerThree.IdJoueur));
                        if (playerFour != null)
                        {
                            cmd.Parameters.Add(new MySqlParameter("@PlayerFour", playerFour.IdJoueur));
                            cmd.Parameters.Add(new MySqlParameter("@Id_PlayerFour", playerFour.IdJoueur));
                        }
                        else
                        {
                            cmd.Parameters.Add(new MySqlParameter("@PlayerFour", DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("@Id_PlayerFour", DBNull.Value));
                        }
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal List<LienJouteScoreJoueur> ListerLiensJouteScoreJoueur(string commande)
        {
            List<LienJouteScoreJoueur> liensExistants = new List<LienJouteScoreJoueur>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Joute_Score_Joueur " + commande, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LienJouteScoreJoueur monLien = new LienJouteScoreJoueur();
                                monLien.IdJoute = (int)reader["Id_Joute"];
                                monLien.IdScore = (int)reader["Id_Score"];
                                monLien.IdJoueur = (int)reader["Id_Joueur"];
                                liensExistants.Add(monLien);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return liensExistants;
                }
            }
            catch (Exception) { throw; }
        }

        internal int CreerLienJouteScoreJoueur(int id_Joute, int id_Joueur, int id_Score)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Joute_Score_Joueur VALUES (@Id_Joute, @Id_Joueur, @Id_Score)", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Id_Joute", id_Joute));
                        cmd.Parameters.Add(new MySqlParameter("@Id_Score", id_Score));
                        cmd.Parameters.Add(new MySqlParameter("@Id_Joueur", id_Joueur));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int AjouterDonneesScore(ScoreJoueurDataGrid scoreAAjouter)
        {
            int lignesAffectees = 0;
            string commandeModifier = "";
            string setTours = "";
            string setCompilations = "";
            string whereCommand = "";
            int id_Score = scoreAAjouter.ScoreJoueur.IdScore;

            if (id_Score == 0)
            {
                try
                {
                    id_Score = CreerNouveauScore();
                }
                catch (Exception) { throw; }
            }
           
            commandeModifier = "UPDATE Score ";
            setTours = " SET Tour1 = @Tour1, Tour2 = @Tour2, Tour3 = @Tour3, Tour4 = @Tour4, Tour5 = @Tour5 ";
            setCompilations = ", Bonus = @Bonus, Penalite = @Penalite, Total = @Total ";
            whereCommand = " WHERE Id_Score = " + id_Score.ToString() + ";";
            commandeModifier = commandeModifier + setTours + setCompilations + whereCommand;
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);

                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(commandeModifier, sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Tour1", scoreAAjouter.Tour1));
                        cmd.Parameters.Add(new MySqlParameter("@Tour2", scoreAAjouter.Tour2));
                        cmd.Parameters.Add(new MySqlParameter("@Tour3", scoreAAjouter.Tour3));
                        cmd.Parameters.Add(new MySqlParameter("@Tour4", scoreAAjouter.Tour4));
                        cmd.Parameters.Add(new MySqlParameter("@Tour5", scoreAAjouter.Tour5));
                        cmd.Parameters.Add(new MySqlParameter("@Bonus", scoreAAjouter.Bonus));
                        cmd.Parameters.Add(new MySqlParameter("@Penalite", scoreAAjouter.Penalite));
                        cmd.Parameters.Add(new MySqlParameter("@Total", scoreAAjouter.TotalJoueur));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    //return lignesAffectees;
                }
                // Créer nouveau lien Joute_Score_Joueur
                //int idLien = CreerLienJouteScoreJoueur(scoreAAjouter.IdJoute, scoreAAjouter.Joueur.IdJoueur, id_Score);
                return lignesAffectees;
            }

            catch (Exception) { throw; }
        }
        internal int CreerNouveauScore()
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int id_Score = 0;

                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Score () VALUES (); SELECT LAST_INSERT_ID();", sqlConnexion))
                    {
                        //cmd.Parameters.Add(new MySqlParameter("@Id_Joute", id_Joute));
                        //cmd.Parameters.Add(new MySqlParameter("@Id_Score", id_Score));
                        //cmd.Parameters.Add(new MySqlParameter("@Id_Joueur", id_Joueur));
                        var idCree = cmd.ExecuteScalar().ToString();
                        bool ok = int.TryParse(idCree, out id_Score);
                        
                    }
                    sqlConnexion.Close();
                    return id_Score;
                }
            }
            catch (Exception) { throw; }
        }

        internal List<Score> ListerScoresDansBD(string orderBy)
        {
            List<Score> scores = new List<Score>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Score " + orderBy, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Score monScore = new Score();
                                monScore.IdScore = (int)reader["Id_Score"];
                                monScore.Tour1 = reader["Tour1"] == DBNull.Value ? 0 : (int)reader["Tour1"];
                                monScore.Tour2 = reader["Tour2"] == DBNull.Value ? 0 : (int)reader["Tour2"];
                                monScore.Tour3 = reader["Tour3"] == DBNull.Value ? 0 : (int)reader["Tour3"];
                                monScore.Tour4 = reader["Tour4"] == DBNull.Value ? 0 : (int)reader["Tour4"];
                                monScore.Tour5 = reader["Tour5"] == DBNull.Value ? 0 : (int)reader["Tour5"];
                                //monScore.Total = reader["Total"] == DBNull.Value ? 0 : (int)reader["Total"];
                                monScore.Bonus = reader["Bonus"] == DBNull.Value ? 0 : (int)reader["Bonus"];
                                monScore.Penalite = reader["Penalite"] == DBNull.Value ? 0 : (int)reader["Penalite"];
                                
                                scores.Add(monScore);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return scores;
                }
            }
            catch (Exception) { throw; }
        }

        internal int SupprimerLienJouteScoreJoueur(string commande)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand(commande, sqlConnexion))
                    {
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int SupprimerScore(int idScore)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("DELETE from Score WHERE ID_Score = " + idScore.ToString(), sqlConnexion))
                    {
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }
    }
}
