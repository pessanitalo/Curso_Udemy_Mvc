using Lanches_Mac.Context;
using Lanches_Mac.Interface;
using Lanches_Mac.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac.Repository
{
    public class LancheRepository : ILancheRepository
    {
        private readonly DataContext _context;

        public LancheRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> LanchesPreferidos()
        {
            return _context.Lanches.Where(l => l.IsLanchePreferido).Include(c => c.Categoria);
        }

        public Lanche ObterLanchePorId(int id)
        {
            return _context.Lanches.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Lanche> ObterLanches()
        {
            return _context.Lanches.Include(c => c.Categoria);
        }
    }
}
