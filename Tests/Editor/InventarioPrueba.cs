using System.Collections.Generic;

namespace ItIsNotOnlyMe.Inventario
{
    public class InventarioPrueba : Inventario
    {
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
    }
}
