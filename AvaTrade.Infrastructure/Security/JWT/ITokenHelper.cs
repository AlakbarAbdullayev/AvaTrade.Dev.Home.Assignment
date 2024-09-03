using AvaTrade.Domain.Entities.Users;

namespace AvaTrade.Infrastructure.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user/*, IList<OperationClaim> operationClaims*/);

    RefreshToken CreateRefreshToken(User user);
}
