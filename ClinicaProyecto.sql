CREATE DATABASE Clinica
GO

USE Clinica
GO

CREATE TABLE Rol(
IdRol  INT IDENTITY,
Nombre VARCHAR(100),
PRIMARY KEY(IdRol))
GO


CREATE TABLE Usuario (
IdUsuario INT IDENTITY,
Nombre VARCHAR(100),
Apellido VARCHAR(100),
Correo VARCHAR(100),
Edad INT,
Direccion VARCHAR(5000),
Clave VARCHAR(150),
StatusUsuario BIT,
FechaRegistro DATETIME DEFAULT GETDATE(),
IdRol INT REFERENCES Rol(IdRol),
PRIMARY KEY(IdUsuario))
GO


/*  TABLA PARA GUARDAR PRECIOS PREDEFINIDOS PARA UNA ESPECIALIDAD*/
CREATE TABLE Precio (
  IdPrecio INT IDENTITY,
  Valor INT,
  PRIMARY KEY (IdPrecio)
)
GO


/*  TABLA PARA GUARDAR LAS AREAS QUE SE PUEDEN ATENDER EN LA CLINICA*/
CREATE TABLE Especialidad (
  IdEspecialidad INT IDENTITY,
  Nombre VARCHAR(50),
  IdPrecio INT REFERENCES Precio(IdPrecio),
  StatusEspecialidad BIT,
  PRIMARY KEY (IdEspecialidad)
)
GO


CREATE TABLE Clinica(
IdClinica INT IDENTITY,
Nombre VARCHAR(200),
Direccion VARCHAR(1000),
Telefono VARCHAR(20),
Correo VARCHAR(50),
PRIMARY KEY(IdClinica))
GO

/*  TABLA PARA GUARDAR LOS DOCTORES Y PODER USARLOS EN LA CREACION DE CITAS (NO ES EL USUARIO)*/
CREATE TABLE Doctor(
IdDoctor INT IDENTITY,
Nombre VARCHAR(50),
Apellido VARCHAR(50),
StatusDoctor BIT,
PRIMARY KEY(IdDoctor))
GO


/*  TABLA PARA GUARDAR LOS HORARIOS DISPONIBLES)*/
CREATE TABLE Horario(
IdHorario INT IDENTITY,
Dia VARCHAR(25),
Hora VARCHAR(25),
StatusHorario BIT,
PRIMARY KEY(IdHorario))
GO


/*  TABLA QUE ALMACENA LAS OPCIONES DE CITAS QUE LOS USUARIOS PUEDEN ESCOGER PARA RESERVAR */
CREATE TABLE Cita(
IdCita INT IDENTITY,
IdDoctor INT REFERENCES Doctor(IdDoctor),
IdEspecialidad INT REFERENCES Especialidad(IdEspecialidad),
IdClinica INT REFERENCES Clinica(IdClinica),
IdHorario INT REFERENCES Horario(IdHorario),
StatusCita BIT,
PRIMARY KEY(IdCita))
GO


/*  TABLA PARA GUARDAR SI UNA CITA ES PENDIENTE-EN PROCESO-FINALIZADA*/
CREATE TABLE StatusReserva(
IdStatusReserva INT IDENTITY,
Nombre VARCHAR(20),
PRIMARY KEY(IdStatusReserva))
GO


CREATE TABLE Reserva(
IdReserva INT IDENTITY,
IdCita INT REFERENCES Cita(IdCita),
IdUsuario INT REFERENCES Usuario(IdUsuario),
IdStatusReserva INT REFERENCES StatusReserva(IdStatusReserva),
Precio INT,
FechaRegistro DATETIME DEFAULT GETDATE(),
PRIMARY KEY(IdReserva))
GO



CREATE TABLE Facturas(
IdFactura INT IDENTITY,
Total INT,
IdReserva INT REFERENCES Reserva(IdReserva),
FechaRegistro DATETIME DEFAULT GETDATE(),
PRIMARY KEY(IdFactura))
GO


CREATE TABLE Diagnostico (
IdDiagnostico INT IDENTITY,
Descripcion VARCHAR(MAX),
IdReserva INT REFERENCES Reserva(IdReserva),
PRIMARY KEY(IdDiagnostico))
GO

-- Inserción de datos en la tabla 'Rol'
INSERT INTO Rol (Nombre) VALUES ('Administrador');
INSERT INTO Rol (Nombre) VALUES ('Médico');
INSERT INTO Rol (Nombre) VALUES ('Recepcionista');
INSERT INTO Rol (Nombre) VALUES ('Paciente');

