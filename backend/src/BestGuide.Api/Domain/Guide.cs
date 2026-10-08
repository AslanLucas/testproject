namespace BestGuide.Api.Domain;

// Ein Guide = ein Wiki-Artikel, der genau einem Tenant gehört.
public class Guide
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ContentMarkdown { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }

    // TODO: Navigation zu Tenant, Favoriten, ...
}
