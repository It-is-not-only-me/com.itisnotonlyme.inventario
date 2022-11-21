namespace ItIsNotOnlyMe.Inventario
{
    public class SacarElemento : IOperacionEspacios
    {
        private IElemento _elemento;
        private bool _seElimino;

        public SacarElemento(IElemento elemento)
        {
            _elemento = elemento;
            _seElimino = false;
        }

        public void Aplicar(IEspacio espacios) => Aplicar(espacios as ISlotPrueba);

        public void Aplicar(ISlotPrueba espacios)
        {
            if (_seElimino)
                return;

            _seElimino = espacios.SacarElemento(_elemento);
        }

        public bool SePudoEliminar() => _seElimino;
    }
}