-- Inserción de datos en la tabla 'Usuario'
-- Inserción de datos en la tabla 'Usuario' para varios usuarios
INSERT INTO Usuario (Nombre, Apellido, Correo, Edad, Direccion, Clave, StatusUsuario, IdRol)
VALUES ('John', 'Doe', 'john.doe@example.com', 35, '123 Main St', 'password123', 1, 1);

INSERT INTO Usuario (Nombre, Apellido, Correo, Edad, Direccion, Clave, StatusUsuario, IdRol)
VALUES ('Maria', 'Gómez', 'maria.gomez@example.com', 28, '456 Elm St', 'password456', 1, 2);

INSERT INTO Usuario (Nombre, Apellido, Correo, Edad, Direccion, Clave, StatusUsuario, IdRol)
VALUES ('Carlos', 'Martínez', 'carlos.martinez@example.com', 42, '789 Oak St', 'password789', 1, 3);

-- Inserción de datos en la tabla 'Precio'
INSERT INTO Precio (Valor) VALUES (100);
INSERT INTO Precio (Valor) VALUES (150);
INSERT INTO Precio (Valor) VALUES (200);

-- Inserción de datos en la tabla 'Especialidad'
INSERT INTO Especialidad (Nombre, IdPrecio, StatusEspecialidad)
VALUES ('Cardiología', 1, 1);
INSERT INTO Especialidad (Nombre, IdPrecio, StatusEspecialidad)
VALUES ('Dermatología', 2, 1);
INSERT INTO Especialidad (Nombre, IdPrecio, StatusEspecialidad)
VALUES ('Ginecología', 3, 1);

-- Inserción de datos en la tabla 'Clinica'
INSERT INTO Clinica (Nombre, Direccion, Telefono, Correo)
VALUES ('Clinica Principal', '456 Elm St', '123-456-7890', 'info@clinicaprincipal.com');

-- Inserción de datos en la tabla 'Doctor'
INSERT INTO Doctor (Nombre, Apellido, StatusDoctor)
VALUES ('Dr. Juan', 'Pérez', 1);
INSERT INTO Doctor (Nombre, Apellido, StatusDoctor)
VALUES ('Dra. María', 'Gómez', 1);

-- Inserción de datos en la tabla 'Horario'
INSERT INTO Horario (Dia, Hora, StatusHorario)
VALUES ('Lunes', '09:00 AM - 05:00 PM', 1);
INSERT INTO Horario (Dia, Hora, StatusHorario)
VALUES ('Martes', '10:00 AM - 06:00 PM', 1);

-- Inserción de datos en la tabla 'Cita'
INSERT INTO Cita (IdDoctor, IdEspecialidad, IdClinica, IdHorario, StatusCita)
VALUES (1, 1, 1, 1, 1);
INSERT INTO Cita (IdDoctor, IdEspecialidad, IdClinica, IdHorario, StatusCita)
VALUES (2, 2, 1, 2, 1);

-- Inserción de datos en la tabla 'StatusReserva'
INSERT INTO StatusReserva (Nombre) VALUES ('Pendiente');
INSERT INTO StatusReserva (Nombre) VALUES ('En Proceso');
INSERT INTO StatusReserva (Nombre) VALUES ('Finalizada');

-- Inserción de datos en la tabla 'Reserva'
INSERT INTO Reserva (IdCita, IdUsuario, IdStatusReserva, Precio)
VALUES (1, 1, 1, 100);
INSERT INTO Reserva (IdCita, IdUsuario, IdStatusReserva, Precio)
VALUES (2, 1, 2, 150);

-- Inserción de datos en la tabla 'Facturas'
INSERT INTO Facturas (Total, IdReserva) VALUES (100, 1);
INSERT INTO Facturas (Total, IdReserva) VALUES (150, 2);

-- Inserción de datos en la tabla 'Diagnostico'
INSERT INTO Diagnostico (Descripcion, IdReserva)
VALUES ('El paciente presenta síntomas cardíacos.', 1);
INSERT INTO Diagnostico (Descripcion, IdReserva)
VALUES ('La paciente necesita tratamiento dermatológico.', 2);

-- Procedimientos almacenados
create procedure sp_CitasDisponibles
as
begin
select ct.IdCita, CONCAT(d.Nombre,' ',d.Apellido) Doctor, c.Nombre Clinica, e.Nombre Especialidad, CONCAT(h.Dia,' ',h.Hora) Horario, ct.StatusCita Estado
from Cita ct inner join Doctor d on d.IdDoctor = ct.IdDoctor
              inner join Clinica c on c.IdClinica = ct.IdClinica
			  inner join Especialidad e on e.IdEspecialidad = ct.IdEspecialidad
			  inner join Horario h on h.IdHorario = ct.IdHorario
