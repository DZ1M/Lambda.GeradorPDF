using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;
namespace Lambda.GeradorPDF.Helpers
{
    public class PdfGeneratorHelper : IPdfGeneratorHelper
    {
        private readonly IConverter converter;

        public PdfGeneratorHelper(IConverter converter)
        {
            this.converter = converter;
        }

        //private readonly IPdfConverter _pdfConverter = new SynchronizedConverter(new PdfTools());
        public byte[] Generate(string html, Orientation orientacao)
        {
            //const double margin = 25;
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = orientacao,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 }, //new MarginSettings(margin, margin, margin, margin),
                DocumentTitle = String.Format("Relatorio_{0}.pdf", Guid.NewGuid())
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = new WebSettings
                {
                    PrintMediaType = true,
                    EnableIntelligentShrinking = true
                },
                HeaderSettings = { FontName = "Roboto", FontSize = 6, Right = "Página [page] de [toPage]", Line = false, Spacing = 4 },
            };

            return this.converter.Convert(new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            });
        }
    }
}
