using AGUIDojoServer;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Hosting.AGUI.AspNetCore;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
        HttpLoggingFields.RequestBody |
        HttpLoggingFields.ResponsePropertiesAndHeaders |
        HttpLoggingFields.ResponseBody;
    logging.RequestBodyLogLimit = int.MaxValue;
    logging.ResponseBodyLogLimit = int.MaxValue;
});

builder.Services.AddHttpClient().AddLogging();
builder.Services.AddAGUI();
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.TypeInfoResolverChain.Add(AGUIDojoServerSerializerContext.Default));

builder.Services.AddSingleton<ChatClientAgentFactory>();

var app = builder.Build();

app.UseHttpLogging();

var agentFactory = app.Services.GetRequiredService<ChatClientAgentFactory>();

app.MapAGUI("/agentic_chat", agentFactory.CreateAgenticChat());
app.MapAGUI("/backend_tool_rendering", agentFactory.CreateBackendToolRendering());
app.MapAGUI("/human_in_the_loop", agentFactory.CreateHumanInTheLoop());
app.MapAGUI("/agentic_generative_ui", agentFactory.CreateAgenticGenerativeUi());
app.MapAGUI("/tool_based_generative_ui", agentFactory.CreateToolBasedGenerativeUi());
app.MapAGUI("/shared_state", agentFactory.CreateSharedState());
app.MapAGUI("/predictive_state_updates", agentFactory.CreatePredictiveStateUpdates());

await app.RunAsync();

public partial class Program;
