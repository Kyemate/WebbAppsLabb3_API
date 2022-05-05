using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(k => new {k.PersonId, k.InterestId});

        builder.HasData(new Link(1,1,"http://sample.com"));
    }
}