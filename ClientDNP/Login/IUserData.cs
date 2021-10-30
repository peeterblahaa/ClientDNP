using System.Collections.Generic;
using System.Threading.Tasks;
using ClientDNP.Models;

namespace ClientDNP.Login
{
    public interface IUserData
    {
        Task<User> Get(string username, string password);
        Task Add(User user);
        Task<IList<User>> GetUsers();
    }
}