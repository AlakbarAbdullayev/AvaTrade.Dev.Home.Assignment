using AvaTrade.Domain.Entities.Users;
using AvaTrade.Infrastructure.Repositories;

namespace AvaTrade.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByUserNameOrEmail(string userNameOrEmail)
        {
            if (string.IsNullOrWhiteSpace(userNameOrEmail))
            {
                return null;
            }

            return new User
            {
                Email = "AvaTrade",
                FullName = "AvaTrade",
                UserName = "AvaTrade",
            };
        }
    }
}
