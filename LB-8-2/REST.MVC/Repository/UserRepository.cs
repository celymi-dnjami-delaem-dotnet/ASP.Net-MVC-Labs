using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REST.MVC.Models;

namespace REST.MVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<List<UserModel>> GetUsers()
        {
            return await _databaseContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<UserModel> GetUser(int id)
        {
            return await _databaseContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddUser(UserModel user)
        {
            await _databaseContext.Users.AddAsync(user);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            _databaseContext.Users.Update(user);

            await _databaseContext.SaveChangesAsync();

            return user;
        }

        public async Task RemoveUser(int id)
        {
            var removableUser = await _databaseContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (removableUser != null)
            {
                _databaseContext.Remove(removableUser);
            }

            await _databaseContext.SaveChangesAsync();
        }
    }
}