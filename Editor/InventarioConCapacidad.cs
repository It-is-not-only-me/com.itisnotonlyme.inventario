using System.Collections.Generic;
using System.Collections;

namespace ItIsNotOnlyMe.Inventario
{
    public class InventarioConCapacidad : IInventario
    {
        private int _capacidad;

        private Inventario _inventario;

        public InventarioConCapacidad(int capacidad)
        {
            _capacidad = capacidad;
            _inventario = new Inventario();
        }

        public bool Agregar(IItem item)
        {
            return Lleno() ? false : _inventario.Agregar(item);
        }

        public bool Sacar(IItem item)
        {
            return Vacio() ? false : _inventario.Sacar(item);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Stack stack in _inventario)
                yield return stack;
        }

        public int Cantidad()
        {
            return _inventario.Cantidad();
        }

        private bool Lleno()
        {
            return Cantidad() >= _capacidad;
        }

        private bool Vacio()
        {
            return Cantidad() == 0;
        }
    }
}
