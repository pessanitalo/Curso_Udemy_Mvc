using Lanches_Mac.Models;

namespace Lanches_Mac.Interface
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> ObterLanches();
        IEnumerable<Lanche> LanchesPreferidos();
        Lanche ObterLanchePorId(int id);

    }
}
