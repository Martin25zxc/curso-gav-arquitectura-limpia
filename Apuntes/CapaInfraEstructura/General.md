Representa la capa mas externa del sistema
(Envio de emails, BD, servicios de la nube, servicios de tercero, archivos)
No debe tener logica de negocio, debe ser una implementacion tecnica, implementar los contratos definidos en las capas interiores

Está encargada de interactuar con elementos externos
La responsabilidad principal de la infraestructura es implementar los contratos definidos por las capas interiores
La infraestructura se encarga de ese "cómo"
Principio de inversión de dependencias, la infraesctura depende de las capas internas e implementa lo que definen


Dentro del proyecto de infraestructura suelen encontrarse implementaciones concretas de los repositorios y de otros contratos
No debe haber lógica de negocio, ni validaciones del dominio, ni decisiones que afecten el comportamiento central del sistema

DBContext, ApiRest, Configuracion de Logs
Se puede tener uno o varios (persistencia, general(envio de correos), identidad)
NO DEBE HABER LOGICA DE NEGOCIO, ni tener objetos de presentacion

No debe intentar coordinar casos de uso, solo debe ejecutar 

UnitOfWork, implementacion, tener en cuenta que pueden haber varias por tecnologia(dapper, ef)


Persistencia
EFCore
Implementaciones