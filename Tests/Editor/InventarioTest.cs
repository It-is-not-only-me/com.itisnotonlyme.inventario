using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
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

public class SlotInfinitoPrueba : IEspacio
{
    public List<IElemento> _elementos;

    public SlotInfinitoPrueba()
    {
        _elementos = new List<IElemento>();
    }

    public bool Agregar(IElemento elemento)
    {
        _elementos.Add(elemento);
        return true;
    }

    public bool TieneEspacio()
    {
        return true;
    }

    public bool TieneEspacio(IElemento elemento)
    {
        return true;
    }
}

public class SlotEspecificoPrueba : IEspacio
{
    public IElemento _elementoEspecifico;
    public List<IElemento> _elementos;

    public SlotEspecificoPrueba(IElemento elementoEspecifico)
    {
        _elementoEspecifico = elementoEspecifico;
        _elementos = new List<IElemento>();
    }

    public bool Agregar(IElemento elemento)
    {
        if (!TieneEspacio(elemento))
            return false;
        _elementos.Add(elemento);
        return true;
    }

    public bool TieneEspacio()
    {
        return true;
    }

    public bool TieneEspacio(IElemento elemento)
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
        IInventario inventario = new Inventario();

        Assert.IsFalse(inventario.TieneEspacio());
    }

    [Test]
    public void Test02InventarioSinEspacioNoPuedeAgregarNada()
    {
        IInventario inventario = new Inventario();

        Assert.IsFalse(inventario.Agregar(_elementoPrincipal));
    }

    [Test]
    public void Test03InventarioAgregandoleUnEspacioTieneEspacio()
    {
        IInventario inventario = new Inventario();
        IEspacio slotInfinito = new SlotInfinitoPrueba();

        inventario.AgregarEspacio(slotInfinito);

        Assert.IsTrue(inventario.TieneEspacio());
    }

    [Test]
    public void Test04InventarioConEspacioSeAgregaSePuedeAgregarUnElemento()
    {
        IInventario inventario = new Inventario();
        IEspacio slotInfinito = new SlotInfinitoPrueba();

        inventario.AgregarEspacio(slotInfinito);

        Assert.IsTrue(inventario.Agregar(_elementoPrincipal));
    }
}
