using BestGuide.Api.Data;
using BestGuide.Api.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BestGuide.Api.Features.Guides;

public static class GuideEndpoints
{
    public static IEndpointRouteBuilder MapGuideEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/guides").WithTags("Guides");

        group.MapGet("/", GetAll);
        group.MapGet("/{id:guid}", GetById);
        group.MapPost("/", Create);

        return app;
    }

    private static async Task<Ok<List<GuideListItemDto>>> GetAll(AppDbContext db, CancellationToken ct)
    {
        var guides = await db.Guides
            .AsNoTracking()
            .OrderByDescending(g => g.CreatedAtUtc)
            .Select(g => new GuideListItemDto(g.Id, g.Title, g.CreatedAtUtc))
            .ToListAsync(ct);

        return TypedResults.Ok(guides);
    }

    private static async Task<Results<Ok<GuideDto>, NotFound>> GetById(
        Guid id, AppDbContext db, CancellationToken ct)
    {
        var guide = await db.Guides
            .AsNoTracking()
            .Where(g => g.Id == id)
            .Select(g => new GuideDto(g.Id, g.TenantId, g.Title, g.ContentMarkdown, g.CreatedAtUtc))
            .FirstOrDefaultAsync(ct);

        return guide is null ? TypedResults.NotFound() : TypedResults.Ok(guide);
    }

    private static async Task<Results<Created<GuideDto>, ValidationProblem>> Create(
        CreateGuideRequest request, AppDbContext db, CancellationToken ct)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(request.Title) || request.Title.Length > 200)
            errors["title"] = ["Title ist Pflicht und darf maximal 200 Zeichen lang sein."];

        if (!await db.Tenants.AnyAsync(t => t.Id == request.TenantId, ct))
            errors["tenantId"] = ["Tenant existiert nicht."];

        if (errors.Count > 0)
            return TypedResults.ValidationProblem(errors);

        var guide = new Guide
        {
            TenantId = request.TenantId,
            Title = request.Title,
            ContentMarkdown = request.ContentMarkdown ?? string.Empty,   // Punkt 5
            CreatedAtUtc = DateTime.UtcNow
        };

        db.Guides.Add(guide);
        await db.SaveChangesAsync(ct);

        var dto = new GuideDto(guide.Id, guide.TenantId, guide.Title, guide.ContentMarkdown, guide.CreatedAtUtc);
        return TypedResults.Created($"/api/guides/{guide.Id}", dto);
    }
}