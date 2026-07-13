Microsoft.EntityFrameworkCore.SqlServer

Configurations
Configurar
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(OdontDbContext).Assembly);
   }

La CN va en el proyecto ejecutable!

Para crear la bd podemos instalar en el ejecutable (api)
entityframeworkcore.tools
O design si no usas visual studio


Add-Migration Tabla
Update-Database