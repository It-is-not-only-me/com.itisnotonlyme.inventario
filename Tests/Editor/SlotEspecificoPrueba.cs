using ItIsNotOnlyMe.Inventario;

public class SlotEspecificoPrueba : SlotPrueba
{
    public IElemento _elementoEspecifico;

    public SlotEspecificoPrueba(IElemento elementoEspecifico)
    {
        _elementoEspecifico = elementoEspecifico;
    }

    public override bool PuedeAgregarElemento(IElemento elemento)
    {
        return _elementoEspecifico.EsIgual(elemento);
    }
}
