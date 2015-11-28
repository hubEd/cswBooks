USE master
IF EXISTS(select * from sys.databases where name='Bookscsw')
DROP DATABASE Bookscsw

CREATE DATABASE Bookscsw

USE Bookscsw
CREATE TABLE Book
(
	BookId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AuthorId int NOT NULL,
	CategoryId int NOT NULL,	
	Name varchar(255) NOT NULL,
	Pages int NOT NULL
);
CREATE TABLE Author
(
	AuthorId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL,
);
CREATE TABLE Category
(
	CategoryId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL
);

ALTER TABLE Book
ADD CONSTRAINT fk_Book_Author
FOREIGN KEY (AuthorId)
REFERENCES Author(AuthorId)

ALTER TABLE Book
ADD CONSTRAINT fk_Book_Category
FOREIGN KEY (CategoryId)
REFERENCES Category(CategoryId)

--AUTHORS------------------------------------------------------------
---------------------------------------------------------------------
INSERT INTO Author(Name)
VALUES ('Suzanne Collins');
INSERT INTO Category(Name)
VALUES ('Adventure');
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (1, 1, 'The Hunger Games', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (1, 1, 'Catching Fire', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (1, 1, 'Mockingjay', 1);

INSERT INTO Author(Name)
VALUES ('J. K. Rowling');
INSERT INTO Category(Name)
VALUES ('Fantasy');
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (2, 2, 'Harry Potter and the Philosophers Stone', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (2, 2, 'Harry Potter and the Chamber of Secrets ', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (2, 2, 'Harry Potter and the Prisoner of Azkaban', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (2, 2, 'Harry Potter and the Goblet of Fire', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (2, 2, 'Harry Potter and the Order of the Phoenix', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (2, 2, 'Harry Potter and the Half-Blood Prince', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (2, 2, 'Harry Potter and the Deathly Hallows', 1);

INSERT INTO Author(Name)
VALUES ('Stephenie Meyer');
INSERT INTO Category(Name)
VALUES ('Romance');
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (3, 3, 'Twilight', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (3, 3, 'New Moon ', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (3, 3, 'Eclipse', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (3, 3, 'Breaking Dawn', 1);

INSERT INTO Author(Name)
VALUES ('Stieg Larsson');
INSERT INTO Category(Name)
VALUES ('Crime');
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (4, 4, 'The Girl with the Dragon Tattoo', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (4, 4, 'The Girl Who Played with Fire', 1);
INSERT INTO Book(AuthorId, CategoryId, Name, Pages)
VALUES (4, 4, 'The Girl Who Kicked the Hornets Nest', 1);
------------------------------------------------------------------------


