CREATE TABLE Games (
    GameId INT PRIMARY KEY,
    Name NVARCHAR(100),
    Platform INT, -- Use INT for enums or TINYINT if desired
    Price DECIMAL(10, 2),
    Stock INT
);

CREATE TABLE Console (
    ConsoleId INT PRIMARY KEY,
    Name NVARCHAR(100),
    Manufacturer NVARCHAR(100),
    Price NVARCHAR(20), -- Assuming price might contain symbols like '$', can use DECIMAL if needed
    Stock INT
);

CREATE TABLE ConsoleGames (
    ConsoleId INT,
    GameId INT,
    FOREIGN KEY (ConsoleId) REFERENCES Console(ConsoleId),
    FOREIGN KEY (GameId) REFERENCES Games(GameId),
    PRIMARY KEY (ConsoleId, GameId)
);

CREATE TABLE Customers (
    CustomerID NVARCHAR(50) PRIMARY KEY
);
