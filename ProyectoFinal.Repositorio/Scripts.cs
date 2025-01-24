
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
                    @tipoIdentificacionId,
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
            """;
    }
}
