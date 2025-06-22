using SSHOUSING.Domain.Entities;

namespace SSHOUSING.Domain.Interface
{
    public interface IMessage
    {
        List<Message> GetAllMessages();
        List<Message> GetMessagesByUser(int userId);
        Message AddMessage(Message message);
    }
}
