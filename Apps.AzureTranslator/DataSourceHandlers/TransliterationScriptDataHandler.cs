using Apps.AzureTranslator.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AzureTranslator.DataSourceHandlers;

public class TransliterationScriptDataHandler : AzureTextTranslatorInvocable, IAsyncDataSourceHandler
{
    public TransliterationScriptDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var languages = await Client.GetLanguagesAsync(cancellationToken: cancellationToken);
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