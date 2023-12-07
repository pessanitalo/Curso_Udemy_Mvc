using Lanches_Mac.Context;
using Lanches_Mac.Interface;
using Lanches_Mac.Models;

namespace Lanches_Mac.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
        public List<Models.Categoria> ObterLista()
        {
            return _context.Categorias.ToList();
        }
    }
}
