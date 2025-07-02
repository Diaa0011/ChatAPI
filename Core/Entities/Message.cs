using ChatApp.Constants.Enums;

namespace ChatApp.Entities;

public class Message
{
    public Guid Id { get; set; }
    public Guid OriginalMessageId { get; set; }
    public string Content { get; set; }
    public MessageType Type { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatorId { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string? UpdaterId { get; set; }
    public DateTime? DeletedOn { get; set; }
    public string? DeleterId { get; set; }
}