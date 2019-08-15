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

## Inicio Rápido

Primero es necesario heredar la interfaz IDbContext tu contexto de datos e implementar la propiedad DataAccessConfiguration.

```csharp
public class BitacoraContext : DbContext, IDbContext
{
	public IDataAccessConfiguration DataAccessConfiguration { get; set; }
	...
```

Despues hay que sobrescribir el método OnConfiguring, esto es totalmente necesario poder usar los objetos de la libreria

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
	base.OnConfiguring(optionsBuilder);

	if (!optionsBuilder.IsConfigured)
	{
		if (DataAccessConfiguration.UseOnMemory)
		{
			optionsBuilder.UseInMemoryDatabase("DbInMemory");
		}
		else if (DataAccessConfiguration.UseSqlite)
		{
			optionsBuilder.UseSqlite(DataAccessConfiguration.ConnectionString);
		}
		else if(DataAccessConfiguration.UseSqlServer)
		{
			optionsBuilder.UseSqlServer(
				DataAccessConfiguration.ConnectionString, options => options.EnableRetryOnFailure());
		} else
		{
			optionsBuilder.UseSqlServer(
				DataAccessConfiguration.ConnectionString, options => options.EnableRetryOnFailure());
		}
	}
}
```

Puedes omitir propiedades o incluso usar solo la cadena de conexión.

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
	base.OnConfiguring(optionsBuilder);

	if (!optionsBuilder.IsConfigured)
	{
		optionsBuilder.UseSqlServer(DataAccessConfiguration.ConnectionString, options => options.EnableRetryOnFailure());
	}
}
```

El siguiente paso es añadir la configuracion (IDataAccessConfiguration).

### Configuracion Directa

En el proyecto AppLabs.EntityFramework.Test se demuestra el uso directo.
La IDataAccessConfiguration expone 4 propiedades para ayudar a la factoria a generar el DbContext de manera adecuada por medio del DatabaseFactory.

```csharp
public string ConnectionString { get; set; }
public bool UseOnMemory { get; set; }
public bool UseSqlite { get; set; }
public bool UseSqlServer { get; set; }
```

Ejemplo usando Sqlite

```csharp
[TestInitialize]
public void Initialize()
{
	_factory = new DatabaseFactory<BitacoraContext>
		(new DataAccessConfiguration("Data Source=E:\\bitacora.db", true));
	_uow = new UnitOfWork(_factory);
	InitProyectos();
	InitEtiquetas();
}
```

Ejemplo usando SqlServer (el constructor de DataAccessConfiguration establece por default SqlServer)

```csharp
[TestInitialize]
public void Initialize()
{
	_factory = new DatabaseFactory<BitacoraContext>
		(new DataAccessConfiguration("Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;"));
	_uow = new UnitOfWork<BitacoraContext>(_factory);
	InitProyectos();
	InitEtiquetas();
}
```

### Configuracion Directa (usando solo Unit of Work)

En el proyecto AppLabs.EntityFramework.Test se demuestra el uso directo omitiendo el Factory
Este método es util cuando vas usa multiples base de datos en un mismo proyecto.

Ejemplo usando Sqlite

```csharp
[TestInitialize]
public void Initialize()
{
	//La configuracion se pasa directa a la unidad de trabajo
	_uow = new UnitOfWork<BitacoraContext>(new DbContextConfiguration<BitacoraContext>("Data Source=C:\\DEV\\bitacora.db", true));
	InitProyectos();
	InitEtiquetas();
}
```

### Configuracion Web

En el proyecto AppLabs.EntityFramework.Web.Demo se muestra como
Para poder usar adecuadamente en un proyecto de .NET CORE 2.2+ primero seria necesario agregar la sección correspondiente en el appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "DataAccessConfiguration": {
    "ConnectionString": "Data Source=E:\\bitacora.db",
    "UseOnMemory": false,
    "UseSqlite": true,
    "UseSqlServer": false
  }
}
```

Y despues inyectar las dependiencias en startup.cs

```csharp
services.AddSingleton<IDataAccessConfiguration>(dc =>
              new DataAccessConfiguration($"{Configuration["DataAccessConfiguration:ConnectionString"]}",
				bool.Parse(Configuration["DataAccessConfiguration:UseSqlite"])));

services.AddScoped<IDatabaseFactory, DatabaseFactory<BitacoraContext>>();
services.AddTransient<IUnitOfWork<BitacoraContext>, UnitOfWork>();
services.AddTransient<IRepository<Proyecto>, Repository<Proyecto>>();
services.AddTransient<IRepository<Etiqueta>, Repository<Etiqueta>>();
services.AddTransient<IRepository<Entrada>, Repository<Entrada>>();
```
