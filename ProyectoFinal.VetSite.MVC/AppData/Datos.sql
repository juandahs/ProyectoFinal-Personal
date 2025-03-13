USE VetSite

-- Insertar TipoIdentificacion
DECLARE @NewUsuarioId UNIQUEIDENTIFIER;
SET @NewUsuarioId = NEWID();

DECLARE @NewTipoIdentificacionId UNIQUEIDENTIFIER;

-- Insertar múltiples registros en TipoIdentificacion
SET @NewTipoIdentificacionId = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionId, Posicion, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@NewTipoIdentificacionId, 1, 'Cedula de ciudadania', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);


SET @NewTipoIdentificacionId = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionId, Posicion, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@NewTipoIdentificacionId, 2, 'NIT', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);


SET @NewTipoIdentificacionId = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionId, Posicion, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@NewTipoIdentificacionId, 3, 'Cedula de extranjeria', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);

SET @NewTipoIdentificacionId = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionId, Posicion, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@NewTipoIdentificacionId, 4, 'Pasaporte', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);

SET @NewTipoIdentificacionId = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionId, Posicion, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@NewTipoIdentificacionId, 5, 'Registro civil', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);

SET @NewTipoIdentificacionId = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionID, Posicion, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@NewTipoIdentificacionId, 6, 'Tarjeta de identidad', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);


SET @NewTipoIdentificacionId = NEWID();
INSERT INTO TipoIdentificacion (TipoIdentificacionId, Posicion, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@NewTipoIdentificacionId, 7, 'Otro', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);

-- Insertar Rol
DECLARE @RolId UNIQUEIDENTIFIER;
SET @RolId = NEWID();
INSERT INTO Rol(RolId, Descripcion, FechaCreacion, FechaModificacion, UsuarioCreacionId, UsuarioModificacionId) 
VALUES (@RolId, 'Administrador', GETDATE(), GETDATE(), @NewUsuarioId, @NewUsuarioId);



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
    UsuarioId,
    TipoIdentificacionId,
    RolId,
    NumeroIdentificacion,
    Nombre,
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
    @NewUsuarioId,
    (SELECT TipoIdentificacionId FROM TipoIdentificacion WHERE Descripcion = 'Otro'), 
    @RolId, 
    '123456789', 
    'Admin', 
    '0000000000', 
    'admin@example.com', 
    NULL, 
    @HashClave, 
    @Salt,
    GETDATE(), 
    GETDATE(), 
    @NewUsuarioId, 
    @NewUsuarioId
);
