using MovieTracker.Domain.Contracts;

namespace MovieTracker.Domain.Entities;
public class Like : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }

}
