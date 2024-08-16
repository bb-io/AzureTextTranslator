using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.MicrosoftTranslator.DataSourceHandlers.Static;

public class TextTypeStaticSource : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "Plain", "Plain" },
            { "Html", "Html" }
        };
    }
}