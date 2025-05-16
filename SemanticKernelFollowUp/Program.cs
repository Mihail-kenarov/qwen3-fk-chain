using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using OllamaSharp;
using SemanticKernelFollowUp;

#pragma warning disable SKEXP0070

// kernel builder
var builder = Kernel.CreateBuilder();
string OllamaModel = "qwen3:latest";
Uri OllamaUrl = new("http://localhost:11434");


var ollamaChatClient = new OllamaApiClient(OllamaUrl, OllamaModel);
builder.AddOllamaChatCompletion(ollamaChatClient);

//Plugins
builder.Plugins.AddFromType<NewsPlugin>();
builder.Plugins.AddFromType<ArchivePlugin>();

//kernel 
var kernel = builder.Build();

//chatService
var chatService = kernel.GetRequiredService<IChatCompletionService>();

ChatHistory chatMessages = new ChatHistory("You are an AI assistant which is hepling the users by providing them" +
    "with knowledge, that is received from function" +
    "If a function requires a specific parameter, you ask for it");

while (true)
{
    Console.Write("User: ");
    chatMessages.AddUserMessage(Console.ReadLine());

    var completion = chatService.GetStreamingChatMessageContentsAsync(
        chatMessages,
        executionSettings: new OllamaPromptExecutionSettings
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
        },
        kernel: kernel);

    string fullmessage = string.Empty;
    await foreach (var message in completion)
    {
        fullmessage += message;
        Console.Write(message);
        Console.WriteLine("---");
    }

    chatMessages.AddAssistantMessage(fullmessage);
    Console.WriteLine();   
}
