using Lanches_Mac.Models;
using Lanches_Mac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            //var itens = new List<CarrinhoItem>()
            //{
            //    new CarrinhoItem(),
            //    new CarrinhoItem()
            //};

            //_carrinhoCompra.CarrinhoCompraItems = itens ;
            _carrinhoCompra.CarrinhoCompraItems.AddRange(itens);

            var carrinhoCompra = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
            };
            return View(carrinhoCompra);
        }
    }
}
