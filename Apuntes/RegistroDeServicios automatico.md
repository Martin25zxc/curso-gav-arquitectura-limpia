Dependencia de una libreria de 3ros para no ir poniendo un AddScoped por cada UseCase que se cree

- Instalar Scrutor en el proyecto Application

services.Scan(scan =>
scan.FromAssembliesOf(typeof(IMediator))
//sin response
.AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
.AsImplementedInterfaces()
.WithScopedLifetime()
//con response
.AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
.AsImplementedInterfaces()
.WithScopedLifetime());
