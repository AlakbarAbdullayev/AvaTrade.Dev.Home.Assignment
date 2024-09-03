using AvaTrade.Domain.Entities.News;
using AvaTrade.Domain.Entities.Users;
using AvaTrade.Infrastructure.Repositories;
using AvaTrade.Persistence.Contexts;

namespace AvaTrade.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
