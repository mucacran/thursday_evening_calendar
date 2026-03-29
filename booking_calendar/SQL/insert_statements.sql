/*here is a basic SQL to insert information to the database.*/

/*you are welcome to execute it to add some basic information to the database or to modify it.*/

USE cse325project;

INSERT INTO courses (id,name,courseid,description)values
(1,".NET Software Development", "CSE 325", "test description");

INSERT INTO users values
(1,'root','admin',1);

INSERT INTO users (username,password,privilege)values
("omar", "admin",2);

insert into meetings values
(1,1,"test meeting",'2026-03-31',"NO DESCRIPTION" );

insert into Users_has_Meetings values
(1,1),(2,1);

select * from Users_has_Meetings;