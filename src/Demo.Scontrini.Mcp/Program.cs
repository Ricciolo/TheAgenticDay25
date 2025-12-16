using Demo.Common;

var builder = WebApplication.CreateBuilder(args);

// Configura le opzioni Content Understanding dalla configurazione (appsettings.json)
builder.Services.Configure<ContentUnderstandingOptions>(
    builder.Configuration.GetSection("ContentUnderstanding"));

// Registra il servizio dell'API Content Understanding
builder.Services.AddContentUnderstandingApi();

// Configura il server MCP con HTTP transport
builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Espone l'endpoint MCP
app.MapMcp("/api/mcp");

app.Run();
