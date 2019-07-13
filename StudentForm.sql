create database StudentDB;
use StudentDB

create table Students
( ID int IDENTITY(1,1) PRIMARY KEY,
  RollNo varchar (100),
  Name varchar (100),
  Address varchar (100)
)
select * from Students

---drop table students
update Students set Name='asd' where ID=4

delete Students where id=4