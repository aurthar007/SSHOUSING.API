using Microsoft.EntityFrameworkCore;
using SSHOUSING.Domain.Entities;
using SSHOUSING.Domain.Interface;
using SSHOUSING.Infrastucture;

namespace SSHOUSING.Infrastructure.Repository
{
    public class MessageRepository : IMessage
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Message> GetAllMessages()
        {
            return _context.Messages.Include(m => m.User).OrderByDescending(m => m.PostedAt).ToList();
        }

        public List<Message> GetMessagesByUser(int userId)
        {
            return _context.Messages.Where(m => m.UserId == userId).Include(m => m.User).OrderByDescending(m => m.PostedAt).ToList();
        }

        public Message AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }
    }
}
