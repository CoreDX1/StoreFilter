-- Table for the platforms
CREATE TABLE Platforms
(
    PlatformID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    PlatformName VARCHAR(50) UNIQUE NOT NULL,
    CONSTRAINT PK_Platforms PRIMARY KEY (PlatformID),
    CONSTRAINT UQ_Platforms UNIQUE (PlatformName)
);


-- Table for the game genres
CREATE TABLE Genres
(
    GenreID INT NOT NULL,
    GenreName VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Genres PRIMARY KEY (GenreID),
    CONSTRAINT UQ_GenreName UNIQUE (GenreName)
);


-- Table for the developers
CREATE TABLE Developers
(
    DeveloperID INT NOT NULL,
    DeveloperName VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Developers PRIMARY KEY (DeveloperID),
    CONSTRAINT UQ_DeveloperName UNIQUE (DeveloperName)
);

-- Table for the game ratings
-- CREATE TABLE Ratings
-- (
--     RatingID INT NOT NULL,
--     RatingValue FLOAT NOT NULL CHECK (RatingValue BETWEEN 0 AND 100), -- Assuming ratings are between 0 and 10
--     CONSTRAINT PK_Ratings PRIMARY KEY (RatingID)
-- );

-- Table for the games
CREATE TABLE Games
(
    GameID UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Name VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0), -- Ensure Stock is not negative
    ImageURL VARCHAR(255), -- Increased length for URLs
    Description VARCHAR(MAX), -- Use VARCHAR(MAX) for potentially long text
    ReleaseDate DATE,
    DeveloperID INT,
    Rating FLOAT NOT NULL CHECK (Rating BETWEEN 0 AND 100), -- Assuming ratings are between 0 and 10
    CONSTRAINT PK_Games PRIMARY KEY (GameID),
    CONSTRAINT UQ_GameName UNIQUE (Name),
    CONSTRAINT FK_Games_Developers FOREIGN KEY (DeveloperID) REFERENCES Developers(DeveloperID),
);

CREATE TABLE GameGenres(
    GameID UNIQUEIDENTIFIER NOT NULL,
    GenreID INT NOT NULL,
    CONSTRAINT PK_GameGenres PRIMARY KEY (GameID, GenreID),
    CONSTRAINT FK_GameGenres_Games FOREIGN KEY (GameID) REFERENCES Games(GameID),
)

-- Table for the game platforms
CREATE TABLE GamePlatforms
(
    GameID UNIQUEIDENTIFIER NOT NULL,
    PlatformID UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_GamePlatforms PRIMARY KEY (GameID, PlatformID),
    CONSTRAINT FK_GamePlatforms_Games FOREIGN KEY (GameID) REFERENCES Games(GameID),
    CONSTRAINT FK_GamePlatforms_Platforms FOREIGN KEY (PlatformID) REFERENCES Platforms(PlatformID)
);


-----------------------------

-- Table for the console manufacturers
CREATE TABLE Manufacturers
(
    ManufacturerID INT,
    ManufacturerName VARCHAR(50),
    PRIMARY KEY(ManufacturerID)
);



-- Table for the consoles available in the store
CREATE TABLE Consoles
(
    ConsoleID INT ,
    Name VARCHAR(100),
    ManufacturerID INT,
    Price DECIMAL(10, 2),
    Stock INT,
    PRIMARY KEY(ConsoleID),
    FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
);

-- Table for the customers visiting the store
CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

