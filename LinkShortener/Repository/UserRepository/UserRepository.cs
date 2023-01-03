using LinkShortener.Data;
using LinkShortener.Models;
using System.Linq;

namespace LinkShortener.Repository.UserRepository
{
    public interface IUserRepository
    {
        bool IsExistUserByEmail(string email);
        User GetUserForLogin(string email, string password);
        void AddUser(User user);
    }

    public class UserRepository : IUserRepository
    {

        private LinkShortenerContext _context;
        public UserRepository(LinkShortenerContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
        }

        public User GetUserForLogin(string email, string password)
        {
            return _context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.User.Any(u => u.Email == email);
        }
    }
}
