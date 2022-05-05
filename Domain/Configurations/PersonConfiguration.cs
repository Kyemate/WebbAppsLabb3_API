using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasData(new Person(1,"Henrik","07X-XXXXXXX"));

        for (int i = 2; i < 35; i++)
        {
            builder.HasData(new Person(i, $"Person {i}", "07X-XXXXXXX"));
        }
    }
}