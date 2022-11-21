namespace ItIsNotOnlyMe.Inventario
{
    public interface IEspacio
    {
        public void AplicarOperacion(IOperacionElementos operacion);

        public void AplicarOperacion(IOperacionEspacios operacion);
    }
}
