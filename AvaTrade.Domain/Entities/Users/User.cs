using AvaTrade.Domain.Common;

namespace AvaTrade.Domain.Entities.Users
{
    public class User : Entity<int>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
    }
}
