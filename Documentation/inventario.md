# Documentacion

Tenemos 5 interfaces:
 * IInventario
 * IEspacio
 * IElemento
 * IOperacionEspacios
 * IOperacionElementos

La base de esta implementacion son las ultimas, estas son para poder implementar las operaciones que sean necesarias para la implementacion especifica del inventario en la situacion.

Si bien son simples, su aplicacion se puede hacer que puedan hacer cosas como agregar elementos al inventario, recorrer todos los espacios que tienen, sacar elementos, contar elementos especificos. Hay algunas implementaciones de estas operaciones para dar como guia, pero la idea es adaptarlas para las necesidades especificas del proyecto.