# AppLabs EntityFramework
El objetivo de está libreria es simplificar el inicio de cualquier proyecto con patrones ya conocidos.

Ver el proyecto AppLabs.EntityFramework.Test para ejemplos de su uso, en el repositorio del proyecto.
Esta libreria solo genera un marco, es necesario agregar las librerias de EntityFrameworkCore que necesitas para tu base de datos.

Es necesario usar como destino la plaforma .NET Core 2.2 o superior para poderlo usarlo de lo contrario marcará problemas de compatibilidad.

## Sqlite

Se agrego el soporte para utilizar Sqlite en la configuración, añade a tu proyecto las librerias de Microsoft.EntityFrameworkCore.Sqlite y Microsoft.EntityFrameworkCore.Design,
para usar migraciones agrega también Microsoft.EntityFrameworkCore.Tools , verifica la clase TemporaryDbContextFactory.cs en la carpeta Helpers del proyecto de prueba.

La base de datos utilizada en el test, se encuentra en la carpeta DatabaseSqlite.

Verifica el proyecto de ejemplo para ver la configuración y uso.

Para mayor referencia verificar la [documentación de microsoft para Sqlite para EF.](https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite)