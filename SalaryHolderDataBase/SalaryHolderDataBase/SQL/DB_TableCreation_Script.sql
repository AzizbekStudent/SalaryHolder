-- Creating tables --
CREATE TABLE UsersList (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(255),
    UserPassword NVARCHAR(16)
);


CREATE TABLE Bogcha (
    BogCha_ID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255),
    Description NVARCHAR(255),
    HireDate DATETIME,
    FireDate DATETIME,
    Salary DECIMAL(10,2),
    IsWorking BIT,
    GroupAmount INT,
    ZavName NVARCHAR(255),
    UserID int
    FOREIGN KEY (UserID) REFERENCES UsersList(UserID)
);



CREATE TABLE SalaryTable (
    Sal_ID INT IDENTITY(1,1) PRIMARY KEY,
    SalaryDate DATETIME,
    SalaryAmount DECIMAL(10, 2),
    Description NVARCHAR(200),
    BogCha_ID INT,
    UserID INT,

    FOREIGN KEY (BogCha_ID) REFERENCES Bogcha(BogCha_ID),
    FOREIGN KEY (UserID) REFERENCES UsersList(UserID)
);



-- DROP table SalaryTable
-- DROP table Bogcha
-- DROP table UsersList
