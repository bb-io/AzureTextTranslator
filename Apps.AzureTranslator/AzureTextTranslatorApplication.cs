using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.MicrosoftTranslator;

public class AzureTextTranslatorApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.MachineTranslationAndMtqe, ApplicationCategory.AzureApps];
        set { }
    }
    
    public string Name
    {
        get => "Azure AI Translator";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}