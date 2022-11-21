using NUnit.Framework;
using ItIsNotOnlyMe.Inventario;

public class InventarioTest
{
    private IElemento _elementoPrincipal, _elementoDiferente;

    public InventarioTest()
    {
        _elementoPrincipal = new ElementoPrueba(1);
        _elementoDiferente = new ElementoPrueba(2);
    }

    [Test]
    public void Test01InventarioEmpiezaSinEspacio()
    {
        InventarioPrueba inventario = new InventarioPrueba();


        Assert.IsFalse(inventario.TieneEspacio(_elementoPrincipal));
    }

    [Test]
    public void Test02InventarioSinEspacioNoPuedeAgregarNada()
    {
        InventarioPrueba inventario = new InventarioPrueba();

        Assert.IsFalse(inventario.AgregarElemento(_elementoPrincipal));
    }

    [Test]
    public void Test03InventarioAgregandoleUnEspacioTieneEspacio()
    {
        InventarioPrueba inventario = new InventarioPrueba();
        IEspacio slotInfinito = new SlotInfinitoPrueba();

        inventario.AgregarEspacio(slotInfinito);

        Assert.IsTrue(inventario.TieneEspacio(_elementoPrincipal));
    }

    [Test]
    public void Test04InventarioConEspacioSeAgregaSePuedeAgregarUnElemento()
    {
        InventarioPrueba inventario = new InventarioPrueba();
        IEspacio slotInfinito = new SlotInfinitoPrueba();

        inventario.AgregarEspacio(slotInfinito);

        Assert.IsTrue(inventario.AgregarElemento(_elementoPrincipal));
    }

    [Test]
    public void Test05InventarioConEspacioParaElementosEspecificosNoTieneEspacioParaOtrosElementos()
    {
        InventarioPrueba inventario = new InventarioPrueba();
        IEspacio slotEspecifico = new SlotEspecificoPrueba(_elementoPrincipal);

        inventario.AgregarEspacio(slotEspecifico);

        Assert.IsFalse(inventario.TieneEspacio(_elementoDiferente));
    }

    [Test]
    public void Test06InventarioSeAgreganTresElementosYSeDevuelvenLaMismaCantidad()
    {
        InventarioPrueba inventario = new InventarioPrueba();
        IEspacio slotEspecificoPrincipal = new SlotEspecificoPrueba(_elementoPrincipal);
        IEspacio slotEspecificoDiferente = new SlotEspecificoPrueba(_elementoDiferente);

        inventario.AgregarEspacio(slotEspecificoPrincipal);
        inventario.AgregarEspacio(slotEspecificoDiferente);

        Assert.IsTrue(inventario.AgregarElemento(_elementoPrincipal));
        Assert.IsTrue(inventario.AgregarElemento(_elementoDiferente));
        Assert.IsTrue(inventario.AgregarElemento(_elementoDiferente));

        int cantidadElementosPrincipales = inventario.CantidadElementos(_elementoPrincipal);
        int cantidadElementosDiferentes = inventario.CantidadElementos(_elementoDiferente);
        int cantidadElementosTotales = inventario.CantidadElementosTotales();

        Assert.AreEqual(1, cantidadElementosPrincipales);
        Assert.AreEqual(2, cantidadElementosDiferentes);
        Assert.AreEqual(3, cantidadElementosTotales);
    }

    [Test]
    public void Test07InventarioNoSePuedeEliminarElementoQueNoTiene()
    {
        InventarioPrueba inventario = new InventarioPrueba();
        IEspacio slotEspecificoDiferente = new SlotEspecificoPrueba(_elementoDiferente);

        inventario.AgregarEspacio(slotEspecificoDiferente);

        Assert.IsTrue(inventario.AgregarElemento(_elementoDiferente));
        Assert.IsTrue(inventario.AgregarElemento(_elementoDiferente));

        Assert.IsFalse(inventario.SacarElemento(_elementoPrincipal));
    }

    [Test]
    public void Test08InventarioDisminuyeLaCantidadConLaCantidadDeElementosDespuesDeEliminarUnElemento()
    {
        InventarioPrueba inventario = new InventarioPrueba();
        IEspacio slotEspecificoPrincipal = new SlotEspecificoPrueba(_elementoPrincipal);
        IEspacio slotEspecificoDiferente = new SlotEspecificoPrueba(_elementoDiferente);

        inventario.AgregarEspacio(slotEspecificoPrincipal);
        inventario.AgregarEspacio(slotEspecificoDiferente);

        Assert.IsTrue(inventario.AgregarElemento(_elementoPrincipal));
        Assert.IsTrue(inventario.AgregarElemento(_elementoDiferente));
        Assert.IsTrue(inventario.AgregarElemento(_elementoDiferente));

        Assert.IsTrue(inventario.SacarElemento(_elementoPrincipal));

        int cantidadElementosTotales = inventario.CantidadElementosTotales();

        Assert.AreEqual(2, cantidadElementosTotales);
    }
}
