using System.Collections.Generic;

namespace ItIsNotOnlyMe.Inventario
{
    public class ObtenerElementos : IOperacionElementos
    {
        private List<IElemento> _elementos;

        public ObtenerElementos()
        {
            _elementos = new List<IElemento>();
        }

        public void Aplicar(IElemento elemento) => _elementos.Add(elemento);

        public List<IElemento> ElementosObtenidos() => _elementos;
    }
}
