-- USE master
-- DROP DATABASE VetSite
CREATE DATABASE VetSite
GO
USE VetSite
GO

-- Crear la tabla TipoIdentificacion
CREATE TABLE TipoIdentificacion (
    TipoIdentificacionID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(32) NOT NULL,
    FechaCreacion DATETIME NOT NULL, 
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Rol
CREATE TABLE Rol (
    RolID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(16) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    UsuarioID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TipoIdentificacionID UNIQUEIDENTIFIER NOT NULL,
    RolID UNIQUEIDENTIFIER NOT NULL,
    NumeroIdentificacion VARCHAR(16) NOT NULL,
    Nombre VARCHAR(128) NOT NULL,
    Apellido VARCHAR(128),
    Telefono VARCHAR(16),
    CorreoElectronico VARCHAR(128),
    TarjetaProfesional VARCHAR(64),
    Clave VARBINARY(32) NOT NULL,
	Salt VARBINARY(32) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Propietario
CREATE TABLE Propietario (
    PropietarioID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TipoIdentificacionID UNIQUEIDENTIFIER NOT NULL,
    NumeroIdentificacion VARCHAR(16) NOT NULL,
    Nombre VARCHAR(128) NOT NULL,
    Apellido VARCHAR(128) NOT NULL,
    Telefono VARCHAR(16),
    CorreoElectronico VARCHAR(128),
    Direccion VARCHAR(128),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Paciente
CREATE TABLE Paciente (
    PacienteID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PropietarioID UNIQUEIDENTIFIER,
    Nombre VARCHAR(128) NOT NULL,
    Sexo CHAR(1) NOT NULL,
    Especie VARCHAR(64) NOT NULL,
    Peso DECIMAL(4,2) NOT NULL,
    Raza VARCHAR(64) NOT NULL,
    Color VARCHAR(64) NOT NULL,
    Edad INT NOT NULL,
    Esterilizado BIT NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Cita
CREATE TABLE Cita (
    CitaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    Fecha DATETIME NOT NULL,
    Motivo VARCHAR(256) ,
    Estado VARCHAR(16) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Consulta
CREATE TABLE Consulta (
    ConsultaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    CitaID UNIQUEIDENTIFIER NOT NULL,
    Fecha DATETIME NOT NULL,
    Motivo VARCHAR(256),
    Sintomas VARCHAR(256) NOT NULL,
    Diagnostico VARCHAR(256) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla TipoVacuna
CREATE TABLE TipoVacuna (
    TipoVacunaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(256) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Vacuna
CREATE TABLE Vacuna (
    VacunaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    TipoVacunaID UNIQUEIDENTIFIER NOT NULL,
    Laboratorio VARCHAR(32),
    Lote VARCHAR(64),
    FechaAplicacion DATETIME NOT NULL,
    FechaProximaAplicacion DATE NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Desparasitacion
CREATE TABLE Desparasitacion (
    DesparasitacionID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    Descripcion VARCHAR(256),
    TipoDesparasitacion VARCHAR(256),
    FechaAplicacion DATETIME NOT NULL,
    FechaProximaAplicacion DATE NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla TipoCirugia
CREATE TABLE TipoCirugia (
    TipoCirugiaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(256) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Cirugia
CREATE TABLE Cirugia (
    CirugiaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TipoCirugiaID UNIQUEIDENTIFIER NOT NULL,
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    Descripcion VARCHAR(256),
    Preanestesico VARCHAR(56),
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO


-- Crear la tabla FormulaMedica
CREATE TABLE FormulaMedica (
    FormulaMedicaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    Fecha DATETIME NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Medicamento
CREATE TABLE Medicamento (
    MedicamentoID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FormulaMedicaID UNIQUEIDENTIFIER NOT NULL,
    NombreMedicamento VARCHAR(256) NOT NULL,
    Dosis VARCHAR(128) NOT NULL,
    Frecuencia VARCHAR(128) NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO


-- Crear la tabla TipoExamen
CREATE TABLE TipoExamen (
    TipoExamenID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(64) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla ExamenLaboratorio
CREATE TABLE ExamenLaboratorio (
    ExamenID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    TipoExamenID UNIQUEIDENTIFIER NOT NULL,
    Fecha DATE NOT NULL,
    Descripcion VARCHAR(256) NOT NULL,
    Resultado VARCHAR(256) NOT NULL,
    Observaciones VARCHAR(512),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER  NOT NULL
);
GO

-- Crear la tabla TipoImagenDiagnostica
CREATE TABLE TipoImagenDiagnostica (
    TipoImagenDiagnosticaID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(64) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla ImagenDiagnostico
CREATE TABLE ImagenDiagnostico (
    ImagenDiagnosticoID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteID UNIQUEIDENTIFIER NOT NULL,
    UsuarioID UNIQUEIDENTIFIER NOT NULL,
    TipoImagenDiagnosticaID UNIQUEIDENTIFIER NOT NULL,
    Fecha DATE NOT NULL,
    SignosClinicos VARCHAR(128),
    DiagnosticoPresuntivo VARCHAR(512),
    Imagen VARBINARY(MAX) NOT NULL,
    Observaciones VARCHAR(512),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionID UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionID UNIQUEIDENTIFIER NOT NULL
);
GO

--------------------------------------------------------------
-- Agregar llaves foráneas
--------------------------------------------------------------

ALTER TABLE Usuario
ADD CONSTRAINT FK_Usuario_TipoIdentificacionID FOREIGN KEY (TipoIdentificacionID) REFERENCES TipoIdentificacion(TipoIdentificacionID),
    CONSTRAINT FK_Usuario_RolID FOREIGN KEY (RolID) REFERENCES Rol(RolID);

ALTER TABLE Propietario
ADD CONSTRAINT FK_Propietario_TipoIdentificacionID FOREIGN KEY (TipoIdentificacionID) REFERENCES TipoIdentificacion(TipoIdentificacionID);

ALTER TABLE Paciente
ADD CONSTRAINT FK_Paciente_PropietarioID FOREIGN KEY (PropietarioID) REFERENCES Propietario(PropietarioID);

ALTER TABLE Cita
ADD CONSTRAINT FK_Cita_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_Cita_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID);

ALTER TABLE Consulta
ADD CONSTRAINT FK_Consulta_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_Consulta_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_Consulta_CitaID FOREIGN KEY (CitaID) REFERENCES Cita(CitaID);

ALTER TABLE Vacuna
ADD CONSTRAINT FK_Vacuna_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_Vacuna_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_Vacuna_TipoVacunaID FOREIGN KEY (TipoVacunaID) REFERENCES TipoVacuna(TipoVacunaID);

ALTER TABLE Desparasitacion
ADD CONSTRAINT FK_Desparasitacion_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_Desparasitacion_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID);

ALTER TABLE Cirugia
ADD CONSTRAINT FK_Cirugia_TipoCirugiaID FOREIGN KEY (TipoCirugiaID) REFERENCES TipoCirugia(TipoCirugiaID),
    CONSTRAINT FK_Cirugia_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_Cirugia_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID);

ALTER TABLE FormulaMedica
ADD CONSTRAINT FK_FormulaMedica_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_FormulaMedica_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_FormulaMedica_UsuarioCreacionID FOREIGN KEY (UsuarioCreacionID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_FormulaMedica_UsuarioModificacionID FOREIGN KEY (UsuarioModificacionID) REFERENCES Usuario(UsuarioID);
GO

ALTER TABLE Medicamento
ADD CONSTRAINT FK_Medicamento_FormulaMedicaID FOREIGN KEY (FormulaMedicaID) REFERENCES FormulaMedica(FormulaMedicaID),
    CONSTRAINT FK_Medicamento_UsuarioCreacionID FOREIGN KEY (UsuarioCreacionID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_Medicamento_UsuarioModificacionID FOREIGN KEY (UsuarioModificacionID) REFERENCES Usuario(UsuarioID);
GO

ALTER TABLE ExamenLaboratorio
ADD CONSTRAINT FK_ExamenLaboratorio_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_ExamenLaboratorio_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_ExamenLaboratorio_TipoExamenID FOREIGN KEY (TipoExamenID) REFERENCES TipoExamen(TipoExamenID);

ALTER TABLE ImagenDiagnostico
ADD CONSTRAINT FK_ImagenDiagnostico_PacienteID FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_ImagenDiagnostico_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_ImagenDiagnostico_TipoImagenDiagnosticaID FOREIGN KEY (TipoImagenDiagnosticaID) REFERENCES TipoImagenDiagnostica(TipoImagenDiagnosticaID);
GO

-- *****************************
-- Procedimientos de Almacenado
-- *****************************
CREATE PROCEDURE uspUsuarioClaveValida
    @UsuarioID UNIQUEIDENTIFIER,
    @Clave VARCHAR(32) -- Se ajusta la longitud de la clave según la longitud máxima esperada
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Salt VARCHAR(32); -- Cambiar a VARCHAR
    DECLARE @HashClaveBD VARCHAR(32); -- Cambiar a VARCHAR
    DECLARE @HashClaveUsuario VARBINARY(32); 
    DECLARE @ClaveConSalt VARBINARY(MAX);

    -- Obtener el hash y el salt almacenados en la base de datos
    SELECT @HashClaveBD = Clave, @Salt = Salt
    FROM Usuario
    WHERE UsuarioID = @UsuarioID;

    -- Asegurarse de que el Salt no sea NULL antes de concatenar
    IF @Salt IS NOT NULL
    BEGIN
        -- Concatenar el salt con la clave proporcionada
        SET @ClaveConSalt = CONVERT(VARBINARY(MAX), @Salt) + CONVERT(VARBINARY(MAX), @Clave); 

        -- Calcular el hash de la clave concatenada con el salt
        SET @HashClaveUsuario = HASHBYTES('SHA2_256', @ClaveConSalt);

        -- Comparar los hashes
        IF @HashClaveBD = CONVERT(VARCHAR(32), @HashClaveUsuario) -- Comparar como VARCHAR
            RETURN 1; -- Contraseña válida
        ELSE
            RETURN 0; -- Contraseña inválida
    END
    ELSE
    BEGIN
        -- Si el salt es NULL, la clave no puede ser válida
        RETURN 0; -- Contraseña inválida
    END
END;
GO

CREATE PROCEDURE uspUsuarioInsertar
    @TipoIdentificacionID UNIQUEIDENTIFIER,
    @RolID UNIQUEIDENTIFIER,
    @NumeroIdentificacion VARCHAR(16),
    @Nombre VARCHAR(128),
    @Apellido VARCHAR(128),
    @Telefono VARCHAR(16),
    @CorreoElectronico VARCHAR(128),
    @TarjetaProfesional VARCHAR(64),
    @Clave VARCHAR(32), 
	@FechaCreacion DATETIME,
	@FechaModificacion DATETIME,
    @UsuarioCreacionID UNIQUEIDENTIFIER,
    @UsuarioModificacionID UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

  
    DECLARE @Salt VARBINARY(32);
    DECLARE @ClaveConSalt VARBINARY(MAX);
    DECLARE @HashClave VARBINARY(32);     

   SET @Salt = CAST(CRYPT_GEN_RANDOM(32) AS VARBINARY(32));

    -- Concatenar el salt con la clave
    SET @ClaveConSalt = @Salt + CAST(@Clave AS VARBINARY(MAX));

    -- Calcular el hash de la clave concatenada con el salt
    SET @HashClave = HASHBYTES('SHA2_256', @ClaveConSalt);

    -- Insertar el nuevo usuario en la tabla
    INSERT INTO Usuario (
        UsuarioID,
        TipoIdentificacionID,
        RolID,
        NumeroIdentificacion,
        Nombre,
        Apellido,
        Telefono,
        CorreoElectronico,
        TarjetaProfesional,
        Clave, 
        Salt,
        FechaCreacion,
        FechaModificacion,
        UsuarioCreacionID,
        UsuarioModificacionID
    )
    VALUES (
        NEWID(),
        @TipoIdentificacionID,
        @RolID,
        @NumeroIdentificacion,
        @Nombre,
        @Apellido,
        @Telefono,
        @CorreoElectronico,
        @TarjetaProfesional,
        @HashClave, 
        @Salt,
        @FechaCreacion,
        @FechaModificacion,
        @UsuarioCreacionID,
        @UsuarioModificacionID
    );
END;
GO





-- Insertar TipoIdentificacion
DECLARE @NewUsuarioID UNIQUEIDENTIFIER;
SET @NewUsuarioID = NEWID();

INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Cedula de ciudadania', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Tarjeta de identidad' , GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Cedula de extranjeria', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Pasaporte', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Registro civil', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('NIT', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Otro', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

DECLARE @RolID  UNIQUEIDENTIFIER;
SET	@RolID = NEWID();
INSERT INTO Rol(RolID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES (@RolID, 'Administrador', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID)
--------------------------------------------------------------

-- Insertar un usuario por defecto
DECLARE @Salt VARBINARY(32);
DECLARE @HashClave VARBINARY(32);
DECLARE @Clave VARCHAR(32) = 'admin123'; -- La clave que deseas establecer

-- Generar un nuevo salt
SET @Salt = CAST(CRYPT_GEN_RANDOM(32) AS VARBINARY(32));

-- Concatenar el salt con la clave
DECLARE @ClaveConSalt VARBINARY(MAX); 
SET @ClaveConSalt = @Salt + CAST(@Clave AS VARBINARY(MAX));

-- Calcular el hash de la clave concatenada con el salt
SET @HashClave = HASHBYTES('SHA2_256', @ClaveConSalt);

INSERT INTO Usuario (
    UsuarioID,
    TipoIdentificacionID,
    RolID,
    NumeroIdentificacion,
    Nombre,
    Apellido,
    Telefono,
    CorreoElectronico,
    TarjetaProfesional,
    Clave,
    Salt,
    FechaCreacion,
    FechaModificacion,
    UsuarioCreacionID,
    UsuarioModificacionID
)
VALUES (
    @NewUsuarioID,
    (SELECT TipoIdentificacionID FROM TipoIdentificacion WHERE Descripcion = 'Otro'), 
    @RolID, 
    '123456789', 
    'Admin', 
    'Admin', 
    '0000000000', 
    'admin@example.com', 
    NULL, 
    @HashClave, 
    @Salt,
    GETDATE(), 
    GETDATE(), 
    @NewUsuarioID, 
    @NewUsuarioID
);
GO