namespace ChatApp.Core.Entities;

public class ReadMessage
{
    public Ulid Id { get; set; }
    public Ulid MessageId { get; set; }
    public Ulid ReaderId { get; set; }
    public DateTime ReadOn { get; set; }
    
}