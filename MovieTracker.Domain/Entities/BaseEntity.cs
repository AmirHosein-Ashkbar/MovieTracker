namespace MovieTracker.Domain.Entities;
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;

}
