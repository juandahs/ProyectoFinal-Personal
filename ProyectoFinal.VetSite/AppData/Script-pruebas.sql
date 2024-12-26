    -- ************************************************************
    --						PROBAR VALIDAR CLAVE
    -- ************************************************************
	    USE VetSite;
	    DECLARE @UsuarioID UNIQUEIDENTIFIER;
	    DECLARE @Respuesta BIT;

	    -- Obtener el UsuarioID del usuario 'Admin'
	    SET @UsuarioID = (SELECT UsuarioID FROM Usuario WHERE Nombre = 'Admin');

	    -- Ejecutar el procedimiento almacenado y capturar el valor de retorno
	    EXEC @Respuesta = uspUsuarioValido @UsuarioID = @UsuarioID, @Clave = 'admin123';

	    -- Mostrar el resultado
	    SELECT @Respuesta AS Resultado;



-- ************************************************************
--						PROBAR INSERTAR USUARIO
-- ************************************************************
USE VetSite;

DECLARE @TipoIdentificacionID UNIQUEIDENTIFIER;
DECLARE @RolID UNIQUEIDENTIFIER;
DECLARE @UsuarioCreacionID UNIQUEIDENTIFIER;
DECLARE @Fecha DATETIME;
SET @Fecha = GETDATE();

-- Obtener el TipoIdentificacionID, RolID y UsuarioCreacionID
SET @TipoIdentificacionID = (SELECT TipoIdentificacionID FROM TipoIdentificacion WHERE Descripcion = 'Otro');
SET @RolID = (SELECT RolID FROM Rol WHERE Descripcion = 'Administrador');
SET @UsuarioCreacionID = (SELECT UsuarioID FROM Usuario WHERE Nombre = 'Admin');
-- Ejecutar el procedimiento almacenado para insertar el usuario
EXEC uspUsuarioInsertar
    @TipoIdentificacionID = @TipoIdentificacionID,
    @RolID = @RolID,
    @NumeroIdentificacion = '1234567890',
    @Nombre = 'Juan',
    @Apellido = 'Pérez',
    @Telefono = '1234567890',
    @CorreoElectronico = 'juan.perez@example.com',
    @TarjetaProfesional = 'TP123456',
    @Clave = 'MiContraseñaSegura',
    @FechaCreacion = @Fecha,
    @FechaModificacion = @Fecha,
    @UsuarioCreacionID = @UsuarioCreacionID,
    @UsuarioModificacionID = @UsuarioCreacionID;

-- Verificar la inserción
SELECT * FROM Usuario;
