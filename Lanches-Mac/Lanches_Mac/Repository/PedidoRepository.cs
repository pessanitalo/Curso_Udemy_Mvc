using Lanches_Mac.Context;
using Lanches_Mac.Interface;
using Lanches_Mac.Models;

namespace Lanches_Mac.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext _context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(DataContext context, CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItems;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.Id,
                    PedidoId = pedido.Id,
                    Preco = carrinhoItem.Lanche.Preco
                };

                _context.PedidoDetalhes.Add(pedidoDetalhe);
            }
            _context.SaveChanges();
        }
    }
}
