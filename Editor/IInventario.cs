using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.Inventario
{
    public interface IInventario
    {
        public bool Agregar(IElemento elemento);

        public bool TieneEspacio();
    }

    public class Inventario : IInventario
    {
        public Inventario()
        {

        }

        public bool Agregar(IElemento elemento)
        {
            return false;
        }

        public bool TieneEspacio()
        {
            return false;
        }
    }

    public interface ISlot
    {

    }

    public interface IElemento
    {

    }
}
