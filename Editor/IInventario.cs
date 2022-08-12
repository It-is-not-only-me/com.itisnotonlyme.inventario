using System.Collections;
using UnityEngine;

namespace ItIsNotOnlyMe.Inventario
{
    public interface IInventario
    {
        public bool AgregarEspacio(IEspacio espacio);

        public void AplicarOperacion(IOperacionElementos operacion);

        public void AplicarOperacion(IOperacionEspacios operacion);
    }
}
