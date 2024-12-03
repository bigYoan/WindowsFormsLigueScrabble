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
        public int AjouterJoueurDansBD(List <Joueur> joueursAjoutes)
        {

            try
            {
                
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);
                int lignesAffectees = 0;
                List<Joueur> joueursDejaDansBD = AfficherJoueurs();
                foreach (var joueurEnTraitement in joueursDejaDansBD)
                {
                    foreach (var joueurAAjouter in joueursAjoutes)
                    {
                        if (joueurEnTraitement.IdCode == joueurAAjouter.IdCode) return 0;
                    }
                }

                using (sqlConnexion)
                {
                    sqlConnexion.Open();

                    foreach (var joueurAAjouter in joueursAjoutes)
                    {
                        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Joueur (ID_Joueur, nom, pseudo) VALUES (@ID_Joueur, @Nom, @Pseudo)", sqlConnexion))
                        {
                            cmd.Parameters.Add(new MySqlParameter("@ID_Joueur", joueurAAjouter.IdCode));
                            cmd.Parameters.Add(new MySqlParameter("@Nom", joueurAAjouter.Nom));
                            cmd.Parameters.Add(new MySqlParameter("@Pseudo", joueurAAjouter.Pseudo));
                            lignesAffectees = cmd.ExecuteNonQuery();
                        }
                    }
                    sqlConnexion.Close();
                    return lignesAffectees;
                }
            }
            catch (Exception) { throw; }
        }

        private List<Joueur> AfficherJoueurs()
        {
            try
            {
                MySqlConnection sqlConnexion = new MySqlConnection(maConnexionString);

                using (sqlConnexion)
                {
                    List<Joueur> joueurs = new List<Joueur>();

                    using (sqlConnexion)
                    {
                        sqlConnexion.Open();
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Joueur ORDER BY Joueur.Nom", sqlConnexion))
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
            }
            catch (Exception) { throw; }
        }
    }
}
