using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.MicrosoftTranslator.Utils;

public static class FileReferenceExtensions
{
    public static string GetFileExtension(this FileReference fileReference)
    {
        return fileReference.Name.Substring(fileReference.Name.LastIndexOf('.'));
    }
}