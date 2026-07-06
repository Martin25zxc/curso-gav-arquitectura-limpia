Arquitectura monolitica 
Todo se encuentra en un modulo
Ideal para proyectos pequeños
no es muy escalable

Arquitectura en capas
Tipicamente se dividente en 3 capas: presentacion, logica de negocio, acceso a datos
Cierto grado de flexibilidad
Desventaja, poca flexibilidad entre capas: dos capas de acceso a datos, sql o progrest? no es tan sencillo,

Arquitectura Limpia
Problematica
Codigo de ngocio mezclado con detalles tecnico
Servicios que dependen de todo, controladora es que hacen demasiado, clases de infra que contienen regla de negocio 

Consecuencia 
Un cambio sencillo te hace reahacer media app

La Arquitectura limpia es una forma de estructura nuestras aplicaciones para que la logica de negocio este en el centro,
independiente de detalles de implem

Partes:
Varios circulos concentricos
Nucleo: Core : Dominio, Aplicacion

Dominio
Colocamos principalmente entidades, excepciones personalizadas y lógica de negocio.

aplicacion
Casos de uso: acciones que el usuario puede realizar en la aplicación,
que tiene que pasar?

Infraestructura
La responsabilidad de definir los detalles de implementación recae en esta capa. Aquí se encuentran los detalles de implementación, como bases de datos, servicios externos, etc.
Aca dice el como, como se van realizar las acciones definidas en la aplicacion

UI
Es donde interactua el usuario 

Beneficiso de arquitectura limpia
Logica mas facil de testear
Mayor flexibilidad
mantenibilidad y escalibilidad
Controladores mas limpios

Desventajas
Mayor complejidad inicial, requier mas tiempo
Curva de aprendiazaje, es mas desconocida por los equipos
Repetir Codigo
Dificultad para depurar

Util para soluciones empresariales

Conceptos que sirven para la arquitectura

Inversion de dependencias
nuestras clases deben de depender de abstracciones no de tipos concretos
Usar los contratos y no las implementaciones

Separacion de preocupaciones / separations of concerns
Cada modulo de la aplciacion debe encargarse de una cosa
No debemos colocar lo que corresponde a otra capa en un modulo

Responsabilidad unica
Esta establece que una clase debe tener una unica razon para cambiar
Si una clase tiene varios componentes, acceso a bd, crear request http, logica de negocio, etc. tendremos mas de una razon para cambiar.

Ignorancia del mecanismo de persistencia
El dominio no debe conocer los detalles de la persistencia de datos.
Ejemplo si hay un modelo que tenga atributos de persistencia estos ensuciarian el dominio y solo deberian conocer las propeidades (no atributos table, collection, etc)

La arquitectura limpia es una forma de estructura nuestras aplciaciones para que la logica de negocio este en el centro, independiente 