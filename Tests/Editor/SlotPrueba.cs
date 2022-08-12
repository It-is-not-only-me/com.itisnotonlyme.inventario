using System.Collections.Generic;
using ItIsNotOnlyMe.Inventario;

public abstract class SlotPrueba : IEspacio
{
    protected List<IElemento> _elementos;

    public SlotPrueba()
    {
        _elementos = new List<IElemento>();
    }

    public bool AgregarElemento(IElemento elemento)
    {
        if (!PuedeAgregarElemento(elemento))
            return false;

        _elementos.Add(elemento);
        return true;
    }

    public void AplicarOperacion(IOperacionElementos operacion)
    {
        foreach (IElemento elemento in _elementos)
            operacion.Aplicar(elemento);
    }

    public void AplicarOperacion(IOperacionEspacios operacion) => operacion.Aplicar(this);

    public bool SacarElemento(IElemento elemento) => _elementos.Remove(elemento);

    public abstract bool PuedeAgregarElemento(IElemento elemento);
}
