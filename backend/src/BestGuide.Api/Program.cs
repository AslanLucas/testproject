var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// TODO: DbContext registrieren (Npgsql, ConnectionString "Default")
// TODO: Einheitliche Fehlerbehandlung (ProblemDetails)
// TODO: Tenant-Auflösung (MultiTenancy/)
// TODO: RabbitMQ / Messaging (Messaging/)

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// TODO: Guide-Endpunkte mappen (Features/Guides/)

app.Run();

// Wird von WebApplicationFactory<Program> in den Integrationstests benötigt.
public partial class Program { }
