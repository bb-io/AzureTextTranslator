using Apps.MicrosoftTranslator.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.MicrosoftTranslator.DataSourceHandlers;

public class TransliterationLanguageDataHandler(InvocationContext invocationContext)
    : AzureTextTranslatorInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var languages = await Client.GetSupportedLanguagesAsync(cancellationToken: cancellationToken);

        return languages.Value.Transliteration
            .Where(x => context.SearchString is null ||
                        x.Value.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Key, x => x.Value.Name);
    }
}