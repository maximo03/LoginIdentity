CREATE DATABASE InformesDB
USE InformesDB
go

/**************************TABLE USER AND PROCEDURE******************************/
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(256),
Email NVARCHAR(256),
EmailNormalized NVARCHAR(256),
PasswordHash NVARCHAR(MAX)
)
go

CREATE PROCEDURE SP_InsertUser
@Name NVARCHAR(256),
@Email NVARCHAR(256),
@EmailNormalized NVARCHAR(256),
@PasswordHash NVARCHAR(MAX)
as
 begin
   INSERT INTO Users(Name,Email,EmailNormalized,PasswordHash)
		VALUES(@Name,@Email,@EmailNormalized,@PasswordHash);
	SELECT SCOPE_IDENTITY();
end
go