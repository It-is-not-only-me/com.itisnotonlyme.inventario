using System.Collections;
using System.Collections.Generic;

namespace ItIsNotOnlyMe.Inventario
{
    public class Inventario : IInventario
    {
        public List<IEspacio> _espacios;

        public Inventario()
        {
            _espacios = new List<IEspacio>();
        }

        public bool AgregarEspacio(IEspacio espacio)
        {
            _espacios.Add(espacio);
            return true;
        }

        public void AplicarOperacion(IOperacionElementos operacion)
        {
            foreach (IEspacio espacio in _espacios)
                espacio.AplicarOperacion(operacion);
        }

        public void AplicarOperacion(IOperacionEspacios operacion)
        {
            foreach (IEspacio espacio in _espacios)
                operacion.Aplicar(espacio);
        }
    }
}
