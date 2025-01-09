USE VetSite

-- Insertar TipoIdentificacion
DECLARE @NewUsuarioID UNIQUEIDENTIFIER;
SET @NewUsuarioID = NEWID();

DECLARE @NewTipoIdentificacionID UNIQUEIDENTIFIER;

-- Insertar múltiples registros en TipoIdentificacion
SET @NewTipoIdentificacionID = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@NewTipoIdentificacionID, 'Cedula de ciudadania', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

SET @NewTipoIdentificacionID = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@NewTipoIdentificacionID, 'Tarjeta de identidad', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

SET @NewTipoIdentificacionID = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@NewTipoIdentificacionID, 'Cedula de extranjeria', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

SET @NewTipoIdentificacionID = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@NewTipoIdentificacionID, 'Pasaporte', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

SET @NewTipoIdentificacionID = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@NewTipoIdentificacionID, 'Registro civil', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

SET @NewTipoIdentificacionID = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@NewTipoIdentificacionID, 'NIT', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

SET @NewTipoIdentificacionID = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@NewTipoIdentificacionID, 'Otro', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);

-- Insertar Rol
DECLARE @RolID UNIQUEIDENTIFIER;
SET @RolID = NEWID();
INSERT INTO Rol(RolID, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionID, UsuarioModificacionID) 
VALUES (@RolID, 'Administrador', GETDATE(), GETDATE(), @NewUsuarioID, @NewUsuarioID);



-- Insertar un usuario por defecto
DECLARE @Salt VARBINARY(32);
DECLARE @HashClave VARBINARY(32);
DECLARE @Clave VARCHAR(32) = 'admin123'; -- La clave

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
