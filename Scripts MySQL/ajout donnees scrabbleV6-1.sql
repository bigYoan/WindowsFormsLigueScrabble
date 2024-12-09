use ligue_scrabble;
 
insert into _Table (No_Table, Regles) values (1, 'sans ODS');
insert into _Table (No_Table, Regles) values (2, 'sans ODS');
insert into _Table (No_Table, Regles) values (3, 'avec ODS');
insert into _Table (No_Table, Regles) values (4, 'Duplicate');
/* select * from _Table; */


insert into joueur (Code_Joueur, Nom, Pseudo) values ('A', 'Ch.-Aimé', 'Orchidée');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('B', 'Simone', 'Oeillet');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('C', 'Nancy', 'Tulipe');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('D', 'Thérèse', 'Rose');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('E', 'Pierre', 'Lys');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('F', 'Céline', 'Marguerite');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('G', 'Yoan', 'Jacinthe');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('H', 'Karine', 'Violette');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('I', 'Yvette', 'Iris');
insert into joueur (Code_Joueur, Nom, Pseudo) values ('J', 'Fabien', 'Lilas');
/* select * from joueur; */



insert into session (Date_Session) values ('2024-10-03 19:00:00');
insert into session (Date_Session) values ('2024-11-27 20:00:00');
insert into session (Date_Session) values ('2024-11-20 20:00:00');
insert into session (Date_Session) values ('2024-12-04 19:00:00');
insert into session (Date_Session) values ('2024-10-03 19:00:00');
insert into session (Date_Session) values ('2024-9-18 20:00:00');
insert into session (Date_Session) values ('2024-9-18 19:00:00');
insert into session (Date_Session) values ('2024-10-04 19:00:00');
/* select * from session order by date_session desc; */

/* INSERT INTO session (Date_Session) VALUES ('2024-11-27 23:00:00');  SELECT LAST_INSERT_ID(); */

/*insert into table_session (ID_Table, ID_Session) values (1,1);
insert into table_session (ID_Table, ID_Session) values (2,1);*/

insert into game (No_ronde, playerOne, playertwo, playerThree, playerfour) values (1, 'A','B','C','D');
insert into game (No_ronde, playerOne, playertwo, playerThree) values (2, 'E','F','G');
insert into game (No_ronde, playerOne, playertwo) values (1, 'H','I');
insert into game (No_ronde, playerOne, playertwo, playerThree, playerfour) values (2, 'A','B','C','D');
insert into game (No_ronde, playerOne, playertwo, playerThree) values (2, 'E','F','G');
insert into game (No_ronde, playerOne, playertwo) values (3, 'H','I');
insert into game (No_ronde, playerOne, playertwo, playerThree, playerfour) values (4, 'A','B','C','D');
insert into game (No_ronde, playerOne, playertwo, playerThree) values (1, 'E','F','G');
insert into game (No_ronde, playerOne, playertwo) values (2, 'H','I');
 
/* insert into game_table values (1, 1);
insert into game_table values (1, 2);
insert into game_table values (1, 3);
insert into game_table values (2, 1);
insert into game_table values (2, 2);
insert into game_table values (2, 3); */

insert into Session_Table_Game values (1,1,1);		 /*(Id_Session, Id_Table, Id_Joute)*/
insert into Session_Table_Game values (1,1,2);
insert into Session_Table_Game values (1,2,3);
insert into Session_Table_Game values (1,2,4);
insert into Session_Table_Game values (5,2,5);
insert into Session_Table_Game values (5,1,6);
insert into Session_Table_Game values (8,3,7);

select * from session;
/* show tables;
select * from Session_Table_Game;
select * from game; */
