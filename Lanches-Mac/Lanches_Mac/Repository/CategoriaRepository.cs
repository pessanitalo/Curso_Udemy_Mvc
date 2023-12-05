using Lanches_Mac.Context;
using Lanches_Mac.Interface;

namespace Lanches_Mac.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }

        public List<Models.Categoria> ObterLista()
        {
            return _context.Categorias.ToList();
        }
    }
}
