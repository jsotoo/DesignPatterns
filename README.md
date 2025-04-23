Gestor virtual de Mascotas - API REST

Operaciones basicas

Crear mascota (nombre, tipo, edad).
Obtener todas las mascotas.
Realizar acciones: alimentar, bañar, jugar.
Estado de la mascota: feliz, triste, hambrienta, aburrida, sucia.


Patrones Aplicados

Creacionales

Factory Method	
* Crear mascotas según tipo (perro, gato etc.).

Singleton	
* Dentro de la carpeta Utils se generó un Logger aplicando el patrón registrando las acciones

Builder
* Crear mascotas paso a paso (con nombre, raza, edad, estado inicial).


Estructurales

Adapter
* Adaptar diferentes tipos de notificaciones como consola u otras ( en este caso consola)

Decorator
* Añadir características especiales a las mascotas (ropa, poderes, etc.).

Facade
* Simplifica la acción de cuidar una mascota (bañar + jugar + alimentar).


Comportamiento

Observer
* Notificar si el estado de la mascota cambia

Command
* Encapsular acciones como jugar, alimentar, bañar.

Strategy
* Cambiar el comportamiento al jugar (pelota, escondidas, saltar, etc.).


