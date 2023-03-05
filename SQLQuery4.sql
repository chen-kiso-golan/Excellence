CREATE DATABASE Market

--create the tabels in the db:
CREATE PROCEDURE DBinit
AS
BEGIN
select 'Start Init'
create table Departments ([id] int not null identity, [name] nvarchar(100) not null, [description] nvarchar(1000) null)
create table Items ([id] int not null identity, [name] nvarchar(100) not null, [price] money not null, [unitsInStock] int not null, [departmentId] int not null)
select 'End Init'
End
--EXEC DBinit


--insert new department
CREATE PROCEDURE NewDepartment
@name nvarchar(100),
@description nvarchar(1000)
AS
BEGIN 
SET NOCOUNT ON;
insert into Departments ([name], [description]) values (@name, @description)
select @@IDENTITY
END


--insert new item
CREATE PROCEDURE NewItem
@name nvarchar(100),
@price money,
@unitsInStock int,
@departmentId int
AS
BEGIN 
SET NOCOUNT ON;
insert into Items ([name], [price], [unitsInStock], [departmentId]) values (@name, @price, @unitsInStock, @departmentId )
select @@IDENTITY
END


