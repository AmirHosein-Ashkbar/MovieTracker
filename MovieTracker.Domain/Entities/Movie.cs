using MovieTracker.Domain.Contracts;

namespace MovieTracker.Domain.Entities;
public class Movie : BaseEntity, IEntity
{
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int ReleaseYear { get; set; }

}
