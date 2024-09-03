using AvaTrade.Domain.Entities.Users;

namespace AvaTrade.Application.Services.Users
{
    public interface IUserService
    {
        public Task<User?> GetByUserNameOrEmail(string userNameOrEmail);
    }
}
