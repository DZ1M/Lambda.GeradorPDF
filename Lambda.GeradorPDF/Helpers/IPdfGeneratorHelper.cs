using WkHtmlToPdfDotNet;

namespace Lambda.GeradorPDF.Helpers
{
    public interface IPdfGeneratorHelper
    {
        byte[] Generate(string html, Orientation orientacao);
    }
}
