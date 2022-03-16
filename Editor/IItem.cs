namespace ItIsNotOnlyMe.Inventario
{
    public interface IItem
    {
        public bool EsIgual(IItem item);

        public bool EsIgual(int id);
    }
}
