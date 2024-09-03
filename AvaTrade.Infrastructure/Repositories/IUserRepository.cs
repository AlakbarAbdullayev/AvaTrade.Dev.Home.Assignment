using AvaTrade.Domain.Entities.News;
using AvaTrade.Domain.Entities.Users;

namespace AvaTrade.Infrastructure.Repositories
{
    public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int>
    {
    }
}
