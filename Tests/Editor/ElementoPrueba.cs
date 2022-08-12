using ItIsNotOnlyMe.Inventario;

public class ElementoPrueba : IElemento
{
    private int _id;

    public ElementoPrueba(int id)
    {
        _id = id;
    }

    public bool EsIgual(IElemento elemento)
    {
        ElementoPrueba elementoPrueba = elemento as ElementoPrueba;
        return elementoPrueba._id == _id;
    }
}
