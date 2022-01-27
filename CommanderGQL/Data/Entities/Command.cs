namespace CommanderGQL.Data.Entities;

public record Command
{
	public Guid Id { get; init; }
	public string? HowTo { get; init; }
	public string? CommandLine { get; init; }
	public Guid PlatformId { get; init; }
	public virtual Platform? Platform { get; init; }
}
