namespace ItIsNotOnlyMe.Inventario
{
    public class CantidadElementosTotales : IOperacionElementos
    {
        private int _cantidadTotal;

        public CantidadElementosTotales()
        {
            _cantidadTotal = 0;
        }

        public void Aplicar(IElemento elemento) => _cantidadTotal++;

        public int CantidadTotal() => _cantidadTotal;
    }
}
