CREATE DATABASE school_db;
USE school_db;

CREATE TABLE login (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL
);
INSERT INTO login (username, password) VALUES
('admin', 'admin123'),
('teacher1', 'teachpass1'),
('student1', 'studpass1');

CREATE TABLE students (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Dob DATE NOT NULL,
    Gender ENUM('Male', 'Female', 'Other') NOT NULL,
    Phone VARCHAR(15) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE
);
INSERT INTO students (Name, Dob, Gender, Phone, Email) VALUES
('John Doe', '2005-08-15', 'Male', '1234567890', 'john.doe@example.com'),
('Jane Smith', '2006-03-22', 'Female', '9876543210', 'jane.smith@example.com'),
('Alex Taylor', '2004-11-05', 'Other', '4567891230', 'alex.taylor@example.com');

CREATE TABLE IF NOT EXISTS subject (
    id INT AUTO_INCREMENT PRIMARY KEY,
    SubjectName VARCHAR(255) NOT NULL
);
INSERT INTO subject (SubjectName) VALUES
('Mathematics'),
('Science'),
('English');

CREATE TABLE IF NOT EXISTS teacher (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    gender ENUM('Male', 'Female', 'Other') NOT NULL,
    phone VARCHAR(15) NOT NULL
);
INSERT INTO teacher (name, gender, phone) VALUES
('Mr. Alan Brown', 'Male', '1122334455'),
('Ms. Emily Clark', 'Female', '2233445566'),
('Mx. Jordan Lee', 'Other', '3344556677');

CREATE TABLE section (
    id INT AUTO_INCREMENT PRIMARY KEY,
    subject_name VARCHAR(255) NOT NULL,
    section VARCHAR(50) NOT NULL
);
INSERT INTO section (subject_name, section) VALUES 
('Mathematics', 'A'),
('Science', 'B'),
('English', 'C');

CREATE TABLE enrollment (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    section VARCHAR(50) NOT NULL,
    dob DATE NOT NULL
);
INSERT INTO enrollment (name, section, dob) VALUES
('Michael Johnson', 'A', '2005-12-25'),
('Emily Davis', 'B', '2006-08-30'),
('Daniel White', 'C', '2007-11-05');

CREATE TABLE attendance (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    status VARCHAR(50) NOT NULL
);
INSERT INTO attendance (name, status) VALUES
('John Doe', 'Present'),
('Jane Smith', 'Absent'),
('Alex Taylor', 'Late'),
('Michael Johnson', 'Present'),
('Emily Davis', 'Absent'),
('Daniel White', 'Present');