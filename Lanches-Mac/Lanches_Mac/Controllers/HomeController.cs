using Lanches_Mac.Interface;
using Lanches_Mac.Models;
using Lanches_Mac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lanches_Mac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILogger<HomeController> logger, ILancheRepository lancheRepository)
        {
            _logger = logger;
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var lanchesPreferidos = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos()
            };
            return View(lanchesPreferidos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
