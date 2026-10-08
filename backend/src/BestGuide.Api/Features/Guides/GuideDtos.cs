namespace BestGuide.Api.Features.Guides;

public record GuideListItemDto(Guid Id, string Title, DateTime CreatedAtUtc);

public record GuideDto(Guid Id, Guid TenantId, string Title, string ContentMarkdown, DateTime CreatedAtUtc);

public record CreateGuideRequest(Guid TenantId, string Title, string? ContentMarkdown);
