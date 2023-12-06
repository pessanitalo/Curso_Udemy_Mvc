using Lanches_Mac.Context;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac.Models
{
    public class CarrinhoCompra
    {
        private readonly DataContext _context;

        public CarrinhoCompra(DataContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<DataContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarCarrinho(Lanche lanche)
        {
            var itemCarrinho = _context.CarrinhoItens.SingleOrDefault(c => c.Lanche.Id == lanche.Id
                                && c.CarrinhoId == CarrinhoCompraId);

            if (itemCarrinho == null)
            {
                itemCarrinho = new CarrinhoItem
                {
                    CarrinhoId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _context.CarrinhoItens.Add(itemCarrinho);
            }
            else
            {
                itemCarrinho.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverItem(Lanche lanche)
        {
            var itemCarrinho = _context.CarrinhoItens.SingleOrDefault(c => c.Lanche.Id == lanche.Id
                                && c.CarrinhoId == CarrinhoCompraId);
            var quantidadeLocal = 0;

            if (itemCarrinho != null)
            {
                if (itemCarrinho.Quantidade > 1)
                {
                    itemCarrinho.Quantidade--;
                    quantidadeLocal = itemCarrinho.Quantidade;
                }
                else
                {
                    _context.CarrinhoItens.Remove(itemCarrinho);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoItens.Where
                (c => c.CarrinhoId == CarrinhoCompraId).Include(s => s.Lanche).ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoItens
                    .Where(c => c.CarrinhoId == CarrinhoCompraId);
            _context.CarrinhoItens.RemoveRange(carrinhoItens);
            _context.SaveChanges(true);
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoItens.Where(c => c.CarrinhoId == CarrinhoCompraId)
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
