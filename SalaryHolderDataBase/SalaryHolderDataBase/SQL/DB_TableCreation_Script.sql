-- Creating tables --
CREATE TABLE UsersList (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(255) NULL,
    UserPassword NVARCHAR(16) NULL
);

CREATE TABLE Bogcha (
    BogCha_ID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NULL,
    Description NVARCHAR(255) NULL,
    HireDate DATETIME NULL,
    FireDate DATETIME NULL,
    Salary DECIMAL(10,2) NULL,
    IsWorking BIT NULL,
    GroupAmount INT NULL,
    ZavName NVARCHAR(255) NULL,
    UserID INT NULL,
    FOREIGN KEY (UserID) REFERENCES UsersList(UserID)
);

CREATE TABLE SalaryTable (
    Sal_ID INT IDENTITY(1,1) PRIMARY KEY,
    SalaryDate DATETIME NULL,
    SalaryAmount DECIMAL(10, 2) NULL,
    Description NVARCHAR(200) NULL,
    BogCha_ID INT NULL,
    UserID INT NULL,
    FOREIGN KEY (BogCha_ID) REFERENCES Bogcha(BogCha_ID),
    FOREIGN KEY (UserID) REFERENCES UsersList(UserID)
);



-- DROP table SalaryTable
-- DROP table Bogcha
-- DROP table UsersList

Insert into UsersList (UserName, UserPassword)
values ('Кариева Дилфуза Усмановна', 'Владелец')




