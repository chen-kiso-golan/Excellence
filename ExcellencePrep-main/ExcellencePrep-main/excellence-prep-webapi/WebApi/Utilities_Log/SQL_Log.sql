----יצירת טבלת לוג
create table LogTable(Code int primary key identity, 
LogType nvarchar(max), LogTime datetime, messege nvarchar(max), ExceptionMsg nvarchar(MAX))

if not exists(select * from [dbo].[LogTable])
begin
create table LogTable(Code int primary key identity, 
LogType nvarchar(max), LogTime datetime, messege nvarchar(max), ExceptionMsg nvarchar(MAX))
end


drop table LogTable


select * from LogTable


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LogTable' AND schema_name(schema_id) = 'dbo') 
BEGIN
    CREATE TABLE dbo.LogTable(Code int primary key identity, 
    LogType nvarchar(max), LogTime datetime, messege nvarchar(max), ExceptionMsg nvarchar(MAX))
END