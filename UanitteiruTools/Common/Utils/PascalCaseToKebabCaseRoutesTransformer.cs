using System.Text.RegularExpressions;

namespace UanitteiruTools.Common.Utils;

public partial class PascalCaseToKebabCaseRoutesTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object? value)
    {
        // Slugify value
        return SlugifyRegex().Replace(value?.ToString() ?? "", "$1-$2").ToLower();
    }

    [GeneratedRegex("([a-z])([A-Z])")]
    private static partial Regex SlugifyRegex();
}