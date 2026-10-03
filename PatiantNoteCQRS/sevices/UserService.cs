using PatiantNoteCQRS.Interfaces;
using PatiantNoteCQRS.Models;
using Microsoft.EntityFrameworkCore;
namespace PatiantNoteCQRS.sevices
{
    public class UserService : IUser
    {
        private readonly MedicalPassportContext medicalPassportContext;

        public UserService(MedicalPassportContext medicalPassportContext)
        {
            this.medicalPassportContext = medicalPassportContext;
        }
        public async Task<User> AddUser(User user)
        {
            medicalPassportContext.Users.Add(user);
            await medicalPassportContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await medicalPassportContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            if(id>0)
            return await medicalPassportContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            else
                return null;
        }
        public async Task UpdateUser(int id, User user)
        {
            var existingUser = await medicalPassportContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (existingUser != null && user != null)
            {
                existingUser.FullName = user.FullName;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                await medicalPassportContext.SaveChangesAsync();
            }
        }
    }
    
}
