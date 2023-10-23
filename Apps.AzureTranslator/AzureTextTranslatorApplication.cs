using Blackbird.Applications.Sdk.Common;

namespace Apps.AzureTranslator;

public class AzureTextTranslatorApplication : IApplication
{
    public string Name
    {
        get => "Azure Text Translator";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}