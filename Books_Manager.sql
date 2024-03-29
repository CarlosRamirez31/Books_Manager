CREATE DATABASE Books_Manager;
Use Books_Manager;

CREATE TABLE Authors(
AuthorId INT IDENTITY(1,1),
FirstName VARCHAR(120) NOT NULL,
LastName VARCHAR(120) NOT NULL,
PhoneNumber INT NULL,
Country VARCHAR(90) NULL,
[Address] VARCHAR(120) NULL,
City VARCHAR(80) NULL,
CreateBy VARCHAR(80) NULL,
Created DATETIME NULL,
LastModifiedBy VARCHAR(80) NULL,
LastModified DATETIME NULL,
PRIMARY KEY (AuthorId)
);

CREATE TABLE Biographies(
AuthorId INT UNIQUE NOT NULL,
Biography VARCHAR(255),
);

CREATE TABLE Books(
BookId INT IDENTITY(1,1),
Title VARCHAR(150) NOT NULL,
BookDescription varchar(250) NOT NULL,
Price INT NOT NULL,
PublicationDate DATETIME NOT NULL,
CreateBy VARCHAR(80) NULL,
Created DATETIME NULL,
LastModifiedBy VARCHAR(80) NULL,
LastModified DATETIME NULL,
PRIMARY KEY (BookId)
);

CREATE TABLE Photographs(
PhotographyId INT IDENTITY(1,1),
Image_Path VARCHAR(200) NOT NULL,
AuthorId INT NOT NULL,
CreateBy VARCHAR(80) NOT NULL,
Created DATETIME NOT NULL,
LastModifiedBy VARCHAR(80) NULL,
LastModified DATETIME NULL,
PRIMARY KEY (PhotographyId)
);

CREATE TABLE AuthorsBooks(
AuthorId INT NOT NULL,
BookId INT NOT NULL
);

CREATE TABLE Comments(
CommentId INT IDENTITY(1,1),
Content VARCHAR(255) NOT NULL,
BookId INT NOT NULL,
CreateBy VARCHAR(80) NULL,
Created DATETIME NULL,
LastModifiedBy VARCHAR(80) NULL,
LastModified DATETIME NULL,
PRIMARY KEY (CommentId)
);

ALTER TABLE Photographs
ADD CONSTRAINT PK_Photographs_AuthorId FOREIGN KEY (AuthorId) REFERENCES Authors (AuthorId) ON DELETE CASCADE;

ALTER TABLE Biographies
ADD CONSTRAINT PK_Biographies_AuthorId FOREIGN KEY (AuthorId) REFERENCES Authors (AuthorId) ON DELETE CASCADE;

ALTER TABLE AuthorsBooks
ADD CONSTRAINT PK_AuthorsBooks_AuthorId FOREIGN KEY (AuthorId) REFERENCES Authors (AuthorId) ON DELETE CASCADE;

ALTER TABLE AuthorsBooks
ADD CONSTRAINT PK_BooksAuthors_BookId FOREIGN KEY (BookId) REFERENCES Books (BookId) ON DELETE CASCADE;

ALTER TABLE Comments
ADD CONSTRAINT PK_Comments_BookId FOREIGN KEY (BookId) REFERENCES Books (BookId) ON DELETE CASCADE;

