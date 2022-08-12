using System.Collections.Generic;
using NUnit.Framework;
using ItIsNotOnlyMe.Inventario;
using UnityEngine;

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

    public void AplicarOperacion(IOperacionEspacios operacion)
    {
        operacion.Aplicar(this);
    }

    public abstract bool PuedeAgregarElemento(IElemento elemento);
}

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
        Inventario inventario = new Inventario();


        Assert.IsFalse(inventario.TieneEspacio(_elementoPrincipal));
    }

    [Test]
    public void Test02InventarioSinEspacioNoPuedeAgregarNada()
    {
        Inventario inventario = new Inventario();

        Assert.IsFalse(inventario.AgregarElemento(_elementoPrincipal));
    }

    [Test]
    public void Test03InventarioAgregandoleUnEspacioTieneEspacio()
    {
        Inventario inventario = new Inventario();
        IEspacio slotInfinito = new SlotInfinitoPrueba();

        inventario.AgregarEspacio(slotInfinito);

        Assert.IsTrue(inventario.TieneEspacio(_elementoPrincipal));
    }

    [Test]
    public void Test04InventarioConEspacioSeAgregaSePuedeAgregarUnElemento()
    {
        Inventario inventario = new Inventario();
        IEspacio slotInfinito = new SlotInfinitoPrueba();

        inventario.AgregarEspacio(slotInfinito);

        Assert.IsTrue(inventario.AgregarElemento(_elementoPrincipal));
    }

    [Test]
    public void Test05InventarioConEspacioParaElementosEspecificosNoTieneEspacioParaOtrosElementos()
    {
        Inventario inventario = new Inventario();
        IEspacio slotEspecifico = new SlotEspecificoPrueba(_elementoPrincipal);

        inventario.AgregarEspacio(slotEspecifico);

        Assert.IsFalse(inventario.TieneEspacio(_elementoDiferente));
    }

    [Test]
    public void Test06InventarioSeAgreganTresElementosYSeDevuelvenLaMismaCantidad()
    {
        Inventario inventario = new Inventario();
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
}
