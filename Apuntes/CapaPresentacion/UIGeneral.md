La capa presentación (UI) cumple la función de punto de entrada al sistema
No contiene lógica de negocio
Lógica de presentación vs lógica de aplicación
¿Qué vamos a colocar en los controladores?
Dependeremos de las capas de aplicación e infraestructura

Es construir el comando o consulta, pasarselo al mediador y esa respuesta sera la que se devuelva

Referencia a los dintitos tipos de infra en la api

depende de infra y aplicacion
-------
Web Api: Rostro de la solucion, recibe peticiones devuelve respuesta
Controladores: Con el mediator no tiene idea de naaah
Excepciones: Centralizar manejo de excepciones evitando que los actions y controladores tenga que tomar decisiones 