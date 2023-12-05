using Lanches_Mac.Interface;
using Lanches_Mac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _repository;

        public LancheController(ILancheRepository context)
        {
            _repository = context;
        }

        public IActionResult List()
        {
            //var lanches = _repository.ObterLanches();
            var lanchesListaViewModel = new LancheListaViewModels();
            lanchesListaViewModel.Lanches = _repository.ObterLanches();
            lanchesListaViewModel.CategoriaAtual = "Fit";
            return View(lanchesListaViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
