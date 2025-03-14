/* Créer une DB pour des rencontres (sessions) de Scrabble, par Yoan Godin
	Chaque session se déroule à une date et une heure
    Il peut y avoir plusieurs sessions ayant la même date et heure
    Chaque session est divisée en pupitres (ou tables) où des joueurs se renontrent
    Chaque table a ses règles de jeu qui lui est propre (3 règles : classique sans dico, duplicate, classique avec dico
    À chaque rencontre : 	-les tables 1 et 2 sont toujours en mode classique sans dico.
							-la table 3 est toujours en mode classique avec dico.
                            -la table 4 est toujours en duplicate
                            -les tables supplémentaires sont au choix de l'arbitre.
	À chaque rencontre, il y a toujours 2 rondes (appelées parties ou joutes; i.e. les joueurs jouent 2 joutes.
    3 à 4 joueurs par joute.
    Chaque joute est unique et contient son identificateur, les joueurs, et les scores indviduels.
    Chaque joueur possède ses stats (scores individuels, high score, nombre de victoires, etc.)
    La table des scores :  chaque score est unique et contient le pointage de chaque tour, le bonus, la pénalité et le total.*/
    
/*   drop database ligue_scrabble;   */
create database ligue_scrabble;

use ligue_scrabble;
select * from _table;
CREATE TABLE _Table(
	ID_Table int auto_increment,
   No_Table int,
   Regles varchar(50),
   PRIMARY KEY(ID_Table)
);

CREATE TABLE Session(
	Id_Session int auto_increment,
   Date_Session DATETIME,
   PRIMARY KEY(Id_Session)
);
select * from score;
delete from score where id_score > 135;
create table Score(
	Id_Score int auto_increment,
    Tour1 int,
    Tour2 int,
    Tour3 int,
    Tour4 int,
    Tour5 int,
    Tour6 int,
    Tour7 int,
    Tour8 int,
    Tour9 int,
    Tour10 int,
    Tour11 int,
    Tour12 int,
    Tour13 int,
    Tour14 int,
    Tour15 int,
    Tour16 int,
    Tour17 int,
    Tour18 int,
    Tour19 int,
    Tour20 int,
    Bonus int,
    Penalite int,
    Total int,
    primary key (Id_Score)
    );
select * from game;  
select * from session;
delete from game where id_joute = 64;   
CREATE TABLE Game(
   Id_Joute int auto_increment,
   No_Ronde int not null,
   Id_PlayerOne int,
   PlayerOne VARCHAR(50),
   Id_PlayerTwo int,
   PlayerTwo VARCHAR(50),
   Id_PlayerThree int,
   PlayerThree VARCHAR(50),
   Id_PlayerFour int,
   PlayerFour VARCHAR(50),
   PRIMARY KEY(Id_Joute)
);
 
 CREATE TABLE Joueur(
   Id_Joueur int auto_increment,
   Code_Joueur CHAR(2) not null,
   Nom VARCHAR(50) not null,
   Pseudo VARCHAR(50),
   FQCSF varchar(10) unique,
   hide_Name int,
   Id_Stats INT,
   PRIMARY KEY(Id_Joueur)
   /* Pour future table Stats
   /*UNIQUE(Id_Stats),
   FOREIGN KEY(Id_Stats) REFERENCES Stats(Id_Stats)*/
);
select * from Joute_Score_Joueur;
delete from joute_Score_joueur where id_joute = 50;
create table Joute_Score_Joueur(
	Id_Joute int,
    Id_Joueur int,
    Id_Score int,
    Primary key (Id_Joute, Id_Joueur, Id_Score),
    FOREIGN KEY(Id_Joute) REFERENCES Game(Id_Joute),
	FOREIGN KEY(Id_Joueur) REFERENCES Joueur(Id_Joueur),
    foreign key(Id_Score) references Score(Id_Score)
);
select * from session_table_game;
CREATE TABLE Session_Table_Game(
   Id_Session int,
   Id_Table int,
   Id_Joute int unique,
   PRIMARY KEY(Id_Table, Id_Session, Id_Joute),
   FOREIGN KEY(Id_Table) REFERENCES _Table(Id_Table),
   FOREIGN KEY(Id_Session) REFERENCES Session(Id_Session),
   foreign key(Id_Joute) references game(Id_Joute)
);




/* future table
/* CREATE TABLE Stats(
   Id_Stats int auto_increment,
   GameDate DATE NOT NULL,
   HighScore INT NOT NULL,
   PRIMARY KEY(Id_Stats)
); */

/* select * from Player_Game  */

/* Future tables
CREATE TABLE Player_Game(
   Id_Joute INT,
   Id_Joueur int,
   PRIMARY KEY(Id_Joute, ID_Joueur),
   FOREIGN KEY(Id_Joute) REFERENCES Game(Id_Joute),
   FOREIGN KEY(Id_Joueur) REFERENCES Joueur(Id_Joueur)
);  

CREATE TABLE Game_Table(
   Id_Table int,
   Id_Joute INT,
   PRIMARY KEY(Id_Table, Id_Joute),
   FOREIGN KEY(Id_Table) REFERENCES _Table(Id_Table),
   FOREIGN KEY(Id_Joute) REFERENCES Game(Id_Joute)
);  */

/*
CREATE TABLE Table_Session(
   Id_Table int,
   Id_Session int,
   PRIMARY KEY(Id_Table, Id_Session),
   FOREIGN KEY(Id_Table) REFERENCES _Table(Id_Table),
   FOREIGN KEY(Id_Session) REFERENCES Session(Id_Session)
);  */

use ligue_scrabble;
select * from _table;
select * from game;  
select * from session;
select * from joueur;
delete from game where id_joute = 64;   
select * from Score;
select Total from Score WHERE id_Score = 154;
select * from session_table_game;
select * from Joute_Score_Joueur;
delete from joute_Score_joueur where id_joute = 50;
SELECT * FROM Joute_Score_Joueur WHERE Id_joueur = 4 AND Id_Joute = 68;







