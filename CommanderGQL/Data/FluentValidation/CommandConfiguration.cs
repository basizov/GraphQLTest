using CommanderGQL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.FluentValidation;

public class CommandConfiguration : IEntityTypeConfiguration<Command>
{
	public void Configure(EntityTypeBuilder<Command> builder)
	{
		builder.HasKey(c => c.Id);
		builder.Property(c => c.HowTo)
			.IsRequired()
			.HasMaxLength(100);
		builder.Property(c => c.CommandLine)
			.IsRequired()
			.HasMaxLength(20);
		builder.HasOne(c => c.Platform)
			.WithMany(p => p.Commands)
			.HasForeignKey(c => c.PlatformId);
	}
}
