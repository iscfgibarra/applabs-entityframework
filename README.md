# AppLabs EntityFramework

El objetivo de está libreria es simplificar el inicio de cualquier proyecto con patrones ya conocidos.


Para usarlo es necesario primero iniciar una factoria.

```[C#]
var DBfactory = new DatabaseFactory<AnatomiaContext>(new DataAccessConfiguration("CADENA_DE_CONEXION", false));
```

