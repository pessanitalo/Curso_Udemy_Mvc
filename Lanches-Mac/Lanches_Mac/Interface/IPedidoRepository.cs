using Lanches_Mac.Models;

namespace Lanches_Mac.Interface
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}
