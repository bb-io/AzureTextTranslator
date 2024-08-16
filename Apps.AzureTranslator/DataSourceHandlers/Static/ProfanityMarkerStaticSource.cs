using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.MicrosoftTranslator.DataSourceHandlers.Static;

public class ProfanityMarkerStaticSource : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "Asterisk", "Asterisk" },
            { "Tag", "Tag" }
        };
    }
}