using MovieTracker.Domain.Contracts;

namespace MovieTracker.Domain.Entities;
public class Otp : BaseEntity, IEntity
{
    public int Code { get; set; }
    public DateTime ExpirationTime { get; set; }
    public Guid UserId { get; set; }
}
