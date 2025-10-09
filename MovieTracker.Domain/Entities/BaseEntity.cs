using MovieTracker.Domain.Contracts;

namespace MovieTracker.Domain.Entities;
public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;

}
