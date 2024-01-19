namespace Domain.Entities;

public class Subscription
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public bool IsActive { get; set; }
    public Book Book { get; set; }
}