using ItIsNotOnlyMe.Inventario;

public interface ISlotPrueba : IEspacio
{
    public bool AgregarElemento(IElemento elemento);

    public bool SacarElemento(IElemento elemento);

    public bool PuedeAgregarElemento(IElemento elemento);
}
