using Lanches_Mac.Interface;
using Lanches_Mac.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Checout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checout(Pedido Pedido)
        {
            return View();
        }
    }
}
