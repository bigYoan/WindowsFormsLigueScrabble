using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


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

                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Joueur (ID_Joueur, nom, pseudo) VALUES (@ID_Joueur, @Nom, @Pseudo)", sqlConnexion))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@ID_Joueur", nouveauJoueur.IdCode));
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
                                monJoueur.IdCode = (string)reader["ID_Joueur"];
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
            throw new NotImplementedException();
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
                                maSession.DateDeJeu = (DateTime)reader["Date_Rencontre"];
                                sessions.Add(maSession);
                            }
                        }
                    }
                    sqlConnexion.Close();
                    return sessions;
                }
            }
            catch (Exception) { throw; }
        }

        internal int ModifierJoueurDansBD(Joueur nouveauJoueur, int modifier)
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("UPDATE Joueur SET Nom = @Nom, Pseudo = @Pseudo  WHERE ID_Joueur = @ID_Joueur", sqlConnexion))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@ID_Joueur", nouveauJoueur.IdCode));
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
            throw new NotImplementedException();
        }

        internal int SupprimerJoueurDansBD(string IDCode)
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
                        cmd.Parameters.Add(new MySqlParameter("@ID_Joueur", IDCode));
                        lignesAffectees = cmd.ExecuteNonQuery();
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        internal int SupprimerRencontreDansBD(DateTime dateDeJeu)
        {
            throw new NotImplementedException();
        }
    }
}
