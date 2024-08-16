using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.MicrosoftTranslator.DataSourceHandlers.Static;

public class ProfanityActionStaticSource : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "NoAction", "No Action" },
            { "Marked", "Marked" },
            { "Deleted", "Deleted" }
        };
    }
}