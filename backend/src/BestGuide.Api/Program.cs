using BestGuide.Api.Data;
using BestGuide.Api.Features.Guides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();          // -> /openapi/v1.json
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGuideEndpoints();
app.Run();

// Wird von WebApplicationFactory<Program> in den Integrationstests benötigt.
public partial class Program { }