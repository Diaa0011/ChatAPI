namespace ChatApp.Core.Entities;

public class ReadMessage
{
    public Guid Id { get; set; }
    public Guid MessageId { get; set; }
    public Guid ReaderId { get; set; }
    public DateTime ReadOn { get; set; }
}