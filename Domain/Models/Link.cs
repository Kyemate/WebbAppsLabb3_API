namespace Domain.Models;

public class Link
{
    private Link(){}
    public Link(int personId, int interestId, string url)
    {
        PersonId = personId;
        InterestId = interestId;
        Url = url;
    }

    public int Id { get; set; }

    public int PersonId { get; set; } = default!;

    public int InterestId { get; set; } = default!;

    public string Url { get; set; } = default!;

}