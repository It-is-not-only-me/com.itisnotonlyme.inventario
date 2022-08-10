using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItIsNotOnlyMe.Inventario;

public class ElementoPrueba : IElemento
{

}

public class InventarioTest
{
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
        IElemento elemento = new ElementoPrueba();

        Assert.IsFalse(inventario.Agregar(elemento));
    }

    [Test]
    public void Test03()
    {

    }
}
