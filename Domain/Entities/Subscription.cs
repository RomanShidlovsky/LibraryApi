using Domain.Common;

namespace Domain.Entities;

public class Subscription : IBaseEntity
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    
    public int UserId { get; set; }
    public virtual User User { get; set; }
    
    public DateTime TakenAt { get; set; }
    public DateTime ShouldReturnAt { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
}