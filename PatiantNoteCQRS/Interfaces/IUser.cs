using PatiantNoteCQRS.Models;

namespace PatiantNoteCQRS.Interfaces
{
    public interface IUser
    {
        public Task<User> AddUser(User user);
        public Task<User> GetUserById(int id);

        public Task<List<User>> GetAllUsers();
    }
}
