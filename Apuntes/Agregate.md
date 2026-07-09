Aggregate
Un agregado es un grupo de objetos del dominio que deben tratarse como una unidad consistente.

Dentro de ese grupo puede haber:

una entidad principal,
otras entidades internas,
value objects,
reglas de negocio,
métodos que modifican el estado.

La idea central es:

Un agregado protege una frontera de consistencia del dominio.

Es decir: define qué cosas deben cambiar juntas y bajo qué reglas.

Aggregate Root

El concepto no nace de Clean Architecture directamente, sino de DDD — Domain-Driven Design, pero se usa mucho dentro de la capa de dominio cuando querés modelar reglas de negocio correctamente.

Reglas prácticas para detectar agregados

Pensá en estas preguntas:

1. ¿Qué entidad tiene sentido cargar, modificar y guardar como unidad?
Probablemente sea un agregado.

2. ¿Qué objeto debe proteger las reglas del conjunto?
Ese es el Aggregate Root.

3. ¿Hay entidades que no tienen sentido sin otra entidad principal?
Probablemente son entidades internas del agregado.

4. ¿Se necesita consistencia inmediata entre estos objetos?
Entonces pueden pertenecer al mismo agregado.

5. ¿Puede cambiarse esto de forma independiente?
Entonces quizá debería ser otro agregado.

una Entity puede ser una Aggregate Root. De hecho, un Aggregate Root siempre es una Entity, porque necesita identidad.

En Clean Architecture, la capa de dominio debería contener las reglas importantes del negocio. La entidad/agregado decide si la operación es válida.

La idea ideal sería:

Modelar el dominio con entidades, value objects y agregados que tengan comportamiento real, protejan invariantes y eviten que el estado del sistema quede inválido.