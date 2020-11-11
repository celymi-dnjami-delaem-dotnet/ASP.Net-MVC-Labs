using System.Collections.Generic;
using System.Threading.Tasks;
using REST.MVC.Models;

namespace REST.MVC.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers();
        
        Task<UserModel> GetUser(int id);

        Task AddUser(UserModel user);

        Task<UserModel> UpdateUser(UserModel user);
        
        Task RemoveUser(int id);
    }
}