
-- 1. List the Top 5 Most Borrowed Books
SELECT TOP 5 
    b.BookId, b.Title, b.Author, COUNT(br.BorrowId) AS TimesBorrowed
FROM BorrowRecords br
JOIN Books b ON br.BookId = b.BookId
GROUP BY b.BookId, b.Title, b.Author
ORDER BY TimesBorrowed DESC;
Go

-- 2. Members Who Borrowed More Than 3 Books in the Last Month

-- (Last month = 2025-09-02 to 2025-10-02)

SELECT m.MemberId, m.Name, m.Email, COUNT(br.BorrowId) AS BooksBorrowed
FROM BorrowRecords br
JOIN Members m ON br.MemberId = m.MemberId
WHERE br.BorrowDate >= DATEADD(MONTH, -1, '2025-10-02')
GROUP BY m.MemberId, m.Name, m.Email
HAVING COUNT(br.BorrowId) > 3;
Go


-- 3. Stored Procedure to Return Overdue Books

CREATE PROCEDURE GetOverdueBooks
AS
BEGIN
    SELECT 
        br.BorrowId,
        m.Name AS MemberName,
        b.Title AS BookTitle,
        br.BorrowDate,
        DATEADD(DAY, 14, br.BorrowDate) AS DueDate
    FROM BorrowRecords br
    JOIN Members m ON br.MemberId = m.MemberId
    JOIN Books b ON br.BookId = b.BookId
    WHERE br.IsReturned = 0
      AND DATEADD(DAY, 14, br.BorrowDate) < '2025-10-02';
END;
Go

EXEC GetOverdueBooks;


--4. Get All Books Currently Borrowed by a Given Member
DECLARE @MemberId INT = 1;

SELECT 
    b.BookId, b.Title, b.Author, br.BorrowDate
FROM BorrowRecords br
JOIN Books b ON br.BookId = b.BookId
WHERE br.MemberId = @MemberId
  AND br.IsReturned = 0;
