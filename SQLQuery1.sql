CREATE DATABASE Inventario;
USE Inventario;

CREATE TABLE Productos (
    ID INT PRIMARY KEY,
    nombre VARCHAR(50),
    descripcion TEXT,
    precio DECIMAL(10,2),
    cantidad INT,
    categoria VARCHAR(30)
);

CREATE TABLE Proveedores (
    ID INT PRIMARY KEY,
    nombre VARCHAR(50),
    direccion TEXT,
    telefono VARCHAR(15)
);

CREATE TABLE Pedidos (
    ID INT PRIMARY KEY,
    fecha DATE,
    cliente VARCHAR(50),
    producto_id INT,
    FOREIGN KEY (producto_id) REFERENCES Productos(ID)
);

INSERT INTO Productos (ID, nombre, descripcion, precio, cantidad, categoria) VALUES
(1, 'Gorra', 'Gorra new era', 26000.00, 20, 'Accesorios'),
(2, 'Tennis', 'Vans', 46000.00, 15, 'Ropa'),
(3, 'Pantalones', 'Cargos', 23000.00, 30, 'Ropa'),
(4, 'Mouse', 'Mouse óptico', 42000.00, 40, 'Accesorios'),
(5, 'Celular', 'iPhone 12 Pro', 269900.00, 20, 'Electrónica');

INSERT INTO Proveedores (ID, nombre, direccion, telefono) VALUES
(1, 'Proveedor A', 'Calle Caricias, Ciudad', '123456789'),
(2, 'Proveedor B', 'Avenida 456, Ciudad', '50689012341');

INSERT INTO Pedidos (ID, fecha, cliente, producto_id) VALUES
(1, '2024-01-01', 'Juan Pérez', 1),
(2, '2024-01-02', 'María Gómez', 2);

UPDATE Productos SET precio = 4800.00 WHERE ID = 1;

DELETE FROM Productos WHERE ID = 5;

SELECT * FROM Productos WHERE precio > 1000;
SELECT AVG(precio) FROM Productos;
SELECT p.nombre, s.nombre FROM Productos p 
INNER JOIN Proveedores s ON p.ID = s.ID;
