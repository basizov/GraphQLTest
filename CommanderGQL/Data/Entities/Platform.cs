namespace CommanderGQL.Data.Entities;

public record Platform
{
	public Guid Id { get; init; }
	public string? Name { get; init; }
	public string? LicenseKey { get; init; }
}
