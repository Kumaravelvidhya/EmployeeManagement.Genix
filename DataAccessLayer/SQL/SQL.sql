
create table Employee
(
Id int primary key identity(1,1),
Name nvarchar (100) not null,
DateOfBirth datetime2 not null,
Experience decimal(3,1)not null,
Phonenumber bigint not null,
EmailAddress nvarchar (50) not null,
)
select*from Employee

create or alter procedure Getallemployees
as
begin
select*from Employee order by Name asc 
end
exec Getallemployees

create or alter procedure Getemployeesid(@Id int)
as
begin
select*from Employee where id=@id
end
exec Getemployeesid 1

create or alter procedure CreateEmployeeDetails(@Name nvarchar(100),@DateOfBirth datetime2,@Experience decimal(3,1),@Phonenumber bigint,@EmailAddress nvarchar (50))
as 
begin
insert into Employee (Name,DateOfBirth,Experience,Phonenumber,EmailAddress)values(@Name,@DateOfBirth,@Experience,@Phonenumber,@EmailAddress)
end
exec CreateEmployeeDetails 'Vidha','05-09-2000',1.5,'9361885628','vidhya@gamil.com'

create or alter procedure UpdateEmployeeDetails(@id int,@Name nvarchar(100),@DateOfBirth datetime2,@Experience decimal(3,1),@Phonenumber bigint,@EmailAddress nvarchar (50))
as
begin
Update Employee set Name=@Name,DateOfBirth=@DateOfBirth,Experience=@Experience,Phonenumber=@Phonenumber,EmailAddress=@EmailAddress where (Id=@Id)
end
exec UpdateEmployeeDetails 1,'Vidhya','05-09-2000',1.5,'9361885628','vidhya@gamil.com'


create or alter procedure DeleteEmployeeDetails(@Id int)
as
begin
delete Employee where (Id=@Id)
end
exec DeleteEmployeeDetails 1
