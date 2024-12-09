use ligue_scrabble;
 
insert into _Table (No_Table) values (1);
insert into _Table (No_Table) values (2);
insert into _Table (No_Table) values (3);
insert into _Table (No_Table) values (4);
select * from _Table;

select * from joueur;
delete from joueur where ID_Joueur = '';
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

UPDATE Joueur SET Nom = 'Nancy', Pseudo = 'Tulipe'  WHERE ID_Joueur = 'C';


select * from session order by date_rencontre desc;
delete from session;
insert into session (Date_Rencontre) values ('2024-10-03 19:00:00');
insert into session (Date_Rencontre) values ('2024-11-27 20:00:00');
insert into session (Date_Rencontre) values ('2024-11-20 20:00:00');
insert into session (Date_Rencontre) values ('2024-12-04 19:00:00');

INSERT INTO session (Date_Rencontre) VALUES ('2024-11-27 23:00:00');
SELECT LAST_INSERT_ID();

insert into table_session (ID_Table, ID_Rencontre) values (1,1);
insert into table_session (ID_Table, ID_Rencontre) values (2,1);

insert into game (No_Partie, playerOne, playertwo, playerThree, playerfour) values (1, 'A','B','C','D');
insert into game (No_Partie, playerOne, playertwo, playerThree) values (1, 'E','F','G');
insert into game (NO_Partie, playerOne, playertwo) values (1, 'H','I');

insert into game_table values (1, 1);
insert into game_table values (1, 2);
insert into game_table values (1, 3);
insert into game_table values (2, 1);
insert into game_table values (2, 2);
insert into game_table values (2, 3);

insert into Session_Table_Game values (1,1,1);		 /*(Id_rencontre, Id_Table, Id_Joute)*/
insert into Session_Table_Game values (1,1,2);
insert into Session_Table_Game values (1,2,1);
insert into Session_Table_Game values (1,2,2);
insert into Session_Table_Game values (5,2,2);
insert into Session_Table_Game values (5,1,1);
insert into Session_Table_Game values (34,3,3);


show tables;
select * from game_Table;
select * from game;
