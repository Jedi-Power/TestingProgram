CREATE TABLE tab_Authorizations
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    login VARCHAR(30) NOT NULL,
    password VARCHAR(30) NOT NULL,
    roleId INT NOT NULL
);

CREATE TABLE tab_Questions
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ask_question VARCHAR(512) NOT NULL,
    question_number INT NOT NULL
);

CREATE TABLE tab_Subjects
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    allotted_time TIME NOT NULL
);

CREATE TABLE tab_Ansvers
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ansver_option VARCHAR(200) NOT NULL,
    scores INT NOT NULL
);

CREATE TABLE tab_Roles
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(20) NOT NULL
);

CREATE TABLE tab_Groups
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30) NOT NULL
);

CREATE TABLE tab_Users
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    firstName VARCHAR(30) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    middleName VARCHAR(50),
    groupId INT REFERENCES tab_Groups(Id),
    authorizationId INT REFERENCES tab_Authorizations (Id)
);

CREATE TABLE tab_Tests
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    questionId INT REFERENCES tab_Questions (Id),
    ansverId INT REFERENCES tab_Ansvers (Id),
    subjectId INT REFERENCES tab_Subjects (Id)
);

CREATE TABLE tab_Results
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    testing_date DATE NOT NULL,
    evaluation INT NOT NULL,
    attempt INT NOT NULL,
    incorrect_answers INT NOT NULL,
    testId INT REFERENCES tab_Tests(Id),
    userId INT REFERENCES tab_Users(Id)
);