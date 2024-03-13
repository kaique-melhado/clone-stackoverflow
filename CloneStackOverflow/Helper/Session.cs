using CloneStackOverflow.Models;
using Newtonsoft.Json;

namespace CloneStackOverflow.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public User GetSession()
        {
            var sessionUser = _httpContext.HttpContext.Session.GetString("sessionUserLogged");
            if (string.IsNullOrEmpty(sessionUser))
                return null;

            return JsonConvert.DeserializeObject<User>(sessionUser);
        }
        
        public void CreateSession(User user)
        {
            var userLogged = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("sessionUserLogged", userLogged);
        }        

        public void RemoveSession()
        {
            _httpContext.HttpContext.Session.Remove("sessionUserLogged");
        }
    }
}
