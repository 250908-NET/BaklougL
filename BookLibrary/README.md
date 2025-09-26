BookLibrary is an ASP.NET Core Minimal API project designed to manage books and users in a library system. The application communicates through HTTP requests and persists data to a SQL Server database running in a Docker container.

🚀 Features

* Built with ASP.NET Core Minimal API

* Supports CRUD operations via HTTP(S):

- GET → Retrieve resources

- POST → Create resources

- DELETE → Remove resources

* Data persistence with SQL Server in Docker

* Entity Framework Core for database communication

* Includes DTOs (Data Transfer Objects) for clean API responses

* Unit tests with ≥ 23% coverage

* ERD diagram of models & relationships

* At least one many-to-many relationship

* Core entities:

- Book: A Book can have many Loans.

- User :A User can have many Loans.

- Loan: The Loan table is the bridge/junction that resolves the many-to-many relationship between User and Book

* User ↔ Loan = one-to-many

* Book ↔ Loan = one-to-many

* User ↔ Book = many-to-many (through Loan)
