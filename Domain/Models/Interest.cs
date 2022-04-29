namespace Domain.Models;

public class Interest
{
    private Interest(){}
    public Interest(int id, int personId, string title, string description, ICollection<Link>? links = null)
    {
        Id = id;
        PersonId = personId;
        Title = title;
        Description = description;
        Links = links;
    }
    public Interest(int personId, string title, string description, ICollection<Link>? links = null)
    {
        PersonId = personId;
        Title = title;
        Description = description;
        Links = links;
    }

    public int Id { get; set; }

    public int PersonId { get; set; }

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ICollection<Link>? Links { get; set; }
}