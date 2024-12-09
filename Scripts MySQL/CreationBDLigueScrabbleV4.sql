use ligue_scrabble;
drop database ligue_scrabble;
create database ligue_scrabble;
select * from ligue_scrabble;
show databases;
show tables;



CREATE TABLE _Table(
	ID_Table int auto_increment,
   No_Table int,
   PRIMARY KEY(ID_Table)
);

/*alter table _Table modify No_Table int;*/

CREATE TABLE Session(
	Id_Rencontre int auto_increment,
   Date_rencontre DATETIME,
   PRIMARY KEY(Id_Rencontre)
);

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
    Bonus int,
    Penalite int,
    Total int,
    primary key (Id_Score)
    )
    
;
CREATE TABLE Game(
   Id_Joute int auto_increment,
   No_Partie int not null,
   PlayerOne VARCHAR(50),
   PlayerTwo VARCHAR(50),
   PlayerThree VARCHAR(50),
   PlayerFour VARCHAR(50),
   PRIMARY KEY(Id_Joute)
);

CREATE TABLE Stats(
   Id_Stats int auto_increment,
   GameDate DATE NOT NULL,
   HighScore INT NOT NULL,
   PRIMARY KEY(Id_Stats)
);



CREATE TABLE Joueur(
   Id_Joueur int auto_increment,
   Code_Joueur CHAR(1),
   Nom VARCHAR(50),
   Pseudo VARCHAR(50),
   Id_Stats INT,
   PRIMARY KEY(ID_Joueur),
   UNIQUE(Id_Stats),
   FOREIGN KEY(Id_Stats) REFERENCES Stats(Id_Stats)
);

create table Joute_Score_Joueur(
	Id_Joute int,
    ID_Joueur int,
    Id_Score int,
    Primary key (Id_Joute, ID_Joueur, ID_Score),
    FOREIGN KEY(Id_Joute) REFERENCES Game(Id_Joute),
	FOREIGN KEY(ID_Joueur) REFERENCES Joueur(ID_Joueur),
    foreign key(ID_Score) references Score(Id_Score)
);

CREATE TABLE Player_Game(
   Id_Joute INT,
   ID_Joueur int,
   PRIMARY KEY(Id_Joute, ID_Joueur),
   FOREIGN KEY(Id_Joute) REFERENCES Game(Id_Joute),
   FOREIGN KEY(ID_Joueur) REFERENCES Joueur(ID_Joueur)
);

CREATE TABLE Game_Table(
   Id_Table int,
   Id_Joute INT,
   PRIMARY KEY(Id_Table, Id_Joute),
   FOREIGN KEY(Id_Table) REFERENCES _Table(Id_Table),
   FOREIGN KEY(Id_Joute) REFERENCES Game(Id_Joute)
);

CREATE TABLE Table_Session(
   Id_Table int,
   Id_Rencontre int,
   PRIMARY KEY(Id_Table, ID_rencontre),
   FOREIGN KEY(Id_Table) REFERENCES _Table(Id_Table),
   FOREIGN KEY(ID_Rencontre) REFERENCES Session(ID_Rencontre)
);

CREATE TABLE Session_Table_Game(
   Id_Rencontre int,
   Id_Table int,
   Id_Joute int,
   PRIMARY KEY(Id_Table, Id_rencontre, Id_Joute),
   FOREIGN KEY(Id_Table) REFERENCES _Table(Id_Table),
   FOREIGN KEY(ID_Rencontre) REFERENCES Session(ID_Rencontre),
   foreign key(Id_Joute) references game(Id_Joute)
);
select * from session;


insert into Stats (GameDate, HighScore) values ('2024-11-20', 0);
insert into Joueur (ID_Joueur, Nom, Pseudo) values ('A', 'Ch.-Aimé', 'Orchidée');
show tables;
select * from table_session;


