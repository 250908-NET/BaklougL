# Project 1

## Overview (Due: 09/26/2025)

For this project, you'll create an ASP.NET Core MinimalAPI project, where the application will be interacting with users via HTTP calls. The project will conclude with a presentation of working software to trainers and colleagues.

## Requirements

- Project hosted on GitHub
- README that describes the application and its functionalities
- The application should be ASP.NET Core Minimal API application
- The application should build and run
- The application should have unit tests and at least 20% coverage
- The application should communicate via HTTP(s) (Must have POST, GET, DELETE)
- Have 1 or more DTOs
- ERD of your models and the relationships between them
- Have at least one many to many (m-m) relationship between the models in your app
- Have 2 or more models
- Persisting data to a SQL Server DB running in a Docker container
- The application should communicate to DB via EF Core (Entity Framework Core)

## Presentation

- Your presentation should demonstrate functionality of your application
- You can demo your API via Swagger, ThunderClient, Postman, or similar
- Powerpoint (optional)
- Please keep the length of presentation to 5-10 minutes

## Half-way Expectations (09/24/2025)

- Repo setup
- Minimal API and Xunit project setup and connected (at least one test written)
- Model(s) and Repo(s) layer file structure setup
- At least 1 endpoint tie to a model
- README.md
- ERD


📚 Book Library API

A Book Library application built with ASP.NET Core Minimal API. This app allows managing books and users, exposing HTTP endpoints for interaction, persisting data to a SQL Server database, and includes unit testing using xUnit.

The project demonstrates a many-to-many relationship between books and users: a user can borrow multiple books, and each book can be borrowed by multiple users over time.

📝 Features

Books

Add, view, update, and delete books

Track details: title, author, ISBN, genre, published date

Users

Add and manage library users

Store user details: name, email, membership date

Borrowing

Many-to-many relationship: Users ↔ Books

Track which users have borrowed which books

API

Fully RESTful HTTP endpoints

JSON request/response format

Testing

Unit tested using xUnit

Database

Persisted to SQL Server using Entity Framework Core

🏗️ Models
Book

Id – Unique identifier

Title – Book title

Author – Author name

ISBN – Unique ISBN number

Genre – Book genre

PublishedDate – Date of publication

Users – List of users who borrowed the book (many-to-many)

User

Id – Unique identifier

Name – Full name

Email – Unique email address

MembershipDate – Date user joined

Books – List of borrowed books (many-to-many)

UserBook (Join Table for Many-to-Many)

UserId – Foreign key to User

BookId – Foreign key to Book

BorrowedDate – Date the book was borrowed

ReturnedDate – Optional return date