Create database Plantas

Create table Categorias (
IdCategoria INT PRIMARY KEY IDENTITY (1,1),
Nombre NVARCHAR (50)
);

CREATE TABLE Plantas (
 IdPlanta INT PRIMARY KEY IDENTITY(1,1),
 Nombre NVARCHAR(100),
 Descripcion NVARCHAR(200),
 Precio DECIMAL(10,2),
 Imagen NVARCHAR(200),
 IdCategoria INT,
 FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);