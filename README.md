# Resipass
Proyecto de control de acceso a residencial en .NET Core 2.1 (backend)

## Preparación de DB

### Crear DB con EF
Previo a la ejecución de la aplicación, es necesario actualizar la base de datos: Para ello debe dirigirse al directorio /src/Resipass.Data y desde ahí ejecutar el sigiente comando:
``` dotnet ef database update -s ../Resipass.Api ```.

### Troubleshooting con migraciones
En caso de que la migración definida en el repositorio no funcione puede ejecutar una nueva migración con el comando: ``` dotnet ef migrations add <nombre-deseado> -s ../Resipass.Api```
