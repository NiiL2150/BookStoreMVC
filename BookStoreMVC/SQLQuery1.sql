﻿USE master
DROP DATABASE BookStore3

CREATE DATABASE BookStore3
USE BookStore3

CREATE TABLE Authors(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(max) NOT NULL,
)

CREATE TABLE Genres(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(max) NOT NULL,
)

CREATE TABLE Books(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Title nvarchar(max) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	Price money NOT NULL CHECK(Price >= 0) DEFAULT(0),
	Pages int NOT NULL CHECK(Pages > 0) DEFAULT(1),
)

CREATE TABLE BookGenres(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	BookId int NOT NULL FOREIGN KEY REFERENCES Books(Id) ON DELETE CASCADE,
	GenreId int NOT NULL FOREIGN KEY REFERENCES Genres(Id) ON DELETE CASCADE,
)

CREATE TABLE BookAuthors(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	BookId int NOT NULL FOREIGN KEY REFERENCES Books(Id) ON DELETE CASCADE,
	AuthorId int NOT NULL FOREIGN KEY REFERENCES Authors(Id) ON DELETE CASCADE,
)

CREATE TRIGGER insert_book
ON Books
AFTER INSERT
AS
BEGIN
	SELECT Id FROM inserted
END

CREATE TRIGGER insert_author
ON Authors
AFTER INSERT
AS
BEGIN
	SELECT Id FROM inserted
END

CREATE TRIGGER insert_genre
ON Genres
AFTER INSERT
AS
BEGIN
	SELECT Id FROM inserted
END