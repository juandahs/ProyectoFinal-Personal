
namespace ProyectoFinal.Repositorio
{
    public struct Scripts
    {
        public static readonly string uspUsuarioValidoNombre = "uspUsuarioValido";
        public static readonly string uspUsuarioValido = $"""
            CREATE PROCEDURE {uspUsuarioValidoNombre}
              @UsuarioID UNIQUEIDENTIFIER,
                @Clave VARCHAR(32)
            AS
            BEGIN
                SET NOCOUNT ON;

                DECLARE @Salt VARCHAR(32);
                DECLARE @HashClaveBD VARCHAR(32);
                DECLARE @HashClaveUsuario VARBINARY(32); 
                DECLARE @ClaveConSalt VARBINARY(MAX);

                -- Obtener el hash y el salt almacenados en la base de datos
                SELECT @HashClaveBD = Clave, @Salt = Salt
                FROM Usuario
                WHERE UsuarioID = @UsuarioID;

                -- Verificar si no se encontró el usuario o la clave
                IF @Salt IS NULL OR @HashClaveBD IS NULL
                BEGIN
                    -- Si no hay salt o clave en la BD, se considera inválida la autenticación
                    RETURN 0; -- Contraseña inválida
                END

                -- Concatenar el salt con la clave proporcionada
                SET @ClaveConSalt = CONVERT(VARBINARY(MAX), @Salt) + CONVERT(VARBINARY(MAX), @Clave); 

                -- Calcular el hash de la clave concatenada con el salt
                SET @HashClaveUsuario = HASHBYTES('SHA2_256', @ClaveConSalt);

                -- Comparar los hashes
                IF @HashClaveBD = CONVERT(VARCHAR(32), @HashClaveUsuario) -- Comparar como VARCHAR
                    RETURN 1; -- Contraseña válida
                ELSE
                    RETURN 0; -- Contraseña inválida
            END;
            """;

        public static readonly string uspUsuarioInsertarNombre = "uspUsuarioInsertar";
        public static readonly string uspUsuarioInsertar = $"""
            CREATE PROCEDURE {uspUsuarioInsertarNombre}
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
            """;

        public static readonly string uspUsuarioActualizarNombre = "uspUsuarioActualizar";
        public static readonly string uspUsuarioActualizar = $"""
            CREATE PROCEDURE {uspUsuarioActualizarNombre}
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
            """;
    }
}
