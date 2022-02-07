using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TrainingPortal.WebPL.Helpers
{
    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.ActionDescriptor.ActionName;
            }

            controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !partial);

                if (!viewResult.Success)
                {
                    return $"A view with the name {viewName} could not be found";
                }

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }

        public static async Task<string> GeneratePDF(this Controller controller, string viewHtml)
        {
            string puppeteerSharpDir = Path.Combine(Environment.CurrentDirectory, "bin/PuppeteerSharp");
            string browserDir = Path.Combine(puppeteerSharpDir, ".local-chromium");
            string userDataDir = Path.Combine(puppeteerSharpDir, "UserData");
            var browserFetcher = new BrowserFetcher(new BrowserFetcherOptions() { Path = browserDir });
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = browserFetcher.GetExecutablePath(BrowserFetcher.DefaultChromiumRevision),
                UserDataDir = userDataDir,
                Timeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds
            });
            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(viewHtml);
            string fileName = $"{Guid.NewGuid()}.pdf";
            string filePath = Path.Combine(userDataDir, fileName);
            PdfOptions pdfOptions = new PdfOptions() { Format = PaperFormat.A4 };
            await page.PdfAsync(filePath, pdfOptions);
            await browser.CloseAsync();

            return filePath;
        }
    }
}