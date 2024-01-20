using Domain.Common;

namespace Domain.Entities;

public class Subscription : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public DateTime TakenAt { get; set; }
    public DateTime ShouldReturnAt { get; set; }
    public bool IsActive { get; set; }
}