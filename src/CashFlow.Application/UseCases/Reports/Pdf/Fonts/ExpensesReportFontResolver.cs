using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Reports.Pdf.Fonts;
public class ExpensesReportFontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        var stream = ReadFontFile(faceName);

        stream ??= ReadFontFile(FontHelper.DEFAULT_FONT); // ??= substitui o if null

        var length = (int)stream!.Length; // ! indica que é certeza que stream é não null

        var data = new byte[length]; // Sempre que criarmos um array de algo caso já soubermos sua extensão de antemão é interessante já passar por performance

        stream.Read(buffer: data, offset: 0, count: length);

        return data;
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        return new FontResolverInfo(familyName);
    }

    private Stream? ReadFontFile(string faceName)
    {
        var assembly = Assembly.GetExecutingAssembly(); // Pede a plataforma do .net a referencia do projeto que está sendo executado agora (application no caso).

        return assembly.GetManifestResourceStream($"CashFlow.Application.UseCases.Reports.Pdf.Fonts.{faceName}.ttf");
    }
}
