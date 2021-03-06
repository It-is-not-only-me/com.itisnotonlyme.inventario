using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace ItIsNotOnlyMe.Inventario
{
    public class Inventario : IInventario
    {
        private List<Stack> _stacks;

        public Inventario()
        {
            _stacks = new List<Stack>();
        }

        public bool Agregar(IItem item)
        {
            foreach (Stack stack in _stacks)
                if (stack.EsIgual(item))
                {
                    stack.Agregar(item);
                    stack.Cantidad();
                    return true;
                }

            _stacks.Add(new Stack(item));
            return true;
        }

        public bool Sacar(IItem item)
        {
            if (Vacio())
                return false;

            foreach (Stack stack in _stacks)
                if (stack.EsIgual(item))
                {
                    stack.Sacar(item);
                    if (stack.Vacio())
                        _stacks.Remove(stack);
                    return true;
                }

            return false;
        }

        public int Cantidad()
        {            
            int cantidadTotal = 0;
            _stacks.ForEach(stack => cantidadTotal += stack.Cantidad());
            return cantidadTotal;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Stack stack in _stacks)
                yield return stack;
        }

        private bool Vacio()
        {
            return _stacks.Count == 0;
        }
    }
}
