# Resipass
Proyecto de control de acceso a residencial en .NET Core 2.1 (backend).

# **IMPORTANTE LEER**

## Preparación de DB

### Crear Base de Datos con EF
Previo a la ejecución de la aplicación, es necesario crear la base de datos: dirigase a su motor de SQLServer y cree manualmente una nueva BD con el nombre de: ```resipass```.
Una vez creada la base de datos puede proceder a ejecutar la migración. Para ello debe dirigirse al directorio ../src/Resipass.Data y desde ahí ejecutar el sigiente comando:
``` dotnet ef database update -s ../Resipass.Api ```.

### Troubleshooting con migraciones
En caso de que la migración definida en el repositorio no funcione puede ejecutar una nueva migración con el comando: ``` dotnet ef migrations add <nombre-deseado> -s ../Resipass.Api```.
Acto seguido, actulice la base de datos ejecutando la migración previamente creada con el comando: ``` dotnet ef database update <nombre-deseado> -s ../Resipass.Api```.

Si aún persisten los problemas para generar la base de datos y su estructura pruebe ejecutando manualmente los scripts que se han incluido en éste repositorio:
1. ```Resipass-DDL-Script.sql```
2. ```Resipass-DML-Seeder.sql```.

Para cualquiera de los caso de generación de la estructura de la Base de Datos puede ejecutar el script ```Resipass-DML-Seeder.sql``` el cual genera datos dummy que pueden ser útiles para probar toda la aplicación.

### Estructura de directorios
El proyecto está preparado para "reconocer" los archivos estáticos que servirián la aplicación del cliente. En éste caso es necesario que cree la siguiente estructura de directorios conjugado con los repositorios de backend y frontend para una óptima ejecucion:

```
<Nombre-Folder-Proyecto>
└───resipass.ui
└───Resipass
```
