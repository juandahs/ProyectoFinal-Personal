@echo off

:: Directorio origen (la carpeta de la cual quieres copiar el contenido)
SET ORIGEN=AppData\

:: Directorio destino (la carpeta a la cual quieres copiar el contenido)
SET DESTINO=bin\Releasi\net8.0\AppData

:: Comando para copiar todo el contenido de la carpeta origen al destino
xcopy "%ORIGEN%" "%DESTINO%" /E /I /Y

echo Contenido copiado con exito de %ORIGEN% a %DESTINO%.

