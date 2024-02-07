using Lanches_Mac.Context;
using Lanches_Mac.Interface;
using Lanches_Mac.Models;
using Lanches_Mac.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;
        private readonly DataContext _context;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra, DataContext context)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
            _context = context;
        }

        public IActionResult Index()
        {
            var pedidos = _context.Pedidos.ToList();
            return View(pedidos);
        }

        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            List<CarrinhoItem> items = _carrinhoCompra.GetCarrinhoCompraItens();

            _carrinhoCompra.CarrinhoCompraItems = items;


            if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio!");
            }

            foreach (var item in items)
            {
                totalItensPedido = item.Quantidade;
                precoTotalPedido = item.Lanche.Preco * item.Quantidade;
            }

            pedido.TotalItensPedido = totalItensPedido;
            pedido.TotalPedido = precoTotalPedido;

            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);
                ViewBag.CheckOutCompletoMensagem = "Obrigado pelo seu pedido!";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                _carrinhoCompra.LimparCarrinho();

                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);

        }

        public IActionResult PedidoLanches(int? id)
        {
            var pedido = _context.Pedidos.Include(c => c.PedidoItens)
                .ThenInclude(c => c.Lanche).FirstOrDefault(c => c.Id == id);

            if (pedido == null)
            {
                Response.StatusCode = 404;
                return View("PedidoNotFoud", id.Value);
            }

            PedidoLancheViewModel pedidoLanches = new PedidoLancheViewModel()
            {
                Pedido = pedido,
                PedidosDetalhes = pedido.PedidoItens
            };

            return View(pedidoLanches);
        }
    }
}
