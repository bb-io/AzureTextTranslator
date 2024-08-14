using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.MicrosoftTranslator.Model.Response;

public class TranslateDocumentResponse
{
    [Display("Translated file")]
    public FileReference File { get; set; } = new();
}