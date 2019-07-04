using System.Threading.Tasks;
using TexTuto.API.Models;

namespace TexTuto.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
    }
}