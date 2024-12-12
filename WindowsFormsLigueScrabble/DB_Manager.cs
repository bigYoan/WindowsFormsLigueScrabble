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
            //Créer une nouvelle session (recontre);
            //Créer des liens session avec les tables (pupitres)
            //Créer une nouvelle(s) partie(s) (joute)
            //Créer des liens tables avec les parties (joutes)
            //Créer une nouvelle table de scores
            //Créer des liens joueur_score_joute

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
            // Dans la BD :    rencontre -> session
            /* SELECT s.at, pupitre.no, joute.no
    FROM session s
    INNER JOIN session_pupitre_joute spj ON spj.session_id = s.id-- Joindre la table de jonction
    INNER JOIN pupitre ON spj.pupitre_id = pupitre.id-- Joindre la table pupitre
    INNER JOIN joute ON spj.joute_id = joute.id; --Joindre la table joute */

            string commande_Lister_Session_Table_Game =
            "SELECT Session.*, _Table.No_Table, Game.No_Ronde, Game.Id_Joute, _Table.Id_Table " +
            "FROM session " +
            "LEFT JOIN Session_Table_Game  as stj ON stj.Id_Session = session.Id_Session " +
            "LEFT JOIN _Table ON stj.Id_Table = _Table.Id_Table " +
            "LEFT JOIN Game ON stj.Id_Joute = Game.Id_Joute ";

            ;/* + "FROM _Table " + "LEFT OUTER JOIN Session_Table_Game ON _Table.Id_Table = Session_Table_Game.Id_Table " +
            "RIGHT OUTER JOIN Game ON Session_Table_Game.Id_Joute = Game.Id_Joute " +
            "RIGHT OUTER JOIN Session ON Session_Table_Game.Id_Session = Session.Id_Session "
            "order by session.date_Session desc;";*/

            List<RencontresDataGrid> sessions = new List<RencontresDataGrid>();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(commande_Lister_Session_Table_Game + orderBy, sqlConnexion))

                    //using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Session LEFT JOIN " + orderBy, sqlConnexion))
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
                                monLienTS.IdSession = (int)reader["Id_Session"];
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

        internal Rencontre ListerRencontreSeule(int idSession)
        {
            Rencontre rencontreTrouvee = new Rencontre();
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                //int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Session WHERE ID_Session = @ID_Session" , sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@ID_Session", idSession));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rencontreTrouvee.IdSession = (int)reader["Id_Session"];
                                rencontreTrouvee.DateNouvelle = (DateTime)reader["Date_Session"];
                                rencontreTrouvee.DateDeJeu = rencontreTrouvee.DateNouvelle;
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return rencontreTrouvee;
                }
            }
            catch (Exception) { throw; }
        }
    }
}
