use ligue_scrabble;
 
insert into _Table (No_Table, Regles) values (1, 'sans ODS');
insert into _Table (No_Table, Regles) values (2, 'sans ODS');
insert into _Table (No_Table, Regles) values (3, 'avec ODS');
insert into _Table (No_Table, Regles) values (4, 'Duplicate');

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

insert into session (Date_Session) values ('2024-10-03 19:00:00');
insert into session (Date_Session) values ('2024-11-27 20:00:00');
insert into session (Date_Session) values ('2024-11-20 20:00:00');

insert into game (No_ronde, playerOne, playertwo, playerThree, playerfour) values (1, 'A','B','C','D');
insert into game (No_ronde, playerOne, playertwo, playerThree) values (2, 'E','F','G');
insert into game (No_ronde) values (1);
insert into game (No_ronde) values (2);
insert into game (No_ronde) values (1);


insert into Session_Table_Game values (1,1,1);		 /*(Id_Session, Id_Table, Id_Joute)*/
insert into Session_Table_Game values (1,1,2);
insert into Session_Table_Game values (1,2,3);
insert into Session_Table_Game values (2,1,4);
insert into Session_Table_Game values (3,1,5);

insert into Score (Tour1, Tour2, Tour3, Tour4, Tour5, Penalite, Bonus, Total) values (1,1,1,1,1,0,2,7);
insert into Joute_Score_Joueur values (1,1,1);
insert into Score (Tour1, Tour2, Tour3, Tour4, Tour5, Penalite, Bonus, Total) values (2,2,2,2,2,-2,0,8);
insert into Joute_Score_Joueur values (1,2,2);
insert into Score (Tour1, Tour2, Tour3, Tour4, Tour5, Penalite, Bonus, Total) values (3,3,3,3,3,0,0,12);
insert into Joute_Score_Joueur values (1,3,3);
insert into Score (Tour1, Tour2, Tour3, Tour4, Tour5, Penalite, Bonus, Total) values (4,4,4,4,4,-1,3, 22);
insert into Joute_Score_Joueur values (1,4,4);

insert into Score (Tour1, Tour2, Tour3, Tour4, Tour5, Penalite, Bonus, Total) values (5,5,5,5,5,0,5,30);
insert into Joute_Score_Joueur values (2,5,5);
insert into Score (Tour1, Tour2, Tour3, Tour4, Tour5, Penalite, Bonus, Total) values (6,6,6,6,6,-6,0,24);
insert into Joute_Score_Joueur values (2,6,6);
insert into Score (Tour1, Tour2, Tour3, Tour4, Tour5, Penalite, Bonus, Total) values (7,7,7,7,7,-2,9,42);
insert into Joute_Score_Joueur values (2,7,7);


