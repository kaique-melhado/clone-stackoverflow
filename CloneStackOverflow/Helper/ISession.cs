using CloneStackOverflow.Models;

namespace CloneStackOverflow.Helper
{
    public interface ISession
    {
        User GetSession();
        void CreateSession(User user);
        void RemoveSession();
    }
}
