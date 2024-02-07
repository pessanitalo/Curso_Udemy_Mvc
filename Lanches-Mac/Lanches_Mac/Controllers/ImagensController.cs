using Lanches_Mac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;

namespace Lanches_Mac.Controllers
{
    public class ImagensController : Controller
    {
        private readonly ConfigurationsImagens _config;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImagensController(IOptions<ConfigurationsImagens> config, IWebHostEnvironment hostEnvironment)
        {
            _config = config.Value;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    ViewData["Erro"] = "Error Arquivos não selecionado(s)";
                    return View();
                }

                if (files.Count > 10)
                {
                    ViewData["Erro"] = "Error Quantidade de arquivos excedeu o limite";
                    return View();
                }

                long size = files.Sum(f => f.Length);

                var filePathsName = new List<string>();

                var filePath = Path.Combine(_hostEnvironment.WebRootPath, _config.NomePastaImagensProdutos);


                foreach (var formFile in files)
                {
                    if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif") ||
                             formFile.FileName.Contains(".png"))
                    {
                        var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                        filePathsName.Add(fileNameWithPath);

                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }

                ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " + $" com tamanho total de: {size} bytes.";

                ViewBag.Arquivos = filePathsName;
                return View(ViewData);
            }
            catch (Exception ex)
            {
                ViewData["Erro"] = $"Erro : {ex.Message}";
                return View(ViewData);
            }


        }

        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_hostEnvironment.WebRootPath,
                    _config.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }

            model.Files = files;
            return View(model);
        }
    }
}
