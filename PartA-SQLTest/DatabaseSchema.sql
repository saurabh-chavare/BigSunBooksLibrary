
-- Book Table
CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    ISBN NVARCHAR(20) NOT NULL,
    PublishedYear INT NOT NULL,
    AvailableCopies INT NOT NULL
);

-- Member Table
CREATE TABLE Members (
    MemberId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Phone NVARCHAR(20),
    JoinDate DATE NOT NULL
);


-- BorrowRecord Table
CREATE TABLE BorrowRecords (
    BorrowId INT IDENTITY(1,1) PRIMARY KEY,
    MemberId INT NOT NULL,
    BookId INT NOT NULL,
    BorrowDate DATE NOT NULL,
    ReturnDate DATE NULL,
    IsReturned BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (MemberId) REFERENCES Members(MemberId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId)
);