Capa de dominio
Es donde modelamos los conceptos, reglas e invariantes del negocio que estamos resolviendo
La capa de dominio no depende de nada externo (no sabe si es una api o worker)
Su unica responsabilidad es expresar correctamente el problema del negocio

que debe contener la capa?

Entidades
Las entidades son objetos que tinen identidad propia que representan conceptos importantes del negocio
Cita
Paciente
Consultorio
No solo son contenedores datos, deben encapsular comportamiento y reglas

Objetos de valor / Vlaue Object

Representa un concepto del negocio que no tiene identidad por si misma (un email, una direccion, un intervalo de tiempo )
Son clases inmutables que encapsulan comportamientos y validaciones relacionados con ese valor
Nos ayuda a centralizar reglas ocmunies y evitar repeticiones de logica

Reglas del negocio
Las reglas que definen que es valido o invalido en el dominio no deben estar dentro de las entidades o los objetos de valor
De esta forma no importa quien maneje o muestre el dominio, las reglas se mantienen

Agregados
Un agregado es un conjunto de objetos del dominio (entidades y/o objetos de valor) que se tratan como una unidad válida
Está encabezado por una raíz de agregado, que es una entidad con ciclo de vida independiente y responsable de garantizar las invariantes del conjunto
Cuando hablamos de invariantes, hablamos de reglas de negocio que se deben de cumplir siempre.

Las propiedades de la entidad serán de solo lectura desde fuera de la clase
Así, para cambiar cualquier valor del agregado, tendremos que usar métodos de la clase
Y, a través de estos métodos, vamos a garantizar se cumplan las reglas del negocio

Excepciones del dominio
Cuando una regla del negocio se incumple, no basta con devolver un false; lo ideal es lanzar una excepción de dominio

que no debe contener
No ORM
No HTTP Context
NO DTOS
No envio de correos
No almacenamiento a disco
No conexion a Apis
