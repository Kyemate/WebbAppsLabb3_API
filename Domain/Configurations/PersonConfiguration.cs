using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasData(new Person(1,"Henrik","072-XXXXXXX"));
        builder.HasData(new Person(2, "Hanna", "072-XXXXXXX"));
    }
}