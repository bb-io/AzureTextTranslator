using Apps.MicrosoftTranslator.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.MicrosoftTranslator.DataSourceHandlers;

public class TranslationLanguageDataHandler : AzureTextTranslatorInvocable, IAsyncDataSourceHandler
{
    public TranslationLanguageDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var languages = await Client.GetLanguagesAsync(cancellationToken: cancellationToken);

        return languages.Value.Translation
            .Where(x => context.SearchString is null ||
                        x.Value.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Key, x => x.Value.Name);
    }
}