-- Table to record the sales made
CREATE TABLE Sales
(
    SaleID INT ,
    CustomerID INT,
    SaleDate DATE,
    TotalAmount DECIMAL(10, 2),
    PRIMARY KEY(SaleID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Table to record sale details
CREATE TABLE SaleDetails
(
    DetailID INT,
    SaleID INT,
    GameID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Subtotal DECIMAL(10, 2),
    PRIMARY KEY(DetailID),
    FOREIGN KEY (SaleID) REFERENCES Sales(SaleID),
    FOREIGN KEY (GameID) REFERENCES Games(GameID)
);

insert into Platforms(PlatformName)
VALUES('xbox series'),('pc'),('playstation 5');

insert into Genres(GenreID, GenreName)
VALUES(1, 'Action'),(2, 'RPG'),(3, 'Strategy'), (4, 'Racing'), (5, 'Shooter'), (6, 'Horror');
-- Red Dead Redemption 2	Action-adventure
-- The Witcher 3: Wild Hunt	Role-playing
-- Hollow Knight	Metroidvania
-- Celeste	Platformer
-- Stardew Valley	Simulation
-- Disco Elysium	Role-playing
-- Outer Wilds	Adventure
-- Hades	Roguelike
-- Cuphead	Action
-- Subnautica	Survival

insert into Genres(GenreID, GenreName)
VALUES
(7, 'Action-adventure'),
(8, 'Metroidvania'),
(9, 'Platformer'),
(10, 'Simulation'),
(11, 'Role-playing'),
(12, 'Adventure'),
(13, 'Roguelike'),
(14, 'Survival');


INSERT into Developers(DeveloperID, DeveloperName)
VALUES
(1, 'FromSoftware'),
(2, 'Bandai Namco'),
(3, 'Square Enix'),
(4, 'Rockstar Games'),
(5, 'CD Projekt Red'),
(6, 'Team Cherry'),
(7, 'Matt Makes Games'),
(8, 'ConcernedApe'),
(9, 'ZA/UM'),
(10, 'Mobius Digital'),
(11, 'Supergiant Games'),
(12, 'StudioMDHR'),
(13, 'Unknown Worlds Entertainment');

INSERT into Games(Name, Price, Stock, ReleaseDate, ImageURL, [Description] ,DeveloperID, Rating)
VALUES('DARK SOULS: REMASTERED', 31.99, 20, '2018-03-23', 'DarkSoulsRemastered.png', 'Then, there was fire. Re-experience the critically acclaimed, genre-defining game that started it all. Beautifully remastered, return to Lordran in stunning high-definition detail running at 60fps.', 1, 90);

INSERT into Games(Name, Price, Stock, ReleaseDate, ImageURL, [Description], DeveloperID, Rating)
VALUES
('Red Dead Redemption 2', 39.99, 35, '2018-10-26', 'RedDeadRedemption2.png', 'Embody the life of Arthur Morgan, an outlaw on the run in the Wild West. Live an epic tale of survival, loyalty, and honor in an awe-inspiring open world.', 4, 80),
('The Witcher 3: Wild Hunt', 24.99, 40, '2015-05-19', 'TheWitcher3WildHunt.png', 'Become Geralt of Rivia, a monster hunter in a vast open world full of difficult choices and unexpected consequences.', 5, 90),
('Hollow Knight', 14.99, 50, '2017-02-24', 'HollowKnight.png', 'Descend into the depths of Hallownest, a forgotten kingdom of insects, in this critically acclaimed metroidvania.', 6, 70),
('Celeste', 19.99, 30, '2018-01-25', 'Celeste.png', 'Help Madeline climb Celeste Mountain in this beautiful and challenging platformer.', 7, 8),
('Stardew Valley', 14.99, 45, '2016-02-24', 'StardewValley.png', 'Start a new life on the farm, grow your own food, raise animals, and build your farm in this charming simulation game.', 8, 75),
('Disco Elysium', 34.99, 25, '2019-10-15', 'DiscoElysium.png', 'Become the ultimate detective in this open-world RPG with a unique narrative and innovative dialogue system.', 9, 9),
('Outer Wilds', 24.99, 15, '2019-05-30','OuterWilds.png', 'Explore a miniature solar system, unravel its mysteries, and find out what happened to the Nomai in this space exploration game.', 10, 86),
('Hades', 24.99, 35, '2020-09-17','Hades.png', 'Escape the Underworld in this addictive roguelike with a story full of action and charismatic characters.', 11, 81),
('Cuphead', 19.99, 20, '2017-09-29','Cuphead.png', 'Take Cuphead and Mugman through vibrant run-and-gun levels in this action game with stunning cartoon-style art.', 12, 72),
('Subnautica', 29.99, 40, '2018-01-23','Subnautica.png', 'Survive in an alien ocean full of danger and wonder in this survival and exploration game.', 13, 89);


insert into GamePlatforms(GameID, PlatformID)
VALUES((select GameID from Games where Name = 'DARK SOULS: REMASTERED'), (select PlatformID from Platforms where PlatformName = 'playstation 5'));

-- Drop table
-- drop table Developers;
-- drop table GamePlatforms;
-- drop table Games;
-- drop table Genres;
-- drop table Platforms;
-- drop table Ratings;

select * from Platforms;
select * from Genres;
select * from Games;
select * from GamePlatforms;

SELECT 
    G.Name AS GameName,
    G.Price, 
    G.Rating,
    P.PlatformName
FROM 
    GamePlatforms AS GP
    JOIN Games AS G ON GP.GameID = G.GameID
    JOIN Platforms AS P ON GP.PlatformID = P.PlatformID;