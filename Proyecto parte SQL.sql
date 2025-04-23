create database serviciotecnico

use serviciotecnico
go
Create table Usuarios(
UsuarioID int identity primary key,
Nombre varchar(50) not null,
Correo varchar(50) null,
Telefono varchar(12) null
)

create table Tecnicos(
TecnicoID int identity primary key,
Nombre varchar(50) not null,
Especialidad varchar(50) null,
)

create table Equipos(
EquipoID int identity primary key,
TipoEquipo varchar(50) not null,
Modelo varchar(50) null,
UsuarioID int foreign key references usuarios(UsuarioID)
)

create table Reparaciones(
ReparacionID int identity primary key,
Estado varchar(12) not null,
Fecha datetime,
EquipoID int foreign key References Equipos(EquipoID)
)

Create table asignaciones
(
AsignacionID int identity primary key,
ReparacionID int foreign key references Reparaciones(ReparacionID),
TecnicoID int foreign key References Tecnicos(TecnicoID),
Fecha datetime
)
Create table DetalleReparacion
(
DetalleID int identity primary key ,
ReparacionID int foreign key references Reparaciones(ReparacionID),
Descripcion varchar (100),
Fechainicio datetime,
FechaFin datetime

)
