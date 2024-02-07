using Lanches_Mac.Interface;
using Lanches_Mac.Models;
using Lanches_Mac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace Lanches_Mac.Controllers
{

    public class LancheController : Controller
    {
        private readonly ILancheRepository _repository;

        public LancheController(ILancheRepository context)
        {
            _repository = context;
        }


        public IActionResult Index(string filter, int pageindex = 1, string sort = "Nome")
        {

            IEnumerable<Lanche> lanches;

            lanches = _repository.ObterLanches();

            if (!string.IsNullOrEmpty(filter))
            {
                lanches = lanches.Where(p => p.Nome.Contains(filter));
            }

            var model = PagingList.Create(lanches, 5, pageindex);

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var lanche = _repository.ObterLanchePorId(id);
            return View(lanche);
        }

        public IActionResult Search(string busca)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(busca))
            {
                lanches = _repository.ObterLanches();
                categoriaAtual = "Todos os Lanches";
            }

            else
            {

                lanches = _repository.ObterLanches().Where(c => c.Nome.ToLower().Contains(busca.ToLower()));

                if (lanches.Any())
                {
                    categoriaAtual = "Lanches";
                }

                else
                {
                    categoriaAtual = "Nenhum Lanche foi encontrado";
                }

            }

            return View("~/Views/Lanche/List.cshtml", new LancheListaViewModels
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
