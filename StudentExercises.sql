USE MASTER
GO

IF NOT EXISTS (
    SELECT [name]
    FROM sys.databases
    WHERE [name] = N'StudentExercises'
)
CREATE DATABASE StudentExercises
GO

USE StudentExercises
GO


DROP TABLE IF EXISTS Student;
DROP TABLE IF EXISTS Cohort;
DROP TABLE IF EXISTS Instructor;
DROP TABLE IF EXISTS Exercise;

CREATE TABLE Cohort (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CohortName VARCHAR(55) NOT NULL
);

CREATE TABLE Student (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
    LastName VARCHAR(55) NOT NULL,
    Slack VARCHAR(55) NOT NULL,
    CohortId INT NOT NULL,
    CONSTRAINT FK_CohortId FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Instructor (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(55) NOT NULL,
    LastName VARCHAR(55) NOT NULL,
    Slack VARCHAR(55) NOT NULL,
    CohortId INT,
    Specialty VARCHAR(55),
    CONSTRAINT FK_CohortIdInstructor FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Exercise (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ExerciseName VARCHAR(55) NOT NULL,
    ExerciseLanguage VARCHAR(55) NOT NULL
);

CREATE TABLE StudentExercise (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    ExerciseId INT NOT NULL,
    CONSTRAINT FK_StudentId FOREIGN KEY(StudentId) REFERENCES Student(Id),
    CONSTRAINT FK_ExerciseId FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id)
);

-- create cohorts
INSERT INTO Cohort (CohortName) VALUES ('c30');
INSERT INTO Cohort (CohortName) VALUES ('c31');
INSERT INTO Cohort (CohortName) VALUES ('c32');

-- create students
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Jonathan','Schaffer', 'jonizzy', 2);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Rose','Witzosky', 'roseland', 2);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Meag','Mueller', 'gothy', 2);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Billy','Mathison', 'geekybilly', 1);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Anne','Vick', 'gothyhotty', 1);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Alex','Thacker', 'lander', 1);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Chris','Morgan', 'nerd', 3);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Sam','Britt', 'red', 3);
INSERT INTO Student (FirstName, LastName, Slack, CohortId) VALUES ('Jameka','Echols', 'meka', 3);

-- create instructors
INSERT INTO Instructor (FirstName, LastName, Slack, CohortId, Specialty) VALUES ('Jisie', 'Davis', 'jisis', 3, 'C');
INSERT INTO Instructor (FirstName, LastName, Slack, CohortId, Specialty) VALUES ('Andy', 'Collins', 'andyc', 1, 'C#');
INSERT INTO Instructor (FirstName, LastName, Slack, CohortId, Specialty) VALUES ('Steve', 'Brownlee', 'steveeee', 2, 'JavaScript');
INSERT INTO Instructor (FirstName, LastName, Slack, CohortId, Specialty) VALUES ('Joe', 'Shepard', 'joe', 2, 'Python');
INSERT INTO Instructor (FirstName, LastName, Slack, CohortId, Specialty) VALUES ('Kristen', 'Norris', 'knorris', 1, 'Ruby');
INSERT INTO Instructor (FirstName, LastName, Slack, CohortId, Specialty) VALUES ('Leah', 'Hoefling', 'leahh', 3, 'R');
INSERT INTO Instructor (FirstName, LastName, Slack, CohortId, Specialty) VALUES ('Madi', 'Peper', 'Madi', 3, 'Java');

-- create exercises
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Ternary Traveler', 'JavaScript');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Gary Garage', 'C#');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Reactive Nutshell', 'React');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Colors', 'JavaScript');
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ('Student Ex', 'C#');

-- create student's exercises
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (1,3);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (1,2);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (2,1);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (2,4);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (3,5);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (3,1);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (4,2);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (4,3);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (5,1);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (5,4);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (6,2);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (6,3);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (7,2);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (7,5);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (8,1);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (8,4);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (9,3);
INSERT INTO  StudentExercise (StudentId, ExerciseId) VALUES (9,5);

SELECT *
FROM StudentExercise;