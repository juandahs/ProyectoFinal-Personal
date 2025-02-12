-- USE master
-- DROP DATABASE VetSite
CREATE DATABASE VetSite
GO
USE VetSite
GO

-- Crear la tabla TipoIdentificacion
CREATE TABLE TipoIdentificacion (
    TipoIdentificacionId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(32) NOT NULL,
    FechaCreacion DATETIME NOT NULL, 
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Rol
CREATE TABLE Rol (
    RolId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(16) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    UsuarioId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TipoIdentificacionId UNIQUEIDENTIFIER NOT NULL,
    RolId UNIQUEIDENTIFIER NOT NULL,
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
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Propietario
CREATE TABLE Propietario (
    PropietarioId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TipoIdentificacionId UNIQUEIDENTIFIER NOT NULL,
    NumeroIdentificacion VARCHAR(16) NOT NULL,
    Nombre VARCHAR(128) NOT NULL,
    Apellido VARCHAR(128) NOT NULL,
    Telefono VARCHAR(16),
    CorreoElectronico VARCHAR(128),
    Direccion VARCHAR(128),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Paciente
CREATE TABLE Paciente (
    PacienteId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PropietarioId UNIQUEIDENTIFIER,
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
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Cita
CREATE TABLE Cita (
    CitaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    Fecha DATETIME NOT NULL,
    Motivo VARCHAR(256) ,
    Estado VARCHAR(16) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Consulta
CREATE TABLE Consulta (
    ConsultaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    CitaID UNIQUEIDENTIFIER NOT NULL,
    Fecha DATETIME NOT NULL,
    Motivo VARCHAR(256),
    Sintomas VARCHAR(256) NOT NULL,
    Diagnostico VARCHAR(256) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionIdD UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
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
    VacunaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    TipoVacunaId UNIQUEIDENTIFIER NOT NULL,
    Laboratorio VARCHAR(32),
    Lote VARCHAR(64),
    FechaAplicacion DATETIME NOT NULL,
    FechaProximaAplicacion DATE NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Desparasitacion
CREATE TABLE Desparasitacion (
    DesparasitacionId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    Descripcion VARCHAR(256),
    TipoDesparasitacion VARCHAR(256),
    FechaAplicacion DATETIME NOT NULL,
    FechaProximaAplicacion DATE NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla TipoCirugia
CREATE TABLE TipoCirugia (
    TipoCirugiaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(256) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Cirugia
CREATE TABLE Cirugia (
    CirugiaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TipoCirugiaId UNIQUEIDENTIFIER NOT NULL,
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    Descripcion VARCHAR(256),
    Preanestesico VARCHAR(56),
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO


-- Crear la tabla FormulaMedica
CREATE TABLE FormulaMedica (
    FormulaMedicaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    Fecha DATETIME NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla Medicamento
CREATE TABLE Medicamento (
    MedicamentoId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FormulaMedicaId UNIQUEIDENTIFIER NOT NULL,
    NombreMedicamento VARCHAR(256) NOT NULL,
    Dosis VARCHAR(128) NOT NULL,
    Frecuencia VARCHAR(128) NOT NULL,
    Observaciones VARCHAR(256),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO


-- Crear la tabla TipoExamen
CREATE TABLE TipoExamen (
    TipoExamenId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(64) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla ExamenLaboratorio
CREATE TABLE ExamenLaboratorio (
    ExamenId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    TipoExamenId UNIQUEIDENTIFIER NOT NULL,
    Fecha DATE NOT NULL,
    Descripcion VARCHAR(256) NOT NULL,
    Resultado VARCHAR(256) NOT NULL,
    Observaciones VARCHAR(512),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER  NOT NULL
);
GO

-- Crear la tabla TipoImagenDiagnostica
CREATE TABLE TipoImagenDiagnostica (
    TipoImagenDiagnosticaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Descripcion VARCHAR(64) NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

-- Crear la tabla ImagenDiagnostico
CREATE TABLE ImagenDiagnostico (
    ImagenDiagnosticoId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PacienteId UNIQUEIDENTIFIER NOT NULL,
    UsuarioId UNIQUEIDENTIFIER NOT NULL,
    TipoImagenDiagnosticaId UNIQUEIDENTIFIER NOT NULL,
    Fecha DATE NOT NULL,
    SignosClinicos VARCHAR(128),
    DiagnosticoPresuntivo VARCHAR(512),
    Imagen VARBINARY(MAX) NOT NULL,
    Observaciones VARCHAR(512),
    FechaCreacion DATETIME NOT NULL,
    FechaModificacion DATETIME NOT NULL,
    UsuarioCreacionId UNIQUEIDENTIFIER NOT NULL,
    UsuarioModificacionId UNIQUEIDENTIFIER NOT NULL
);
GO

--------------------------------------------------------------
-- Agregar llaves foráneas
--------------------------------------------------------------

ALTER TABLE Usuario
ADD CONSTRAINT FK_Usuario_TipoIdentificacionID FOREIGN KEY (TipoIdentificacionId) REFERENCES TipoIdentificacion(TipoIdentificacionId),
    CONSTRAINT FK_Usuario_RolId FOREIGN KEY (RolId) REFERENCES Rol(RolId);

ALTER TABLE Propietario
ADD CONSTRAINT FK_Propietario_TipoIdentificacionId FOREIGN KEY (TipoIdentificacionId) REFERENCES TipoIdentificacion(TipoIdentificacionId);

ALTER TABLE Paciente
ADD CONSTRAINT FK_Paciente_PropietarioId FOREIGN KEY (PropietarioId) REFERENCES Propietario(PropietarioId);

ALTER TABLE Cita
ADD CONSTRAINT FK_Cita_UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId),
    CONSTRAINT FK_Cita_PacienteId FOREIGN KEY (PacienteId) REFERENCES Paciente(PacienteId);

ALTER TABLE Consulta
ADD CONSTRAINT FK_Consulta_PacienteId FOREIGN KEY (PacienteId) REFERENCES Paciente(PacienteId),
    CONSTRAINT FK_Consulta_UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId),
    CONSTRAINT FK_Consulta_CitaId FOREIGN KEY (CitaId) REFERENCES Cita(CitaId);

ALTER TABLE Vacuna
ADD CONSTRAINT FK_Vacuna_PacienteId FOREIGN KEY (PacienteID) REFERENCES Paciente(PacienteID),
    CONSTRAINT FK_Vacuna_UsuarioId FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    CONSTRAINT FK_Vacuna_TipoVacunaId FOREIGN KEY (TipoVacunaID) REFERENCES TipoVacuna(TipoVacunaID);

ALTER TABLE Desparasitacion
ADD CONSTRAINT FK_Desparasitacion_PacienteID FOREIGN KEY (PacienteId) REFERENCES Paciente(PacienteId),
    CONSTRAINT FK_Desparasitacion_UsuarioID FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId);

ALTER TABLE Cirugia
ADD CONSTRAINT FK_Cirugia_TipoCirugiaId FOREIGN KEY (TipoCirugiaId) REFERENCES TipoCirugia(TipoCirugiaId),
    CONSTRAINT FK_Cirugia_PacienteId FOREIGN KEY (PacienteId) REFERENCES Paciente(PacienteId),
    CONSTRAINT FK_Cirugia_UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId);

ALTER TABLE FormulaMedica
ADD CONSTRAINT FK_FormulaMedica_PacienteId FOREIGN KEY (PacienteId) REFERENCES Paciente(PacienteId),
    CONSTRAINT FK_FormulaMedica_UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId),
    CONSTRAINT FK_FormulaMedica_UsuarioCreacionId FOREIGN KEY (UsuarioCreacionId) REFERENCES Usuario(UsuarioId),
    CONSTRAINT FK_FormulaMedica_UsuarioModificacionId FOREIGN KEY (UsuarioModificacionId) REFERENCES Usuario(UsuarioId);
GO

ALTER TABLE Medicamento
ADD CONSTRAINT FK_Medicamento_FormulaMedicaId FOREIGN KEY (FormulaMedicaId) REFERENCES FormulaMedica(FormulaMedicaId),
    CONSTRAINT FK_Medicamento_UsuarioCreacionId FOREIGN KEY (UsuarioCreacionId) REFERENCES Usuario(UsuarioId),
    CONSTRAINT FK_Medicamento_UsuarioModificacionId FOREIGN KEY (UsuarioModificacionId) REFERENCES Usuario(UsuarioId);
GO

ALTER TABLE ExamenLaboratorio
ADD CONSTRAINT FK_ExamenLaboratorio_PacienteId FOREIGN KEY (PacienteId) REFERENCES Paciente(PacienteId),
    CONSTRAINT FK_ExamenLaboratorio_UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId),
    CONSTRAINT FK_ExamenLaboratorio_TipoExamenId FOREIGN KEY (TipoExamenId) REFERENCES TipoExamen(TipoExamenId);

ALTER TABLE ImagenDiagnostico
ADD CONSTRAINT FK_ImagenDiagnostico_PacienteId FOREIGN KEY (PacienteId) REFERENCES Paciente(PacienteId),
    CONSTRAINT FK_ImagenDiagnostico_UsuarioIs FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId),
    CONSTRAINT FK_ImagenDiagnostico_TipoImagenDiagnosticaId FOREIGN KEY (TipoImagenDiagnosticaId) REFERENCES TipoImagenDiagnostica(TipoImagenDiagnosticaId);
GO

-- *****************************
-- Procedimientos de Almacenado
-- *****************************
CREATE PROCEDURE uspUsuarioClaveValida
    @UsuarioId UNIQUEIDENTIFIER,
    @clave VARCHAR(32) -- Se ajusta la longitud de la clave según la longitud máxima esperada
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @salt VARCHAR(32); -- Cambiar a VARCHAR
    DECLARE @HashClaveBD VARCHAR(32); -- Cambiar a VARCHAR
    DECLARE @HashClaveUsuario VARBINARY(32); 
    DECLARE @claveConSalt VARBINARY(MAX);

    -- Obtener el hash y el salt almacenados en la base de datos
    SELECT @HashClaveBD = Clave, @salt = Salt
    FROM Usuario
    WHERE UsuarioId = @UsuarioId;

    -- Asegurarse de que el Salt no sea NULL antes de concatenar
    IF @salt IS NOT NULL
    BEGIN
        -- Concatenar el salt con la clave proporcionada
        SET @claveConSalt = CONVERT(VARBINARY(MAX), @salt) + CONVERT(VARBINARY(MAX), @clave); 

        -- Calcular el hash de la clave concatenada con el salt
        SET @HashClaveUsuario = HASHBYTES('SHA2_256', @claveConSalt);

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
    @tipoIdentificacionId UNIQUEIDENTIFIER,
    @rolId UNIQUEIDENTIFIER,
    @numeroIdentificacion VARCHAR(16),
    @nombre VARCHAR(128),
    @Apellido VARCHAR(128),
    @telefono VARCHAR(16),
    @correoElectronico VARCHAR(128),
    @tarjetaProfesional VARCHAR(64),
    @clave VARCHAR(32), 
	@fechaCreacion DATETIME,
    @usuarioCreacionId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

  
    DECLARE @salt VARBINARY(32);
    DECLARE @claveConSalt VARBINARY(MAX);
    DECLARE @hashClave VARBINARY(32);     

   SET @salt = CAST(CRYPT_GEN_RANDOM(32) AS VARBINARY(32));

    -- Concatenar el salt con la clave
    SET @claveConSalt = @salt + CAST(@clave AS VARBINARY(MAX));

    -- Calcular el hash de la clave concatenada con el salt
    SET @hashClave = HASHBYTES('SHA2_256', @claveConSalt);

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
        @tipoIdentificacionId,
        @rolId,
        @numeroIdentificacion,
        @nombre,
        @Apellido,
        @telefono,
        @correoElectronico,
        @tarjetaProfesional,
        @hashClave, 
        @salt,
        @fechaCreacion,
        @fechaCreacion,
        @usuarioCreacionId,
        @usuarioCreacionId
    );
END;
GO

CREATE PROCEDURE [dbo].[uspUsuarioActualizar]
    @usuarioId UNIQUEIDENTIFIER,
    @tipoIdentificacionId UNIQUEIDENTIFIER,
    @rolId UNIQUEIDENTIFIER,
    @numeroIdentificacion VARCHAR(16),
    @nombre VARCHAR(128),
    @apellido VARCHAR(128),
    @telefono VARCHAR(16),
    @correoElectronico VARCHAR(128),
    @tarjetaProfesional VARCHAR(64),
    @fechaModificacion DATETIME,
    @usuarioModificacionId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
        
        UPDATE Usuario
        SET TipoIdentificacionId = @tipoIdentificacionId,
            RolID = @rolId,
            NumeroIdentificacion = @numeroIdentificacion,
            Nombre = @nombre,
            Apellido = @apellido,
            Telefono = @telefono,
            CorreoElectronico = @correoElectronico,
            TarjetaProfesional = @tarjetaProfesional,
            FechaModificacion = @fechaModificacion,
            UsuarioModificacionId = @usuarioModificacionId
        WHERE UsuarioID = @usuarioId;
END;
GO


CREATE PROCEDURE [dbo].[uspUsuarioClaveActualiza]
	@usuarioId UNIQUEIDENTIFIER,
	@claveNueva VARCHAR(32)
AS
BEGIN

	SET NOCOUNT ON;

    DECLARE @salt VARBINARY(32);
    DECLARE @claveConSalt VARBINARY(MAX);
    DECLARE @hashClave VARBINARY(32); 

	SET @salt = CAST(CRYPT_GEN_RANDOM(32) AS VARBINARY(32));

    -- Concatenar el salt con la clave
    SET @claveConSalt = @salt + CAST(@claveNueva AS VARBINARY(MAX));

    -- Calcular el hash de la clave concatenada con el salt
    SET @hashClave = HASHBYTES('SHA2_256', @claveConSalt);

	UPDATE Usuario  
	SET Clave = @hashClave
		, Salt= @salt
	WHERE Usuario.UsuarioId = @usuarioId
END;
GO

-- Insertar TipoIdentificacion
DECLARE @NewUsuarioId UNIQUEIDENTIFIER;
SET @newUsuarioId = NEWID();

INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Cedula de ciudadania', GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Tarjeta de identidad' , GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Cedula de extranjeria', GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Pasaporte', GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Registro civil', GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('NIT', GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId);
INSERT INTO TipoIdentificacion (Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES ('Otro', GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId);

DECLARE @rolId  UNIQUEIDENTIFIER;
SET	@rolId = NEWID();
INSERT INTO Rol(RolID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) VALUES (@rolId, 'Administrador', GETDATE(), GETDATE(), @newUsuarioId, @newUsuarioId)
--------------------------------------------------------------

-- Insertar un usuario por defecto
DECLARE @salt VARBINARY(32);
DECLARE @hashClave VARBINARY(32);
DECLARE @clave VARCHAR(32) = 'admin123'; -- La clave que deseas establecer

-- Generar un nuevo salt
SET @salt = CAST(CRYPT_GEN_RANDOM(32) AS VARBINARY(32));

-- Concatenar el salt con la clave
DECLARE @claveConSalt VARBINARY(MAX); 
SET @claveConSalt = @salt + CAST(@clave AS VARBINARY(MAX));

-- Calcular el hash de la clave concatenada con el salt
SET @hashClave = HASHBYTES('SHA2_256', @claveConSalt);

INSERT INTO Usuario (
    UsuarioId,
    TipoIdentificacionId,
    RolId,
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
    UsuarioCreacionId,
    UsuarioModificacionId
)
VALUES (
    @newUsuarioId,
    (SELECT TipoIdentificacionId FROM TipoIdentificacion WHERE Descripcion = 'Otro'), 
    @rolId, 
    '123456789', 
    'Admin', 
    'Admin', 
    '0000000000', 
    'admin@example.com', 
    NULL, 
    @hashClave, 
    @salt,
    GETDATE(), 
    GETDATE(), 
    @newUsuarioId, 
    @newUsuarioId
);
GO