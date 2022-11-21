namespace ItIsNotOnlyMe.Inventario
{
    public class ElementosIguales : IOperacionElementos
    {
        private IElemento _elemento;
        private int _cantidadTotal;

        public ElementosIguales(IElemento elemento)
        {
            _elemento = elemento;
            _cantidadTotal = 0;
        }

        public void Aplicar(IElemento elemento)
        {
            if (_elemento.EsIgual(elemento))
                _cantidadTotal++;
        }

        public int CantidadTotal() => _cantidadTotal;
    }
}
