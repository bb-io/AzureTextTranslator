using Apps.MicrosoftTranslator.Model.Dtos;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.MicrosoftTranslator.Utils;

public static class RestResponseExtensions
{
    public static Exception GetException(this RestResponse response)
    {
        try
        {
            var error = JsonConvert.DeserializeObject<ErrorDto>(response.Content!)!;
            return new Exception(error.ToString());
        }
        catch (Exception)
        {
            return new Exception(response.Content);
        }
    }
}