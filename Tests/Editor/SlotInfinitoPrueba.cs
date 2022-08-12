using ItIsNotOnlyMe.Inventario;

public class SlotInfinitoPrueba : SlotPrueba
{
    public SlotInfinitoPrueba()
    {
    }

    public override bool PuedeAgregarElemento(IElemento elemento)
    {
        return true;
    }
}
