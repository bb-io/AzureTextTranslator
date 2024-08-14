# Blackbird.io Microsoft Translator

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

This application build around the Azure AI Translator API. Azure AI Translator is a cloud-based neural machine translation service that can be used with any operating system. It powers many Microsoft products and services for language translation and other language-related operations. The service uses modern neural machine translation technology and offers statistical machine translation technology.

## Before setting up

Before setting up the connection you must be known with the following:

- In order to get `Document translation endpoint` you can find documentation [here](https://learn.microsoft.com/en-us/azure/ai-services/translator/document-translation/how-to-guides/use-rest-api-programmatically?tabs=csharp#retrieve-your-key-and-custom-domain-endpoint). Note, that Document Translation is supported in the S1 Standard Service Plan (Pay-as-you-go) and C2, C3, C4, and D3 Volume Discount Plans. See [Azure AI services pricing—Translator](https://azure.microsoft.com/en-us/pricing/details/cognitive-services/translator/)
- You can find how to get `API key` [here](https://learn.microsoft.com/en-us/azure/ai-services/translator/document-translation/how-to-guides/use-rest-api-programmatically?tabs=csharp#prerequisites)
- If you are unsure about your region you can try `global` as a default value. You can find more information [here](https://learn.microsoft.com/en-us/azure/ai-services/translator/document-translation/how-to-guides/create-use-managed-identities)

## Connecting

1. Navigate to Apps, and identify the **Microsoft Translator** app. You can use search to find it.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My organization'.
4. Fill all the required fields:
   - `Document translation endpoint` - The endpoint for the document translation service. We expect something like this: https://<NAME-OF-YOUR-RESOURCE>.cognitiveservices.azure.com.
   - `API key` - The API key for the document translation service.
   - `Region` - The region where the document translation service is hosted.
5. Click _Connect_.
6. Confirm that the connection has appeared and the status is _Connected_.

![Connection](image/README/connection.png)

## Actions

- **Translate** - Translates the text to the target language. 
- **Translate document** - Translates the document to the target language, under the hood we are using synchronous translation. The action returns the translated document. You can find supported file formats [here](https://learn.microsoft.com/en-us/azure/ai-services/translator/document-translation/overview#batch-supported-document-formats).
- **Transliterate** - Transliterates the text to the target script.

## Example 

Here is an example of how you can use the Microsoft Translator app in a workflow. In this example, we are translating a document from Google Drive to the target language and then sending the translated document back to a different folder.

![Example](image/README/example.png)

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->