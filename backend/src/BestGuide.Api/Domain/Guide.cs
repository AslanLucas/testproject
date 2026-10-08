namespace BestGuide.Api.Domain;

public class Guide
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }

    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    public ICollection<Guide> Guides { get; set; } = new List<Guide>();
}