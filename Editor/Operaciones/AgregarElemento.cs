namespace ItIsNotOnlyMe.Inventario
{
    public class AgregarElemento : IOperacionEspacios
    {
        private IElemento _elemento;
        private bool _agregado;

        public AgregarElemento(IElemento elemento)
        {
            _elemento = elemento;
            _agregado = false;
        }

        public void Aplicar(IEspacio espacios)
        {
            if (_agregado || !espacios.PuedeAgregarElemento(_elemento))
                return;

            espacios.AgregarElemento(_elemento);
            _agregado = true;
        }

        public bool SePudoAgregar() => _agregado;
    }
}
