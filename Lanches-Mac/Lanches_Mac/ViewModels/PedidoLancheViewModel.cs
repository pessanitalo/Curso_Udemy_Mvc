using Lanches_Mac.Models;

namespace Lanches_Mac.ViewModels
{
    public class PedidoLancheViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidosDetalhes { get; set; }
    }
}
