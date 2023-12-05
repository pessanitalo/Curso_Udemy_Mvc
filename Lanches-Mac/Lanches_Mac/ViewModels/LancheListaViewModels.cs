using Lanches_Mac.Models;

namespace Lanches_Mac.ViewModels
{
    public class LancheListaViewModels
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
