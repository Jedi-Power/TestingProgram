USE Testingdb

CREATE TABLE tab_Roles
(
  id INT PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(20) NOT NULL 
);

CREATE TABLE tab_Authorizations
(
  id INT PRIMARY KEY IDENTITY(1,1),
  [login] NVARCHAR(30) NOT NULL,
  [password] NVARCHAR(30) NOT NULL,
  roleId INT REFERENCES tab_Roles(id)
);

CREATE TABLE tab_Questions
(
  id INT PRIMARY KEY IDENTITY(1,1),
  ask_question NVARCHAR(512) NOT NULL,
  picture VARBINARY,
  question_number INT NOT NULL
);

CREATE TABLE tab_Subjects
(
  id INT PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(200) NOT NULL,
  allotted_time INT NOT NULL
);

CREATE TABLE tab_Ansvers
(
  id INT PRIMARY KEY IDENTITY(1,1),
  answer_option NVARCHAR(200) NOT NULL,
  scores INT NOT NULL
);

CREATE TABLE tab_Groups
(
 id INT PRIMARY KEY IDENTITY(1,1),
 [name] NVARCHAR(30) NOT NULL
);

CREATE TABLE tab_Users
(
  id INT PRIMARY KEY IDENTITY(1,1),
  firstName NVARCHAR(30) NOT NULL,
  lastName NVARCHAR(50) NOT NULL,
  middleName NVARCHAR(50),
  groupId INT REFERENCES tab_Groups(id),
  authorizationId INT REFERENCES tab_Authorizations (id),
  
);

CREATE TABLE tab_Tests
(
 id INT PRIMARY KEY IDENTITY(1,1),
 questionId INT REFERENCES tab_Questions (id),
 ansverId INT REFERENCES tab_Ansvers (id),
 subjectId INT REFERENCES tab_Subjects (id)
 
);

CREATE TABLE tab_Results
(
  id INT PRIMARY KEY IDENTITY(1,1),
  testing_date DATETIME NOT NULL,
  evaluation INT NOT NULL,
  attempt INT NOT NULL,
  incorrect_answers NVARCHAR(100),
  testId INT REFERENCES tab_Tests(id),
  userId INT REFERENCES tab_Users(Id)
);
