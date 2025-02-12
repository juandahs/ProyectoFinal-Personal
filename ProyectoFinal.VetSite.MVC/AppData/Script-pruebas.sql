    -- ************************************************************
    --						PROBAR VALIDAR CLAVE
    -- ************************************************************
	    USE VetSite;
	    DECLARE @UsuarioId UNIQUEIDENTIFIER;
	    DECLARE @Respuesta BIT;

	    -- Obtener el UsuarioID del usuario 'Admin'
	    SET @UsuarioId = (SELECT UsuarioId FROM Usuario WHERE Nombre = 'Admin');

	    -- Ejecutar el procedimiento almacenado y capturar el valor de retorno
	    EXEC @Respuesta = uspUsuarioValido @UsuarioId = @UsuarioId, @Clave = 'admin123';

	    -- Mostrar el resultado
	    SELECT @Respuesta AS Resultado;



-- ************************************************************
--						PROBAR INSERTAR USUARIO
-- ************************************************************
USE VetSite;

DECLARE @TipoIdentificacionId UNIQUEIDENTIFIER;
DECLARE @RolId UNIQUEIDENTIFIER;
DECLARE @UsuarioCreacionId UNIQUEIDENTIFIER;
DECLARE @Fecha DATETIME;
SET @Fecha = GETDATE();

-- Obtener el TipoIdentificacionID, RolID y UsuarioCreacionID
SET @TipoIdentificacionId = (SELECT TipoIdentificacionId FROM TipoIdentificacion WHERE Descripcion = 'Otro');
SET @RolId = (SELECT RolId FROM Rol WHERE Descripcion = 'Administrador');
SET @UsuarioCreacionId = (SELECT UsuarioId FROM Usuario WHERE Nombre = 'Admin');
-- Ejecutar el procedimiento almacenado para insertar el usuario
EXEC uspUsuarioInsertar
    @TipoIdentificacionId = @TipoIdentificacionId,
    @RolId = @RolId,
    @NumeroIdentificacion = '1234567890',
    @Nombre = 'Juan',
    @Apellido = 'P�rez',
    @Telefono = '1234567890',
    @CorreoElectronico = 'juan.perez@example.com',
    @TarjetaProfesional = 'TP123456',
    @Clave = 'MiContrase�aSegura',
    @FechaCreacion = @Fecha,    
    @UsuarioCreacionId = @UsuarioCreacionId
    

-- Verificar la inserci�n
SELECT * FROM Usuario;



-- ************************************************************
--						PROBAR ACTUALIZAR USUARIO
-- ************************************************************
USE VetSite;

DECLARE @UsuarioId UNIQUEIDENTIFIER;
DECLARE @TipoIdentificacionId UNIQUEIDENTIFIER;
DECLARE @RolId UNIQUEIDENTIFIER;
DECLARE @UsuarioModificacionId UNIQUEIDENTIFIER;
DECLARE @Fecha DATETIME;
SET @Fecha = GETDATE();

-- Obtener el UsuarioId del usuario "Juan P�rez"
SET @UsuarioId = (SELECT UsuarioId FROM Usuario WHERE Nombre = 'Juan' AND Apellido = 'P�rez');

-- Verificar si el UsuarioId fue encontrado
IF @UsuarioId IS NULL
BEGIN
    PRINT 'El usuario "Juan P�rez" no existe en la tabla Usuario.';
    RETURN;
END;

-- Obtener el TipoIdentificacionID, RolID y UsuarioModificacionID
SET @TipoIdentificacionId = (SELECT TipoIdentificacionId FROM TipoIdentificacion WHERE Descripcion = 'Otro');
SET @RolId = (SELECT RolId FROM Rol WHERE Descripcion = 'Usuario');
SET @UsuarioModificacionId = (SELECT UsuarioId FROM Usuario WHERE Nombre = 'Admin');

-- Ejecutar el procedimiento almacenado para actualizar el usuario
EXEC uspUsuarioActualizar
    @usuarioId = @UsuarioId,
    @tipoIdentificacionId = @TipoIdentificacionId,
    @rolId = @RolId,
    @numeroIdentificacion = '9876543210',
    @nombre = 'Juan',
    @apellido = 'P�rez Actualizado',
    @telefono = '0987654321',
    @correoElectronico = 'juan.perez.updated@example.com',
    @tarjetaProfesional = 'TP987654',
    @fechaModificacion = @Fecha,
    @usuarioModificacionId = @UsuarioModificacionId;

-- Verificar la actualizaci�n
PRINT 'Informaci�n actualizada del usuario "Juan P�rez":';
SELECT * 
FROM Usuario 
WHERE UsuarioId = @UsuarioId;


-- ************************************************************
--						PROBAR ACTUALIZAR USUARIO
-- ************************************************************

USE VetSite;

DECLARE @UsuarioId UNIQUEIDENTIFIER;

-- Obtener el UsuarioId con TOP 1 para evitar m�ltiples resultados
SET @UsuarioId = (SELECT TOP 1 UsuarioId FROM Usuario WHERE Nombre = 'admin');

-- Validar si el usuario existe antes de ejecutar el procedimiento
IF @UsuarioId IS NOT NULL
BEGIN
    EXEC uspUsuarioClaveActualizar 
        @usuarioId = @UsuarioId, 
        @claveNueva = 'admin321';
END
ELSE
BEGIN
    PRINT 'Usuario no encontrado.';
END
