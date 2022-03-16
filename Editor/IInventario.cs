using System.Collections;

namespace ItIsNotOnlyMe.Inventario
{
    public interface IInventario : IEnumerable
    {
        public bool Agregar(IItem item);

        public bool Sacar(IItem item);

        public int Cantidad();
    }
}
