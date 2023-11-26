using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SeniorChallenge.Consts;
using SeniorChallenge.Entities;

namespace SeniorChallenge.Utilities
{
    /// <summary>
    /// The class responsible for performing authentication
    /// </summary>
    public class UtilAuthenticator
    {
        private readonly User _User;

        /// <summary>
        /// The constructor to set the current user used to realize operations in this class.
        /// </summary>
        /// <param name="user">The user entity</param>
        public UtilAuthenticator(User user)
        {
            _User = user;
        }

        /// <summary>
        /// Realize the authentication for the user with claim of roles.
        /// </summary>
        /// <returns>The bearer token to use this session.</returns>
        public string GetAuthUser()
        {
            List<Claim> claims = new(FetchClaimsPermissions()) {
                new Claim(ClaimTypes.Sid, _User.Id.ToString()),
                new Claim(ClaimTypes.Email, _User.Mail)
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(UtilEncrypter.GetByteKey()), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private IEnumerable<Claim> FetchClaimsPermissions()
        {
            return _User.Permissions.Select(x => new Claim(ClaimTypes.Role, TypeSafeEnumPermissionRoles.GetPermissionByEnum(x).Description));
        }
    }
}
