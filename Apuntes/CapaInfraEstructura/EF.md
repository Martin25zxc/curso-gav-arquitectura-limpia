Microsoft.EntityFrameworkCore.SqlServer

Configurations
Configurar
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(OdontDbContext).Assembly);
   }

La CN va en el proyecto ejecutable!
No guardar usuarios ni contraseñas reales en el repositorio. Para secrets, usar variables de entorno o User Secrets.
Para crear la bd podemos instalar en el ejecutable (api)
entityframeworkcore.tools
O design si no usas visual studio


Add-Migration Tabla
Update-Database
Antes de ejecutar Update-Database, revisar el archivo de migración generado. EF Core interpreta los cambios del modelo, pero puede generar una operación no deseada, como eliminar y volver a crear una columna.
