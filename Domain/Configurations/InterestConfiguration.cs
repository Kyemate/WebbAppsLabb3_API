using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class InterestConfiguration : IEntityTypeConfiguration<Interest>
{
    public void Configure(EntityTypeBuilder<Interest> builder)
    {
        builder.HasData(new Interest(1, 1, "test interest 1", "this is a test interest"));
        builder.HasData(new Interest(2, 2, "test interest 2", "this is a test interest"));
    }
}