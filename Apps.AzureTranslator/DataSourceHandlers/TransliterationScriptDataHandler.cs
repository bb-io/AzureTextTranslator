using Apps.MicrosoftTranslator.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.MicrosoftTranslator.DataSourceHandlers;

public class TransliterationScriptDataHandler(InvocationContext invocationContext)
    : AzureTextTranslatorInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var languages = await Client.GetSupportedLanguagesAsync(cancellationToken: cancellationToken);
        var scripts = languages.Value.Transliteration
            .SelectMany(x => x.Value.Scripts)
            .DistinctBy(x => x.Code)
            .ToArray();

        return scripts
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Code, x => x.Name);
    }
}