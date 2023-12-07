using Lanches_Mac.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
           
        }

        public IViewComponentResult Invoke()
        {
            var categoria = _categoriaRepository.ObterLista().OrderBy(x => x.Nome);
            return View(categoria);
        }
    }
}
