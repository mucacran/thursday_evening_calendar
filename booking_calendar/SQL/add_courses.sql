-- Script to add common courses to the database
-- Run this to populate the courses table

USE CSE325Project;

-- Add common BYU-I courses
INSERT INTO courses (id, name, courseid, description) VALUES
(1, 'Object-Oriented Programming', 'CSE 210', 'Learn OOP concepts with Python and C#'),
(2, 'Network and Internet Systems', 'CSE 270', 'Introduction to networking and web technologies'),
(3, 'Database Design and Development', 'CSE 310', 'Learn database design, SQL and normalization'),
(4, '.NET Software Development', 'CSE 325', 'Build web applications with ASP.NET Core'),
(5, 'Data Structures', 'CSE 212', 'Learn advanced data structures and algorithms'),
(6, 'Mobile Application Development', 'CSE 450', 'Build mobile apps with React Native or Flutter'),
(7, 'Software Engineering', 'CSE 456', 'Software development lifecycle and best practices')
ON DUPLICATE KEY UPDATE 
    name = VALUES(name),
    courseid = VALUES(courseid),
    description = VALUES(description);

-- Verify the courses were added
SELECT * FROM courses;
