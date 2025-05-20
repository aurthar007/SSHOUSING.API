namespace SSHOUSING.Domain.Interface
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}
