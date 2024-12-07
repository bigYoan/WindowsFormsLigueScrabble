using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;


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

                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Joueur (ID_Joueur, nom, pseudo) VALUES (@Code_Joueur, @Nom, @Pseudo)", sqlConnexion))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@Code_Joueur", nouveauJoueur.CodeJoueur));
                            cmd.Parameters.Add(new MySqlParameter("@Nom", nouveauJoueur.Nom));
                            cmd.Parameters.Add(new MySqlParameter("@Pseudo", nouveauJoueur.Pseudo));
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
                //int lignesAffectees = 0;
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
            //Créer une nouvelle session (recontre);
            //Créer des liens session avec les tables (pupitres)
            //Créer une nouvelle(s) partie(s) (joute)
            //Créer des liens tables avec les parties (joutes)
            //Créer une nouvelle table de scores
            //Créer des liens joueur_score_joute

            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO session (Date_Rencontre) VALUES (@Date_rencontre)", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Date_rencontre", newRencontre.DateNouvelle));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal List<Rencontre> ListerRencontresDansBD(string orderBy)
        {
            // Dans la BD :    rencontre -> session

            List<Rencontre> sessions = new List<Rencontre>();
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
                                Rencontre maSession = new Rencontre();
                                maSession.IdSession = (int)reader["Id_Rencontre"];
                                maSession.DateDeJeu = (DateTime)reader["Date_Rencontre"];
                                sessions.Add(maSession);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    Rencontre rencontreBidon = new Rencontre();
                    rencontreBidon.DateNouvelle = DateTime.Now;
                    rencontreBidon.DateDeJeu = DateTime.Now;
                    

                    return sessions;
                }
            }
            catch (Exception) { throw; }
        }

        internal List<LienTableSession> ListerLiensRencontre_Table(string orderBy)
        {
            // Dans la BD :    rencontre -> session      table -> _table

            List <LienTableSession> liensTS = new List<LienTableSession> ();

            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM table_session", sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //LienTableSession monLienTS = new LienTableSession();
                                //monLienTS.IdSession = (DateTime)reader["Id_Rencontre"];
                                //monLienTS.IdTable = (int)reader["Id_Table"];
                                //liensTS.Add(monLienTS);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return liensTS;
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

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Joueur SET CodeJoueur = @Code_Joueur Nom = @Nom, Pseudo = @Pseudo  WHERE ID_Joueur = @Id_joueur", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Id_Joueur", nouveauJoueur.IdJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Code_Joueur", nouveauJoueur.CodeJoueur));
                        cmd.Parameters.Add(new MySqlParameter("@Nom", nouveauJoueur.Nom));
                        cmd.Parameters.Add(new MySqlParameter("@Pseudo", nouveauJoueur.Pseudo));
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

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Session SET Date_Rencontre = @New_Date where Date_Rencontre = @Old_Date WHERE Id_Rencontre = @Id_Rencontre", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@Id_Rencontre", newRencontre.IdSession));
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

        internal int SupprimerRencontreDansBD(int Id_Rencontre)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Session WHERE ID_Rencontre = @ID_Rencontre", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@ID_Rencontre", Id_Rencontre));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int ListerLiensSessionTable(DateTime dateEtHeureNewSession, int noTable)
        {

            // Dans la BD :    rencontre -> session      table -> _table

            List<LienTableSession> liensTS = new List<LienTableSession>();

            

            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM table_session", sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LienTableSession monLienTS = new LienTableSession();
                                monLienTS.IdSession = (int)reader["Id_Rencontre"];
                                monLienTS.IdTable = (int)reader["Id_Table"];
                                liensTS.Add(monLienTS);
                            }
                        }
                    }
                    
                    
                    sqlConnexion.Close();
                    return 0;
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

        internal List<Partie> ListerPartiesDansBD(string orderBy)
        {
            List<Partie> parties = new List<Partie>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM game " + orderBy, sqlConnexion))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Partie maPartie = new Partie();
                                maPartie.IdPartie = (int)reader["Id_Joute"];
                                maPartie.NoPartie = (int)reader["No_Partie"];
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
                                monLien.IdSession = (int)reader["Id_Rencontre"];
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
    }
}
