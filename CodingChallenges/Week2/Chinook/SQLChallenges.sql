-- SETUP:
    -- Create a database server (docker)
        -- docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<password>" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
    -- Connect to the server (Azure Data Studio / Database extension)
    -- Test your connection with a simple query (like a select)
    -- Execute the Chinook database (to create Chinook resources in your db)

    SELECT @@VERSION;

USE MyDatabase;
GO

-- On the Chinook DB, practice writing queries with the following exercises

-- BASIC CHALLENGES
-- List all customers (full name, customer id, and country) who are not in the USA
select FirstName, LastName, CustomerId, Country from Customer where Country ='USA';

-- List all customers from Brazil
SELECT * FROM Customer WHERE Country = 'Brazil';

-- List all sales agents

SELECT * from Employee where Title = 'Sales Support Agent';

-- Retrieve a list of all countries in billing addresses on invoices
SELECT DISTINCT BillingCountry from Invoice;


-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
SELECT COUNT (*) AS InvoiceCount, SUM(Total) AS SalesTotal FROM Invoice WHERE YEAR(InvoiceDate) = 2009;


 
-- (challenge: find the invoice count sales total for every year using one query)
SELECT COUNT (*) As InvoiceCount, SUM(Total) As SalesTotal, YEAR(InvoiceDate) As InvoiceYear From Invoice GROUP BY YEAR(InvoiceDate); 

-- how many line items were there for invoice #37
SELECT Count (*) AS LineCount From InvoiceLine WHERE InvoiceId =37;

-- how many invoices per country? BillingCountry  # of invoices -
SELECT BillingCountry, COUNT(*) AS InvoiceCount From Invoice Group BY BillingCountry;

-- Retrieve the total sales per country, ordered by the highest total sales first.
SELECT BillingCountry, SUM(Total) AS TotalSales From Invoice Group BY BillingCountry ORDER BY TotalSales DESC;

-- JOINS CHALLENGES
-- Every Album by Artist
SELECT Artist.Name AS ArtistName, Album.Title AS AlbumTitle FROM Artist JOIN Album ON Artist.ArtistId = Album.ArtistId ORDER BY ArtistName;

-- All songs of the rock genre
SELECT Track.Name AS TrackName, Genre.Name AS GenreName FROM Track JOIN Genre ON Track.GenreId = Genre.GenreId WHERE Genre.Name = 'Rock';


-- Show all invoices of customers from brazil (mailing address not billing)
SELECT Invoice.InvoiceId, Customer.FirstName + ' ' + Customer.LastName AS CustomerName, Customer.Country FROM Invoice JOIN Customer ON Invoice.CustomerId = Customer.CustomerId WHERE Customer.Country = 'Brazil';

-- Show all invoices together with the name of the sales agent for each one
SELECT Invoice.InvoiceId, Employee.FirstName + ' ' +  Employee.LastName AS AgentName FROM Invoice JOIN Customer ON Invoice.CustomerId = Customer.CustomerId JOIN Employee ON Customer.SupportRepId = Employee.EmployeeId;

-- Which sales agent made the most sales in 2009?
SELECT Employee.FirstName + ' ' + Employee.LastName AS AgentName, SUM(Invoice.Total) AS TotalSales FROM Invoice JOIN Customer ON Invoice.CustomerId = Customer.CustomerId JOIN Employee ON Customer.SupportRepId = Employee.EmployeeId WHERE YEAR(Invoice.InvoiceDate) = 2009 GROUP BY Employee.FirstName, Employee.LastName ORDER BY TotalSales DESC;

-- How many customers are assigned to each sales agent?
SELECT Employee.FirstName + ' ' + Employee.LastName AS AgentName, COUNT(Customer.CustomerId) AS CustomerCount FROM Employee LEFT JOIN Customer ON Employee.EmployeeId = Customer.SupportRepId GROUP BY Employee.FirstName, Employee.LastName ORDER BY CustomerCount DESC;

-- Which track was purchased the most ing 20010?
SELECT Track.Name AS TrackName, COUNT(InvoiceLine.TrackId) AS PurchaseCount FROM InvoiceLine JOIN Track ON InvoiceLine.TrackId = Track.TrackId JOIN Invoice ON InvoiceLine.InvoiceId = Invoice.InvoiceId WHERE YEAR(Invoice.InvoiceDate) = 2010 GROUP BY Track.Name ORDER BY PurchaseCount DESC;

-- Show the top three best selling artists.
SELECT Top 3 Artist.Name AS ArtistName, SUM(InvoiceLine.Quantity) AS TotalSold FROM InvoiceLine JOIN Track ON InvoiceLine.TrackId = Track.TrackId JOIN Album ON Track.AlbumId = Album.AlbumId JOIN Artist ON Album.ArtistId = Artist.ArtistId GROUP BY Artist.Name ORDER BY TotalSold DESC;

-- Which customers have the same initials as at least one other customer?

-- ADVACED CHALLENGES
-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.


-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.
