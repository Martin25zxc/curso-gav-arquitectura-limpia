La capa de aplicacion orquesta la logica de negocio sin preocuparse por detalles de infraestructura op rsentacion.

Es externa a la capa de dominio, entonces va depende unicamente de ella, no tendra de dependencias de las demas capas

La capa de aplicación es la que se encarga de orquestar los casos de uso del sistema
Los casos de uso son acciones específicas que realiza el sistema para cumplir una necesidad del usuario


Los casos de uso son acciones especificas que realiza el sistema para cumplir con una necesidad del usuario
La mision de un caso de uso, es coordinar el trabajo de los distintos elementos de la solucion
En esta capa se indica paso x paso para que esta tarea se lleve acabo

La capa de aplicación no tiene los detalles de implementación 

Se limita a orquestar las distintas acciones que deben ocurrir para resolver una tarea por medio de uso de contratos

Contratos: interfaces que vamos a declarar en nuestra capa de aplicación

CQRS
Separa las operaciones de lectura y escritura para mejorar claridad y escalabilidad

Casos de uso
Representa acciones enfocadas en resolver necesidades del negocio de forma aislada

Patron mediador
Centraliza la comunicacion entre objetos para reducir el acoplamiento directo entre ellos