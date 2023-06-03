Create table Books(Id int primary key identity, authorForename varchar(30), AuthorSurname varchar(30), Title varchar(50),pages int, price varchar(7))
drop table Books
INSERT Books VALUES( 'Emily', 'Bronte', 'Wuthering Heights',456,'$7.99');
INSERT Books VALUES( 'Harper', 'Lee', 'To Kill a Mockingbird',249,'$5.69');
INSERT Books VALUES( 'R.L', 'Stevenson', 'Treasure Island',181,'$4.99');
INSERT Books VALUES( 'Ayn', 'Rand', 'Atlas Shrugged',659,'$5.99');
INSERT Books VALUES( 'Ayn', 'Rand', 'The Fountainhead',555,'$3.99');
INSERT Books VALUES( 'Charles', 'Darwin', 'The Origins of Species',129,'$4.59');
INSERT Books VALUES( 'John', 'Steinbeck', 'Of Mice and Men',250,'$6.99');
INSERT Books VALUES( 'Stephen', 'King', '11/22/63',898,'$12.99');
INSERT Books VALUES( 'Toni', 'Morrison', 'Beloved',350,'$7.95');
INSERT Books VALUES( 'H.B', 'Stowe', 'Uncle Toms Cabin',674,'$6.99');
INSERT Books VALUES( 'Stephen', 'King', 'The Shining',421,'$5.99');
INSERT Books VALUES( 'J.K', 'Rowling', 'Harry Potter',1044,'$9.99');
INSERT Books VALUES( 'Stephen', 'King', 'Misery',494,'$13.49');
INSERT Books VALUES( 'Virginia', 'Woolf', 'Mrs Dalloway',323,'$3.99');
INSERT Books VALUES( 'Charlotte', 'Bronte', 'Jane Eyre',403,'$13.99');
INSERT Books VALUES( 'Fyodor', 'Dostoevskyy', 'The Idiot',839,'$5.95');
INSERT Books VALUES( 'Phillip', 'Roth', 'The Ghost Writer',130,'$2.49');
INSERT Books VALUES( 'Leo', 'Tolstoy', 'War and Peace',1650,'$4.99');
INSERT Books VALUES( 'Fyodor', 'Dostoevskyy', 'The Brothers Karamazov',1323,'$15.95');
INSERT Books VALUES( 'Leo', 'Tolstoy', 'Anna Karenina',1232,'$16.99');
Select * from Books
Create table publishingInfo (Id int primary key identity, publisherName varchar(30), publishingYear int, bookType varchar(20), publishingId int foreign key references [Books] (Id) ON DELETE CASCADE)
drop table publishingInfo
INSERT publishingInfo VALUES('Simon & Schuster', 2021, 'Paperback',1);
INSERT publishingInfo VALUES('HarperCollins', 1983, 'Hardcover',2);
INSERT publishingInfo VALUES('Simon & Schuster', 2020, 'Paperback',3);
INSERT publishingInfo VALUES('HarperCollins', 1993, 'Paperback',4);
INSERT publishingInfo VALUES('Simon & Schuster', 2009, 'Hardcover',5);
INSERT publishingInfo VALUES('HarperCollins', 2003, 'Hardcover',6);
INSERT publishingInfo VALUES('Penguin Random House', 1990, 'Hardcover',7);
INSERT publishingInfo VALUES('Simon & Schuster', 1986, 'Hardcover',8);
INSERT publishingInfo VALUES('Penguin Random House', 2017, 'Hardcover',9);
INSERT publishingInfo VALUES('Macmillan Publishers', 1981, 'Paperback',10);
INSERT publishingInfo VALUES('Simon & Schuster', 1993, 'Paperback',11);
INSERT publishingInfo VALUES('Penguin Random House', 2017, 'Paperback',12);
INSERT publishingInfo VALUES('Penguin Random House', 2004, 'Paperback',13);
INSERT publishingInfo VALUES('HarperCollins', 1979, 'Paperback',14);
INSERT publishingInfo VALUES('Macmillan Publishers', 1984, 'Paperback',15);
INSERT publishingInfo VALUES('HarperCollins', 1999, 'Hardcover',16);
INSERT publishingInfo VALUES('Macmillan Publishers', 1998, 'Hardcover',17);
INSERT publishingInfo VALUES('HarperCollins', 2011, 'Hardcover',18);
INSERT publishingInfo VALUES('Penguin Random House', 2018, 'Paperback',19);
INSERT publishingInfo VALUES('HarperCollins', 1981, 'Paperback',20);
Select * from publishingInfo

create proc Get_All_Elements
as
Select Books.Id, Books.authorForename, Books.AuthorSurname, Books.Title, Books.price,Books.pages, publishingInfo.publisherName, publishingInfo.publishingYear, publishingInfo.bookType  from Books
inner join publishingInfo
on Books.Id = publishingInfo.publishingId
go