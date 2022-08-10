using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.Inventario
{
    public interface IInventario
    {
        public void AgregarEspacio(IEspacio espacio);

        public bool Agregar(IElemento elemento);

        public bool TieneEspacio();
    }

    public class Inventario : IInventario
    {
        List<IEspacio> _espacios;

        public Inventario()
        {
            _espacios = new List<IEspacio>();
        }

        public void AgregarEspacio(IEspacio espacio)
        {
            _espacios.Add(espacio);
        }

        public bool Agregar(IElemento elemento)
        {
            bool agregado = false;

            for (int i = 0; i < _espacios.Count && !agregado; i++)
            {
                IEspacio espacio = _espacios[i];
                if (!espacio.TieneEspacio(elemento))
                    continue;

                agregado = espacio.Agregar(elemento);                                    
            }

            return agregado;
        }

        public bool TieneEspacio()
        {
            bool tieneEspacio = false;

            foreach (IEspacio espacio in _espacios)
                tieneEspacio |= espacio.TieneEspacio();

            return tieneEspacio;
        }
    }

    public interface IEspacio
    {
        public bool Agregar(IElemento elemento);

        public bool TieneEspacio();

        public bool TieneEspacio(IElemento elemento);
    }

    public interface IElemento
    {
        public bool EsIgual(IElemento elemento);
    }
}
