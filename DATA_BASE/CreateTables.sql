use ReliseCourse;
CREATE TABLE Detachment
(
 Id VARCHAR(100) PRIMARY KEY,
 Detachment_name VARCHAR(30) UNIQUE
);
CREATE TABLE Suborder
(
 Id VARCHAR(100) PRIMARY KEY,
 Detachment VARCHAR(100),
 Suborder_name VARCHAR(30) UNIQUE,
 Count_genus INT
);
ALTER TABLE Suborder
ADD FOREIGN KEY(Detachment) REFERENCES Detachment(Id);
CREATE TABLE Species
(
 Id VARCHAR(100) PRIMARY KEY,
 Suborder VARCHAR(100),
 RUS_name VARCHAR(50),
 ENG_name VARCHAR(50),
 FOREIGN KEY (Suborder) REFERENCES Suborder (Id)
);
CREATE TABLE Animal
(
 Id VARCHAR(100) PRIMARY KEY,
 Species VARCHAR(100),
 Descript VARCHAR(500),
 PhotoUrl VARCHAR(100),
 Lineament VARCHAR(200)
 FOREIGN KEY (Species) REFERENCES Species (Id)
);
CREATE TABLE Method
(
 Id VARCHAR(100) PRIMARY KEY,
 Animal VARCHAR(100),
 Descript VARCHAR(500),
 Units VARCHAR(30)
);
CREATE TABLE TEMP_AM
(
 Animal VARCHAR(100) NOT NULL,
 Method VARCHAR(100) NOT NULL,
  FOREIGN KEY (Animal) REFERENCES Animal (Id),
  FOREIGN KEY (Method) REFERENCES Method (Id)
);
ALTER TABLE TEMP_AM
ADD PRIMARY KEY (Animal,Method);
CREATE TABLE Registration_animal
(
 Id VARCHAR(100) PRIMARY KEY,
 Animal VARCHAR(100) NOT NULL,
 Registration_author VARCHAR(100) NOT NULL,
 Coordinates VARCHAR(100) NOT NULL,
  Method VARCHAR(100) NOT NULL,
 FOREIGN KEY (Method) REFERENCES Method (Id),
 FOREIGN KEY (Animal) REFERENCES Animal (Id)
);
CREATE TABLE Registration_author
(
 Id VARCHAR(100) PRIMARY KEY,
 Reg_date DATE UNIQUE,
 Author VARCHAR(100)
);
CREATE TABLE Author
(
 Id VARCHAR(100) PRIMARY KEY,
 Author_name VARCHAR(100),
 Pass VARCHAR(30)
);
ALTER TABLE Registration_author
ADD FOREIGN KEY(Author) REFERENCES Author(Id);
ALTER TABLE Registration_animal
ADD FOREIGN KEY(Registration_author) REFERENCES Registration_author(Id);
CREATE TABLE Publication
(
 Id VARCHAR(100) PRIMARY KEY,
 Author VARCHAR(100),
 Publication_date DATE NOT NULL,
 link VARCHAR(300),
  FOREIGN KEY (Author) REFERENCES Author (Id)
);
CREATE TABLE Ecosystem
(
 Id VARCHAR(100) PRIMARY KEY,
 Ecosystem_name VARCHAR(100),
 Biotope VARCHAR(100)
);
ALTER TABLE Ecosystem
ADD Coordinates VARCHAR(100);

CREATE TABLE Coordinates
(
Id VARCHAR(100) PRIMARY KEY,
GeoJson NVARCHAR(MAX) NOT NULL
)
ALTER TABLE Ecosystem
ADD FOREIGN KEY(Coordinates) REFERENCES Coordinates(Id);
ALTER TABLE Registration_animal
ADD FOREIGN KEY(Coordinates) REFERENCES Coordinates(Id);