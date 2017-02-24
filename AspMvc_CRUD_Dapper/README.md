

[CRUD Operations In ASP.NET MVC 5 Using Dapper](http://www.compilemode.com/2015/09/crud-operations-in-asp-net-mvc-5-using-dapper.html)


create store
```
-- Insert Data
Create procedure [dbo].[AddNewEmpDetails]
(
@Name varchar (50),
@City varchar (50),
@Address varchar (50)
)
as
begin
Insert into Employee values(@Name,@City,@Address)
End 
-- View Data
Create procedure [dbo].[GetEmployee]
as
begin
select Id as EmpId,Name,City,Address from Employee
End;
-- Update Data
create procedure [dbo].[UpdateEmpDetails]
(
@EmpId int,
@Name varchar(50),
@City varchar(50),
@Address varchar(50)
)
as 
begin
Update Employee
set Name = @Name, City = @City, Address = @Address where Id = @EmpId
End;
-- Delete Data
create procedure [dbo].[DeleteEmpById]
(
@EmpId int 
)
as 
begin
Delete from Employee where Id = @EmpId
end;
```