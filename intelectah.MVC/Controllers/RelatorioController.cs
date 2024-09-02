using DinkToPdf;
using DinkToPdf.Contracts;
using intelectah.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ColorMode = DinkToPdf.ColorMode;

namespace intelectah.MVC.Controllers
{
    [Authorize(Roles = "Gerente")]
    public class RelatorioController : Controller
    {
        private readonly IRelatorioService _relatorioService;
        private readonly IConverter _converter;
        private readonly ICompositeViewEngine _viewEngine;

        public RelatorioController(IRelatorioService relatorioService, IConverter converter, ICompositeViewEngine viewEngine)
        {
            _relatorioService = relatorioService;
            _converter = converter;
            _viewEngine = viewEngine;
        }

        public async Task<IActionResult> Relatorios()
        {
            var vendasMensais = await _relatorioService.GetVendasMensaisAsync();
            ViewBag.VendasMensais = vendasMensais;
            return View();
        }

        public async Task<IActionResult> ExportVendasMensaisPdf()
        {
            var vendasMensais = await _relatorioService.GetVendasMensaisAsync();

            var groupedData = vendasMensais
                .GroupBy(v => v.Concessionaria)
                .Select(g => new
                {
                    Concessionaria = g.Key,
                    TotalVendas = g.Sum(v => v.TotalVendas),
                    Meses = g.Select(v => v.Mes).ToList()
                })
                .ToList();

            var htmlContent = await RenderViewToStringAsync("_VendasMensaisPdf", groupedData);

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            var file = _converter.Convert(pdf);

            return File(file, "application/pdf", "RelatorioVendasMensais.pdf");
        }

        private async Task<string> RenderViewToStringAsync(string viewName, object model)
        {
            ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                var viewResult = _viewEngine.FindView(ControllerContext, viewName, false);
                if (viewResult.View == null)
                    throw new ArgumentNullException($"{viewName} nenhum item disponivel");

                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );
                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
