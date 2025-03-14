﻿using System;
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
                                List<int> idJoueursParticipants = new List<int>();
                                maSession.ListeIdJoueurs = idJoueursParticipants;
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
                                maSession.ListeIdJoueurs.Add((reader["Id_PlayerOne"].GetType() == typeof(DBNull)) ? 0 : (int)reader["Id_PlayerOne"]);

                                maSession.ListeIdJoueurs.Add((reader["Id_PlayerTwo"].GetType() == typeof(DBNull)) ? 0 : (int)reader["Id_PlayerTwo"]);
                                maSession.ListeIdJoueurs.Add((reader["Id_PlayerThree"].GetType() == typeof(DBNull)) ? 0 : (int)reader["Id_PlayerThree"]);
                                maSession.ListeIdJoueurs.Add((reader["Id_PlayerFour"].GetType() == typeof(DBNull)) ? 0 : (int)reader["Id_PlayerFour"]);
                                maSession.NombreJoueurs = CompterJoueursParticipante(maSession.ListeIdJoueurs);
                                sessions.Add(maSession);
                            }
                        }
                    }

                    // Afficher si des parties sont homologuées

                    for (int noSession = 0; noSession < sessions.Count; noSession++)
                    {
                        List<Joueur> joueursDansBD = ListerJoueursDansBD(" ORDER By Id_Joueur"); // Quérir infos des joueurs homologués
                        bool partieHomologuee = true;
                        foreach (var idJoueurAVerifier in joueursDansBD)
                        {
                            for (int noJoueurParticipant = 0; noJoueurParticipant < sessions[noSession].NombreJoueurs; noJoueurParticipant++)
                            {
                                if (idJoueurAVerifier.IdJoueur == sessions[noSession].ListeIdJoueurs[noJoueurParticipant] && idJoueurAVerifier.NoFqcsf == 0)
                                {
                                    partieHomologuee &= false;
                                }
                            }
                        }
                        sessions[noSession].Homologation = partieHomologuee;

                        // Afficher le gagnant et son score

                        
                        int[] scoreIndividuel = new int[joueursDansBD.Count + 1];
                        int idJoute = sessions[noSession].Id_Ronde;
                        int idJoueur = 0;
                        int idScore =0;
                        for (int noJoueur = 0; noJoueur < sessions[noSession].NombreJoueurs; noJoueur++)
                        {
                            idJoueur = sessions[noSession].ListeIdJoueurs[noJoueur];
                            string cmdRechercheIdScore = "SELECT * FROM Joute_Score_Joueur WHERE Id_joueur = "
                                                        + idJoueur.ToString() + " AND Id_Joute = " + idJoute.ToString() + ";";
                            using (MySqlCommand cmd = new MySqlCommand(cmdRechercheIdScore, sqlConnexion))
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        idScore = (int)reader["Id_Score"];
                                    }
                                }
                            }
                            int scoreJoueur =0;
                            string cmdRechercheScoreTotal = "SELECT Total from Score WHERE Id_Score = " + idScore.ToString() + ";";
                            using (MySqlCommand cmd = new MySqlCommand(cmdRechercheScoreTotal, sqlConnexion))
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        //== typeof(DBNull)) ? 0 : (int)reader["Id_PlayerFour"]
                                        scoreJoueur = reader["Total"].GetType() == typeof(DBNull) ? 0 : (int)reader["Total"];
                                    }
                                }
                            }
                            scoreIndividuel[idJoueur] = scoreJoueur;
                            sessions[noSession].ScoreGagnant = scoreIndividuel.Max();
                            if (scoreIndividuel[idJoueur] >= scoreIndividuel.Max() && scoreIndividuel[idJoueur] != 0)
                            {
                                foreach (var joueur in joueursDansBD)
                                {
                                        sessions[noSession].Gagnant = joueursDansBD[idJoueur - 1].Nom;
                                }
                            }


                        }
                    }
                    sqlConnexion.Close();

                    return sessions;
                }
            }
            catch (Exception) { throw; }
        }

        private int CompterJoueursParticipante(List<int> listeIdJoueurs)
        {
            int total = 0;
            foreach (var id in listeIdJoueurs)
            {
                if (id != 0) total++;
            }
            return total;
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

        internal int CreerLiens_Session_Table_Partie(LiensSessionTablePartie newLien)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int nbLignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Session_Table_Game VALUES (@Id_Session, @Id_Table, @Id_Joute); SELECT LAST_INSERT_ID();", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Id_Session", newLien.IdSession));
                        cmd.Parameters.Add(new MySqlParameter("@Id_Table", newLien.IdTable));
                        cmd.Parameters.Add(new MySqlParameter("@Id_Joute", newLien.IdPartie));
                        nbLignesAffectees = cmd.ExecuteNonQuery();
                        //var idCree = cmd.ExecuteScalar().ToString();
                        //bool ok = int.TryParse(idCree, out idLienCree);
                    }
                    sqlConnexion.Close();
                    return nbLignesAffectees;
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
                        //lignesAffectees = cmd.ExecuteNonQuery();
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
                        cmd.Parameters.Add(new MySqlParameter("@PlayerOne", playerOne.Nom));
                        cmd.Parameters.Add(new MySqlParameter("@PlayerTwo", playerTwo.Nom));
                        cmd.Parameters.Add(new MySqlParameter("@PlayerThree", playerThree.Nom));
                        cmd.Parameters.Add(new MySqlParameter("@Id_PlayerOne", playerOne.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Id_PlayerTwo", playerTwo.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Id_PlayerThree", playerThree.IdJoueur));
                        if (playerFour != null)
                        {
                            cmd.Parameters.Add(new MySqlParameter("@PlayerFour", playerFour.Nom));
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
            List<LienJouteScoreJoueur> liensExistantsARetourner = new List<LienJouteScoreJoueur>();

            List<int> listeJoueursDansOrdre = new List<int>();
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
                    if (liensExistants.Count == 0) return liensExistants;
                    string maCommande = "SELECT * FROM Game where id_Joute =" + liensExistants[0].IdJoute.ToString();
                    using (MySqlCommand cmd = new MySqlCommand(maCommande, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listeJoueursDansOrdre.Add((int)reader["Id_PlayerOne"]);
                                listeJoueursDansOrdre.Add((int)reader["Id_PlayerTwo"]);
                                listeJoueursDansOrdre.Add((int)reader["Id_PlayerThree"]);
                                listeJoueursDansOrdre.Add(reader["Id_PlayerFour"] == DBNull.Value ? 0 : (int)reader["Id_PlayerFour"]);
                                //listeJoueursDansOrdre.Add((int)reader["Id_PlayerFour"]);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    foreach (int idJoueur  in listeJoueursDansOrdre)
                    {
                        for (int nbLien = 0; nbLien < liensExistants.Count; nbLien++)
                        {
                            if (liensExistants[nbLien].IdJoueur == idJoueur)
                            {
                                liensExistantsARetourner.Add(liensExistants[nbLien]);
                            }
                        }

                    }
                    return liensExistantsARetourner;
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
            setTours = " SET Tour1 = @Tour1, Tour2 = @Tour2, Tour3 = @Tour3, Tour4 = @Tour4, Tour5 = @Tour5" +
                    ", Tour6 = @Tour6, Tour7 = @Tour7, Tour8 = @Tour8, Tour9 = @Tour9, Tour10 = @Tour10" +
                    ", Tour11 = @Tour11, Tour12 = @Tour12, Tour13 = @Tour13, Tour14 = @Tour14, Tour15 = @Tour15" +
                    ", Tour16 = @Tour16, Tour17 = @Tour17, Tour18 = @Tour18, Tour19 = @Tour19, Tour20 = @Tour20";
            setCompilations = ", Bonus = @Bonus, Penalite = @Penalite, Total = @Total, Rang = @Rang";
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
                        cmd.Parameters.Add(new MySqlParameter("@Tour1", scoreAAjouter.ScoreJoueur.Tours[0]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour2", scoreAAjouter.ScoreJoueur.Tours[1]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour3", scoreAAjouter.ScoreJoueur.Tours[2]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour4", scoreAAjouter.ScoreJoueur.Tours[3]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour5", scoreAAjouter.ScoreJoueur.Tours[4]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour6", scoreAAjouter.ScoreJoueur.Tours[5]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour7", scoreAAjouter.ScoreJoueur.Tours[6]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour8", scoreAAjouter.ScoreJoueur.Tours[7]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour9", scoreAAjouter.ScoreJoueur.Tours[8]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour10", scoreAAjouter.ScoreJoueur.Tours[9]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour11", scoreAAjouter.ScoreJoueur.Tours[10]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour12", scoreAAjouter.ScoreJoueur.Tours[11]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour13", scoreAAjouter.ScoreJoueur.Tours[12]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour14", scoreAAjouter.ScoreJoueur.Tours[13]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour15", scoreAAjouter.ScoreJoueur.Tours[14]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour16", scoreAAjouter.ScoreJoueur.Tours[15]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour17", scoreAAjouter.ScoreJoueur.Tours[16]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour18", scoreAAjouter.ScoreJoueur.Tours[17]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour19", scoreAAjouter.ScoreJoueur.Tours[18]));
                        cmd.Parameters.Add(new MySqlParameter("@Tour20", scoreAAjouter.ScoreJoueur.Tours[19]));
                        cmd.Parameters.Add(new MySqlParameter("@Bonus", scoreAAjouter.Bonus));
                        cmd.Parameters.Add(new MySqlParameter("@Penalite", scoreAAjouter.Penalite));
                        cmd.Parameters.Add(new MySqlParameter("@Total", scoreAAjouter.TotalJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Rang", scoreAAjouter.Rang));
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
            Score monScore = new Score();
            List<int> tours = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            monScore.Tours = tours;

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
                                monScore.IdScore = (int)reader["Id_Score"];
                                monScore.Tours[0] = reader["Tour1"] == DBNull.Value ? 0 : (int)reader["Tour1"];
                                monScore.Tours[1] = reader["Tour2"] == DBNull.Value ? 0 : (int)reader["Tour2"];
                                monScore.Tours[2] = reader["Tour3"] == DBNull.Value ? 0 : (int)reader["Tour3"];
                                monScore.Tours[3] = reader["Tour4"] == DBNull.Value ? 0 : (int)reader["Tour4"];
                                monScore.Tours[4] = reader["Tour5"] == DBNull.Value ? 0 : (int)reader["Tour5"];
                                monScore.Tours[5] = reader["Tour6"] == DBNull.Value ? 0 : (int)reader["Tour6"];
                                monScore.Tours[6] = reader["Tour7"] == DBNull.Value ? 0 : (int)reader["Tour7"];
                                monScore.Tours[7] = reader["Tour8"] == DBNull.Value ? 0 : (int)reader["Tour8"];
                                monScore.Tours[8] = reader["Tour9"] == DBNull.Value ? 0 : (int)reader["Tour9"];
                                monScore.Tours[9] = reader["Tour10"] == DBNull.Value ? 0 : (int)reader["Tour10"];
                                monScore.Tours[10] = reader["Tour11"] == DBNull.Value ? 0 : (int)reader["Tour11"];
                                monScore.Tours[11] = reader["Tour12"] == DBNull.Value ? 0 : (int)reader["Tour12"];
                                monScore.Tours[12] = reader["Tour13"] == DBNull.Value ? 0 : (int)reader["Tour13"];
                                monScore.Tours[13] = reader["Tour14"] == DBNull.Value ? 0 : (int)reader["Tour14"];
                                monScore.Tours[14] = reader["Tour15"] == DBNull.Value ? 0 : (int)reader["Tour15"];
                                monScore.Tours[15] = reader["Tour16"] == DBNull.Value ? 0 : (int)reader["Tour16"];
                                monScore.Tours[16] = reader["Tour17"] == DBNull.Value ? 0 : (int)reader["Tour17"];
                                monScore.Tours[17] = reader["Tour18"] == DBNull.Value ? 0 : (int)reader["Tour18"];
                                monScore.Tours[18] = reader["Tour19"] == DBNull.Value ? 0 : (int)reader["Tour19"];
                                monScore.Tours[19] = reader["Tour20"] == DBNull.Value ? 0 : (int)reader["Tour20"];
                                monScore.Rang = reader["Rang"] == DBNull.Value ? "" : (string)reader["Rang"];
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

        internal int TrouverIdTable(int noTable)
        {
            int idTable = 0;
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT Id_Table FROM _Table WHERE No_Table = " + noTable.ToString(), sqlConnexion))
                    {
                        var idCree = cmd.ExecuteScalar().ToString();
                        bool ok = int.TryParse(idCree, out idTable);
                    }
                    sqlConnexion.Close();
                    return idTable;
                }
            }
            catch (Exception) { throw; }
        }

        internal int TrouverIdJoute(int newLienTable_Session_Joute)
        {
            int idJoute = 0;
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT Id_Table FROM Session_Table_Game WHERE Id_Table_Session_Joute = " + newLienTable_Session_Joute.ToString(), sqlConnexion))
                    {
                        var idCree = cmd.ExecuteScalar().ToString();
                        bool ok = int.TryParse(idCree, out idJoute);
                    }
                    sqlConnexion.Close();
                    return idJoute;
                }
            }
            catch (Exception) { throw; }
        }

        internal int TrouverNoJoute(int idJoute)
        {
            int noJoute = 0;
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT No_Joute FROM Game WHERE Id_Joute = " + idJoute.ToString(), sqlConnexion))
                    {
                        var idCree = cmd.ExecuteScalar().ToString();
                        bool ok = int.TryParse(idCree, out noJoute);
                    }
                    sqlConnexion.Close();
                    return noJoute;
                }
            }
            catch (Exception) { throw; }
        }

        internal Rencontre TrouverSessionTablePartie(int idJoute)
        {
            Rencontre maRencontre = new Rencontre();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM session_table_game WHERE Id_Joute = " + idJoute.ToString(), sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                maRencontre.IdSession = (int)reader["Id_Session"];
                                maRencontre.Id_Table = (int)reader["Id_Table"];
                                maRencontre.Id_Joute = idJoute;
                            }
                        }
                    }
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Session WHERE Id_Session = " + maRencontre.IdSession.ToString(), sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                maRencontre.DateDeJeu = (DateTime)reader["Date_Session"];
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return maRencontre;                    
                }
            }
            catch (Exception) { throw; }
        }
    }
    
}
