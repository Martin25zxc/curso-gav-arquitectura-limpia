CQRS

CQRS: significa Command-Query Responsibility Segregation, o en español: Separación de responsabilidades entre comandos y consultas.
Es un patrón de arquitectura que propone separar las operaciones que modifican el estado del sistema de aquellas que solo consultan información

Nunca deberiamos tener un metodo que intente escribir y leer al mismo tiempo
Por que mezclar ambas reponsabilidades tienda a traer conflictos a la hora de mantener

Separar comandos y consultas

Un comando es una accion que modifica el sistema
Un consulta es una operacion que busca informacion sin modificar nada 
Un comando puede o no devolver un resultado pero si cambia el estado.
Una consulta solo le, nunca cambia nada 

Comando
Crear una cita

clase comandoCreacita
clase casodeusoCrearCita

Consulta
obtener citas
clase consultarobtenerlistadocitas
casodeusoobtenerlistadocitas

Por que aplicar CQRS?
Nos permite aplicar el principio de responsabilidad unica
Codigo es mas organizado
Es mas facil de aplicarle de pruebas automaticas por que sus clases tienen menos dependencias

Es opcional en arquictecuta limpia
Es útil, porque hace que la capa de aplicación sea más clara, testeable y mantenible