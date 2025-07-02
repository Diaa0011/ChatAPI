using ChatApp.Data.IRepository;
using ChatApp.Entities;

namespace ChatApp.Data.Repository;

public class ChatRepository : Repository<Message>, IChatRepository
{
    private readonly AppDbContext _context;

    public ChatRepository(AppDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}