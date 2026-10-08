namespace BestGuide.Api.Domain;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Guide> Guides { get; set; } = new List<Guide>();
}
