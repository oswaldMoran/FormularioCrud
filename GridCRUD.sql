
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Departamento NVARCHAR(50) NOT NULL,
    Puesto NVARCHAR(100) NOT NULL,
    Salario Decimal(15) NULL
);


INSERT INTO Empleados (Nombre, Departamento, Puesto, Salario)
VALUES ('Brandon Perez', 'Logistica', 'Chofer', 16000);

INSERT INTO Empleados (Nombre, Departamento, Puesto, Salario)
VALUES ('Alicia Lara', 'Administracion', 'Facturista', 14000);

select * from Empleados



--  insertar empleado
CREATE PROCEDURE SP_InsertarEmpleado
    @Nombre NVARCHAR(50),
    @Departamento NVARCHAR(50),
    @Puesto NVARCHAR(100),
    @Salario NVARCHAR(15)
AS
BEGIN
    INSERT INTO Empleados (Nombre, Departamento, Puesto, Salario)
    VALUES (@Nombre, @Departamento, @Puesto, @Salario);
END;

EXEC SP_InsertarEmpleado @Nombre = 'Juan', @Departamento = 'Sistemas', @Puesto = 'Programador', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Cristina Perez', @Departamento = 'Sistemas', @Puesto = 'Soporte Tecnico', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Carlos Lopez', @Departamento = 'Ventas', @Puesto = 'Promotor', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Joana Ramirez', @Departamento = 'Ventas', @Puesto = 'Cobranza', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Pedro Picapiedra', @Departamento = 'Marketing', @Puesto = 'Diseñador', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Alex Lora', @Departamento = 'Marketing', @Puesto = 'Diseñador', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Oscar Hernandez', @Departamento = 'Almacen', @Puesto = 'Corte', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Karen Sarmiento', @Departamento = 'Almacen', @Puesto = 'Recibo', @Salario = 20000;
EXEC SP_InsertarEmpleado @Nombre = 'Karla Salas', @Departamento = 'Almacen', @Puesto = 'Recibo', @Salario = 13000;


-----------------------------------------------------------------------------------

--  listar empleados
CREATE PROCEDURE SP_ListarEmpleados
AS
BEGIN
    SELECT Id, Nombre, Departamento, Puesto, Salario FROM Empleados;
END;

EXEC SP_ListarEmpleados;

------------------------------------------------------------------------------------

--  actualizar empleado
CREATE PROCEDURE SP_ActualizarEmpleado
    @Id INT,
    @Nombre NVARCHAR(50),
    @Departamento NVARCHAR(50),
    @Puesto NVARCHAR(100),
    @Salario NVARCHAR(15)
AS
BEGIN
    UPDATE Empleados
    SET Nombre = @Nombre, Departamento = @Departamento, Puesto = @Puesto, Salario = @Salario
    WHERE Id = @Id;
END;

EXEC SP_ActualizarEmpleado @Id = 1, @Nombre = 'Juan Pablo II', @Departamento = 'Sistemas', @Puesto = 'Programador', @Salario = 18000;
EXEC SP_ActualizarEmpleado @Id = 2, @Nombre = 'Cristina Perez', @Departamento = 'Sistemas', @Puesto = 'Soporte Tecnico',@Salario = 14000;
EXEC SP_ActualizarEmpleado @Id = 3, @Nombre = 'Carlos Lopez', @Departamento = 'Ventas', @Puesto = 'Promotor',@Salario = 15000;
EXEC SP_ActualizarEmpleado @Id = 6, @Nombre = 'Alex Lora', @Departamento = 'Marketing', @Puesto = 'Diseñador', @Salario = 17000;
EXEC SP_ActualizarEmpleado @Id = 7, @Nombre = 'Oscar Hernandez', @Departamento = 'Almacen', @Puesto = 'Corte', @Salario = 12000;
EXEC SP_ActualizarEmpleado @Id = 8, @Nombre = 'Karen Sarmiento', @Departamento = 'Almacen', @Puesto = 'Recibo', @Salario = 11000;

----------------------------------------------------------------------------------------

-- eliminar empleado
CREATE PROCEDURE SP_EliminarEmpleado
    @Id INT
AS
BEGIN
    DELETE FROM Empleados
    WHERE Id = @Id;
END;

EXEC SP_EliminarEmpleado @Id = 9;