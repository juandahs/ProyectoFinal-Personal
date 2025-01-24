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
    @Apellido = 'Pérez',
    @Telefono = '1234567890',
    @CorreoElectronico = 'juan.perez@example.com',
    @TarjetaProfesional = 'TP123456',
    @Clave = 'MiContraseñaSegura',
    @FechaCreacion = @Fecha,    
    @UsuarioCreacionId = @UsuarioCreacionId
    

-- Verificar la inserción
SELECT * FROM Usuario;
