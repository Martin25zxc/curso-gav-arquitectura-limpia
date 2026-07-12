Microsoft.EntityFrameworkCore.SqlServer

Configurations
Configurar
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(OdontDbContext).Assembly);
   }
