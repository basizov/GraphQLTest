using CommanderGQL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommanderGQL.Data.FluentValidation;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
	public void Configure(EntityTypeBuilder<Platform> builder)
	{
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(50);
	}
}
