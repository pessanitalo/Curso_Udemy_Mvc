using Lanches_Mac.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac.Controllers
{
    public class GraficoController : Controller
    {
        private readonly GraficosVendasService _graficosVendasService;

        public GraficoController(GraficosVendasService graficosVendasService)
        {
            _graficosVendasService = graficosVendasService;
        }

        [HttpGet]
        public JsonResult VendasLanches(int dias)
        {
            var lanchesvendasTotais = _graficosVendasService.GetVendasLanches(dias);
            return Json(lanchesvendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }

    }
}
