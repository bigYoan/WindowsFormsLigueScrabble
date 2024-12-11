select session.date_rencontre, _table.no_table, game.No_Partie from (session,_table, game) inner join session_table_game;

/* "SELECT Publication.ISBN, Publication.Titre, Publication.Synopsis, Genre.Genre, Auteur.Nom, Auteur.Prenom, Auteur.ID_Auteur" +
                            " FROM Publication LEFT JOIN Publication_Auteur ON Publication.ISBN = Publication_Auteur.ISBN LEFT JOIN Auteur ON Publication_Auteur.Id_Auteur = Auteur.Id_Auteur" +
                            " LEFT JOIN Publication_Genre ON Publication.ISBN = Publication_Genre.ISBN LEFT JOIN Genre ON Publication_Genre.Id_Genre = Genre.Id_Genre" +
                            " ORDER BY Publication.Titre" */
                            
select session.date_rencontre from session left join session.id_rencontre on session_table_game.Id_Rencontre;
select session.date_rencontre, _table.no_table from session left join _table on session_table_game.id_rencontre = session.id_rencontre;
use ligue_scrabble;
show tables;
select * from session_table_game;

SELECT        	Session.*, _Table.No_Table, Game.No_Partie
FROM            _Table 
				LEFT OUTER JOIN Session_Table_Game ON _Table.ID_Table = Session_Table_Game.Id_Table 
                RIGHT OUTER JOIN Game ON Session_Table_Game.Id_Joute = Game.Id_Joute 
                RIGHT OUTER JOIN Session ON Session_Table_Game.Id_Rencontre = Session.Id_Rencontre
order by session.date_rencontre desc;