where ct.StatusCita = 1
end
go

create procedure sp_CitasAdmin
as
begin
select ct.IdCita, CONCAT(d.Nombre,' ',d.Apellido) Doctor, c.Nombre Clinica, e.Nombre Especialidad, CONCAT(h.Dia,' ',h.Hora) Horario, ct.StatusCita Estado
from Cita ct inner join Doctor d on d.IdDoctor = ct.IdDoctor
              inner join Clinica c on c.IdClinica = ct.IdClinica
			  inner join Especialidad e on e.IdEspecialidad = ct.IdEspecialidad
			  inner join Horario h on h.IdHorario = ct.IdHorario
end
go

create procedure sp_Especialidades
as
begin
select e.IdEspecialidad, e.Nombre Area, p.Valor Precio, e.StatusEspecialidad Estado
from Especialidad e inner join Precio p on p.IdPrecio = e.IdPrecio
end
go

CREATE PROCEDURE SpObtenerInfoUsuariosConRol
AS
BEGIN
    SELECT
        U.IdUsuario,
        U.Nombre AS NombreUsuario,
        U.Apellido,
        U.Correo,
        U.Edad,
        U.Direccion,
        U.Clave,
        IIF(U.StatusUsuario = 1, 'ACTIVO', 'NO ACTIVO') AS EstadoUsuario,
        U.FechaRegistro,
        R.Nombre AS NombreRol
    FROM Usuario AS U
    INNER JOIN Rol AS R ON U.IdRol = R.IdRol;
END
GO

CREATE PROCEDURE SpObtenerInfoCitas
AS
BEGIN
    SELECT
        C.IdCita,
        D.Nombre AS NombreDoctor,
        E.Nombre AS NombreEspecialidad,
        Cl.Nombre AS NombreClinica,
        H.Dia AS DiaHorario,
        H.Hora AS HoraHorario
    FROM Cita AS C
    INNER JOIN Doctor AS D ON C.IdDoctor = D.IdDoctor
    INNER JOIN Especialidad AS E ON C.IdEspecialidad = E.IdEspecialidad
    INNER JOIN Clinica AS Cl ON C.IdClinica = Cl.IdClinica
    INNER JOIN Horario AS H ON C.IdHorario = H.IdHorario;
END
GO

CREATE PROCEDURE SpObtenerInfoEspecialidadesConEstado
AS
BEGIN
    SELECT
        E.IdEspecialidad,
        E.Nombre AS NombreEspecialidad,
        P.Valor AS PrecioEspecialidad,
        IIF(E.StatusEspecialidad = 1, 'ACTIVA', 'INACTIVA') AS EstadoEspecialidad
    FROM Especialidad AS E
    INNER JOIN Precio AS P ON E.IdPrecio = P.IdPrecio;
END
GO

CREATE PROCEDURE SpObtenerInfoCompletaReservas
AS
BEGIN
    SELECT
        R.IdReserva,
        R.IdCita,
        U.Nombre AS NombreUsuario,
        R.Precio,
        R.FechaRegistro AS FechaReserva,
        S.Nombre AS EstadoReserva
    FROM Reserva AS R
    INNER JOIN Usuario AS U ON R.IdUsuario = U.IdUsuario
    INNER JOIN StatusReserva AS S ON R.IdStatusReserva = S.IdStatusReserva;
END
GO

CREATE PROCEDURE SpObtenerInfoDiagnosticoConDoctorYUsuario
AS
BEGIN
    SELECT
        D.IdDiagnostico,
        D.Descripcion,
        Doc.Nombre AS NombreDoctor,
        Us.Nombre AS NombreUsuario
    FROM Diagnostico AS D
    INNER JOIN Reserva AS R ON D.IdReserva = R.IdReserva
    INNER JOIN Cita AS C ON R.IdCita = C.IdCita
    INNER JOIN Doctor AS Doc ON C.IdDoctor = Doc.IdDoctor
    INNER JOIN Usuario AS Us ON R.IdUsuario = Us.IdUsuario;
END
GO

CREATE PROCEDURE SpObtenerInfoFacturasConUsuario
AS
BEGIN
    SELECT
        F.IdFactura,
        F.Total,
        F.FechaRegistro AS FechaFactura,
        U.Nombre AS NombreUsuario
    FROM Facturas AS F
    INNER JOIN Reserva AS R ON F.IdReserva = R.IdReserva
    INNER JOIN Usuario AS U ON R.IdUsuario = U.IdUsuario;
END
GO