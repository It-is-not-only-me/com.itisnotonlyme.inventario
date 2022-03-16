using NUnit.Framework;
using ItIsNotOnlyMe.Inventario;

public class InventarioTest
{
    private class ItemPrueba : IItem
    {
        private static int _contador = 0;
        private int _id;

        public ItemPrueba()
        {
            _id = _contador;
            _contador++;
        }

        public bool EsIgual(IItem item)
        {
            return item.EsIgual(_id);
        }

        public bool EsIgual(int id)
        {
            return _id == id;
        }
    }

    private ItemPrueba _item1, _item2, _item3, _item4, _item5;

    public InventarioTest()
    {
        _item1 = new ItemPrueba();
        _item2 = new ItemPrueba();
        _item3 = new ItemPrueba();
        _item4 = new ItemPrueba();
        _item5 = new ItemPrueba();
    }

    [Test]
    public void Test01UnInventarioSinItemsTieneUnaCantidadDeCero()
    {
        IInventario inventario = new Inventario();

        Assert.AreEqual(0, inventario.Cantidad());
    }

    [Test]
    public void Test02UnInventarioConUnItemAgregadoTieneCantidadUno()
    {
        IInventario inventario = new Inventario();
        bool pudoAgregarlo = inventario.Agregar(_item1);

        Assert.IsTrue(pudoAgregarlo);

        Assert.AreEqual(1, inventario.Cantidad());
    }

    [Test]
    public void Test03UnInventarioConDosItemsDiferentesTieneCantidadDos()
    {
        IInventario inventario = new Inventario();
        bool pudoAgregarlo = inventario.Agregar(_item1);
        Assert.IsTrue(pudoAgregarlo);

        pudoAgregarlo = inventario.Agregar(_item2);
        Assert.IsTrue(pudoAgregarlo);

        Assert.AreEqual(2, inventario.Cantidad());
    }

    [Test]
    public void Test04UnInventarioConDosItemsIgualesTieneCantidadDos()
    {
        IInventario inventario = new Inventario();
        bool pudoAgregarlo = inventario.Agregar(_item1);
        Assert.IsTrue(pudoAgregarlo);

        pudoAgregarlo = inventario.Agregar(_item1);
        Assert.IsTrue(pudoAgregarlo);

        Assert.AreEqual(2, inventario.Cantidad());
    }

    [Test]
    public void Test05UnInventarioConDosItemsYDespuesSacarUnoTieneCantidadUno()
    {
        IInventario inventario = new Inventario();
        bool pudoAgregarlo = inventario.Agregar(_item1);
        Assert.IsTrue(pudoAgregarlo);

        pudoAgregarlo = inventario.Agregar(_item1);
        Assert.IsTrue(pudoAgregarlo);

        bool pudoSacarlo = inventario.Sacar(_item1);
        Assert.IsTrue(pudoSacarlo);

        Assert.AreEqual(1, inventario.Cantidad());
    }

    [Test]
    public void Test06UnInventarioConDosItemsSeSacaUnoYSeDevuelveElCorrecto()
    {
        IInventario inventario = new Inventario();
        bool pudoAgregarlo = inventario.Agregar(_item1);
        Assert.IsTrue(pudoAgregarlo);

        pudoAgregarlo = inventario.Agregar(_item2);
        Assert.IsTrue(pudoAgregarlo);

        bool pudoSacarlo = inventario.Sacar(_item1);
        Assert.IsTrue(pudoSacarlo);

        foreach (Stack stack in inventario)
        {
            Assert.IsTrue(stack.EsIgual(_item2));
        }
    }
}
