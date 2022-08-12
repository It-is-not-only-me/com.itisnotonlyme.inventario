namespace ItIsNotOnlyMe.Inventario
{
    public interface IEspacio
    {
        public bool AgregarElemento(IElemento elemento);

        public bool SacarElemento(IElemento elemento);

        public bool PuedeAgregarElemento(IElemento elemento);

        public void AplicarOperacion(IOperacionElementos operacion);

        public void AplicarOperacion(IOperacionEspacios operacion);
    }
}
