IF (NOT EXISTS (SELECT * FROM dbo.Books))
    INSERT INTO dbo.Books (Author, Name, Isbn)
    VALUES ('Gibson','Virtual Light','97831614'),
		   ('Dreiser','The Titan','1714100'),
	       ('Dickens','Doctor Marigold','90001')

IF (NOT EXISTS (SELECT * FROM dbo.Categories))
    INSERT INTO dbo.Categories (Name, CreationDate)
    VALUES ('Fantastic','2015-06-02'),
	       ('Adventure','2015-06-05')

IF (NOT EXISTS (SELECT * FROM dbo.BooksCategories))
    INSERT INTO dbo.BooksCategories (BookId, CategoryId)
    VALUES (1, 1),
	       (2, 1)



