using Microsoft.IdentityModel.Tokens;

namespace AvaTrade.Infrastructure.Encryption
{
    /// <summary>
    /// Signing credentials helper
    /// </summary>
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) =>
        new(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
