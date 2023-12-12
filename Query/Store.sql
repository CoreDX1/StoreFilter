-- Table for the platforms
CREATE TABLE Platforms
(
    PlatformID UNIQUEIDENTIFIER DEFAULT NEWID(),
    PlatformName VARCHAR(50) UNIQUE NOT NULL,
    PRIMARY KEY (PlatformID)
);

-- Table for the games
CREATE TABLE Games
(
    GameID UNIQUEIDENTIFIER DEFAULT NEWID(),
    Name VARCHAR(100) UNIQUE,
    Price DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    ImageURL VARCHAR(100),
    Description VARCHAR(1000),
    ReleaseDate DATE,
    GenreID INT,
    DeveloperID INT,
    RatingID INT,
    PRIMARY KEY (GameID),
    FOREIGN KEY (GenreID) REFERENCES Genres(GenreID),
    FOREIGN KEY (DeveloperID) REFERENCES Developers(DeveloperID),
    FOREIGN KEY (RatingID) REFERENCES Ratings(RatingID)
);
-- Table for the game genres
CREATE TABLE Genres
(
    GenreID INT PRIMARY KEY,
    GenreName VARCHAR(50) UNIQUE
);
-- Table for the developers
CREATE TABLE Developers
(
    DeveloperID INT PRIMARY KEY,
    DeveloperName VARCHAR(100) UNIQUE
);
-- Table for the game ratings
CREATE TABLE Ratings
(
    RatingID INT PRIMARY KEY,
    RatingValue FLOAT
);
-- Table for the game platforms
CREATE TABLE GamePlatforms
(
    GameID UNIQUEIDENTIFIER,
    PlatformID UNIQUEIDENTIFIER,
    PRIMARY KEY (GameID, PlatformID),
    FOREIGN KEY (GameID) REFERENCES Games(GameID),
    FOREIGN KEY (PlatformID) REFERENCES Platforms(PlatformID)
);

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

INSERT into Games(Name, Price, Stock)
VALUES('Dark souls', 19.99, 20);

insert into GamePlatforms(GameID, PlatformID)
VALUES((select GameID from Games where Name = 'Dark souls'), 'e121c5e9-a277-43cf-be32-fe569df34b52');


select * from Games;
select * from Platforms;
select * from GamePlatforms;

SELECT G.Name AS GameName, P.PlatformName
FROM GamePlatforms AS GP
JOIN Games AS G ON GP.GameID = G.GameID
JOIN Platforms AS P ON GP.PlatformID = P.PlatformID;
