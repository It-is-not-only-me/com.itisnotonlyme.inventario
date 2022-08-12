namespace ItIsNotOnlyMe.Inventario
{
    public class TieneEspacio : IOperacionEspacios
    {
        private IElemento _elementoAComprobar;
        private bool _tieneEspacio;

        public TieneEspacio(IElemento elementoAComprobar)
        {
            _elementoAComprobar = elementoAComprobar;
            _tieneEspacio = false;
        }

        public void Aplicar(IEspacio espacios) => _tieneEspacio |= espacios.PuedeAgregarElemento(_elementoAComprobar);

        public bool TieneEspacioParaElemento() => _tieneEspacio;
    }
}
