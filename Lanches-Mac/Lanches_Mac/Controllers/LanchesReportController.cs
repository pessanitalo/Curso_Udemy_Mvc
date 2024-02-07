using FastReport.Web;
using FastReport.Data;
using Lanches_Mac.Services;
using Microsoft.AspNetCore.Mvc;
using LanchesMac.Areas.Admin.FastReportUtils;
using FastReport.Export.PdfSimple;

namespace Lanches_Mac.Controllers
{
    public class LanchesReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        

        public LanchesReportController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;           
        }

        //public async Task<ActionResult> LanchesCategoriaReport ()
        //{
        //    var webREport = new WebReport();
        //    var mssqlDataConnection = new MsSqlDataConnection();

        //    webREport.Report.Dictionary.AddChild(mssqlDataConnection);
        //    webREport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/report", "Lanches.frx"));

        //    var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLancheReport(),"LanchesReport");
        //    var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriaReport(), "CategoriasReport");

        //    webREport.Report.RegisterData(lanches, "LanchesReport");
        //    webREport.Report.RegisterData(categorias, "CategoriasReport");

        //    return View(webREport);
        //}

        //[Route("LanchesCategoriaPDF")]
        //public async Task<ActionResult> LanchesCategoriaPdf()
        //{
        //    var webReport = new WebReport();
        //    var mssqlDataConnection = new MsSqlDataConnection();

        //    webReport.Report.Dictionary.AddChild(mssqlDataConnection);

        //    webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/report",
        //                                       "Lanches.frx"));

        //    var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLancheReport(), "LanchesReport");
        //    var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriaReport(), "CategoriasReport");

        //    webReport.Report.RegisterData(lanches, "LanchesReport");
        //    webReport.Report.RegisterData(categorias, "CategoriasReport");

        //    webReport.Report.Prepare();

        //    Stream stream = new MemoryStream();

        //    webReport.Report.Export(new PDFSimpleExport(), stream);
        //    stream.Position = 0;

        //    //return File(stream, "application/zip", "LancheCategoria.pdf");
        //    return new FileStreamResult(stream, "application/pdf");
        //}
    }
}
