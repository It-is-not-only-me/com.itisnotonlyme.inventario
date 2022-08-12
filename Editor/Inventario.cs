﻿using System.Collections;
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

        public bool AgregarElemento(IElemento elemento)
        {
            AgregarElemento operacion = new AgregarElemento(elemento);
            AplicarOperacion(operacion);
            return operacion.SePudoAgregar();
        }

        public bool SacarElemento(IElemento elemento)
        {
            SacarElemento operacion = new SacarElemento(elemento);
            AplicarOperacion(operacion);
            return operacion.SePudoEliminar();
        }

        public bool TieneEspacio(IElemento elemento)
        {
            TieneEspacio operacion = new TieneEspacio(elemento);
            AplicarOperacion(operacion);
            return operacion.TieneEspacioParaElemento();
        }

        public int CantidadElementosTotales()
        {
            CantidadElementosTotales operacion = new CantidadElementosTotales();
            AplicarOperacion(operacion);
            return operacion.CantidadTotal();
        }

        public int CantidadElementos(IElemento elemento)
        {
            ElementosIguales operacion = new ElementosIguales(elemento);
            AplicarOperacion(operacion);
            return operacion.CantidadTotal();
        }

        public List<IElemento> ObtenerElementos()
        {
            ObtenerElementos operacion = new ObtenerElementos();
            AplicarOperacion(operacion);
            return operacion.ElementosObtenidos();
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

    public class SacarElemento : IOperacionEspacios
    {
        private IElemento _elemento;
        private bool _seElimino;

        public SacarElemento(IElemento elemento)
        {
            _elemento = elemento;
            _seElimino = false;
        }

        public void Aplicar(IEspacio espacios)
        {
            if (_seElimino)
                return;

            _seElimino = espacios.SacarElemento(_elemento);
        }

        public bool SePudoEliminar() => _seElimino;
    }
}