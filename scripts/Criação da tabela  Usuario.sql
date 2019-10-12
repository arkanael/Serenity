CREATE TABLE Usuario(
IdUsuario		integer			identity(1,1),
Nome			varchar(50)			not null,
[Login]			varchar(25)			not null unique,
Senha			varchar(50)			not null,
DataCriacao		datetime			not null,
Primary Key(IdUsuario))