
CREATE TABLE Conducts
(
	tournament_id        INTEGER NOT NULL,
	organizer_id         INTEGER NOT NULL,
	CONSTRAINT XPKConducts PRIMARY KEY (tournament_id,organizer_id)
);

CREATE TABLE Country
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	name                 VARCHAR(128) NULL,
	alphacode            VARCHAR(20) NULL,
	CONSTRAINT XPKCountry PRIMARY KEY (id)
);

CREATE TABLE Federation
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	name                 VARCHAR(128) NOT NULL,
	abbreviation         VARCHAR(20) NULL,
	headquarters         VARCHAR(128) NULL,
	president_name       VARCHAR(128) NULL,
	foundation_date      VARCHAR(128) NULL,
	website              VARCHAR(128) NULL,
	CONSTRAINT XPKFederation PRIMARY KEY (id)
);

CREATE TABLE Game
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	name                 VARCHAR(128) NOT NULL,
	start_time           DATE NOT NULL,
	tournament_id        INTEGER NOT NULL,
	end_time             DATE NOT NULL,
	CONSTRAINT XPKMatch PRIMARY KEY (id)
);

CREATE TABLE Move
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	player_id            INTEGER NOT NULL,
	from_square          VARCHAR(2) NOT NULL,
	to_square            VARCHAR(2) NOT NULL,
	time                 DATETIME NULL,
	is_capturing         BIT NULL,
	is_check             BIT NULL,
	piece_id             INTEGER NOT NULL,
	game_id              INTEGER NOT NULL,
	CONSTRAINT XPKMove PRIMARY KEY (id)
);

CREATE TABLE Organizer
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	name                 VARCHAR(128) NULL,
	website              VARCHAR(128) NULL,
	CONSTRAINT XPKOrganizer PRIMARY KEY (id)
);

CREATE TABLE Participates_in
(
	player_id            INTEGER NOT NULL,
	game_id              INTEGER NOT NULL,
	CONSTRAINT XPKParticipates_in PRIMARY KEY (game_id,player_id)
);

CREATE TABLE Piece
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	color                BIT NOT NULL,
	square               VARCHAR(2) NULL,
	player_id            INTEGER NOT NULL,
	type                 INTEGER NOT NULL,
	CONSTRAINT XPKPiece PRIMARY KEY (id)
);

CREATE TABLE Player
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	firstname            VARCHAR(128) NOT NULL,
	lastname             VARCHAR(128) NOT NULL,
	rank                 INTEGER NULL,
	phone_number         VARCHAR(32) NULL,
	gender               INTEGER NOT NULL,
	birth_date           DATE NULL,
	country_id           INTEGER NOT NULL,
	CONSTRAINT XPKPlayer PRIMARY KEY (id)
);

CREATE TABLE Result
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	game_id              INTEGER NOT NULL,
	type                 INTEGER NULL,
	CONSTRAINT XPKResult PRIMARY KEY (id)
);

CREATE TABLE Title
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	name                 VARCHAR(128) NOT NULL,
	date                 DATE NOT NULL,
	player_id            INTEGER NOT NULL,
	CONSTRAINT XPKTitle PRIMARY KEY (id)
);

CREATE TABLE Tournament
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	name                 VARCHAR(128) NOT NULL,
	start_date           DATE NOT NULL,
	end_date             DATE NOT NULL,
	country_id           INTEGER NOT NULL,
	CONSTRAINT XPKTournament PRIMARY KEY (id)
);

CREATE TABLE Transfer
(
	date                 DATE NOT NULL,
	fee                  INTEGER NULL,
	player_id            INTEGER NOT NULL,
	former_federation_id INTEGER NOT NULL,
	new_federation_id    INTEGER NOT NULL,
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	CONSTRAINT XPKTransfer PRIMARY KEY (id)
);

CREATE TABLE Visitor
(
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	name                 VARCHAR(128) NOT NULL,
	email                VARCHAR(128) NOT NULL,
	password             VARCHAR(128) NOT NULL,
	CONSTRAINT XPKUser PRIMARY KEY (id)
);

CREATE TABLE Vote
(
	game_id              INTEGER NOT NULL,
	player_id            INTEGER NOT NULL,
	visitor_id           INTEGER NOT NULL,
	id                   INTEGER NOT NULL AUTO_INCREMENT,
	CONSTRAINT XPKVote PRIMARY KEY (id)
);

ALTER TABLE Conducts
ADD CONSTRAINT is_conducted FOREIGN KEY (tournament_id) REFERENCES Tournament (id);

ALTER TABLE Conducts
ADD CONSTRAINT arranges FOREIGN KEY (organizer_id) REFERENCES Organizer (id);

ALTER TABLE Game
ADD CONSTRAINT consists_of FOREIGN KEY (tournament_id) REFERENCES Tournament (id);

ALTER TABLE Move
ADD CONSTRAINT starts FOREIGN KEY (player_id) REFERENCES Player (id);

ALTER TABLE Move
ADD CONSTRAINT makes FOREIGN KEY (piece_id) REFERENCES Piece (id);

ALTER TABLE Move
ADD CONSTRAINT has FOREIGN KEY (game_id) REFERENCES Game (id);

ALTER TABLE Participates_in
ADD CONSTRAINT plays_in FOREIGN KEY (player_id) REFERENCES Player (id);

ALTER TABLE Participates_in
ADD CONSTRAINT is_between FOREIGN KEY (game_id) REFERENCES Game (id);

ALTER TABLE Piece
ADD CONSTRAINT controlls FOREIGN KEY (player_id) REFERENCES Player (id);

ALTER TABLE Player
ADD CONSTRAINT produces FOREIGN KEY (country_id) REFERENCES Country (id);

ALTER TABLE Result
ADD CONSTRAINT results_in FOREIGN KEY (game_id) REFERENCES Game (id);

ALTER TABLE Title
ADD CONSTRAINT holds FOREIGN KEY (player_id) REFERENCES Player (id);

ALTER TABLE Tournament
ADD CONSTRAINT takes_place FOREIGN KEY (country_id) REFERENCES Country (id);

ALTER TABLE Transfer
ADD CONSTRAINT signs_for FOREIGN KEY (player_id) REFERENCES Player (id);

ALTER TABLE Transfer
ADD CONSTRAINT releases FOREIGN KEY (former_federation_id) REFERENCES Federation (id);

ALTER TABLE Transfer
ADD CONSTRAINT approves FOREIGN KEY (new_federation_id) REFERENCES Federation (id);

ALTER TABLE Vote
ADD CONSTRAINT gets FOREIGN KEY (game_id) REFERENCES Game (id);

ALTER TABLE Vote
ADD CONSTRAINT receives FOREIGN KEY (player_id) REFERENCES Player (id);

ALTER TABLE Vote
ADD CONSTRAINT leaves FOREIGN KEY (visitor_id) REFERENCES Visitor (id);
