using SeniorChallenge.InputModels;
using SeniorChallenge.Repositories;
using SeniorChallenge.Utilities;

namespace SeniorChallenge.Services
{
    /// <summary>
    /// The service to manage users and authentication.
    /// </summary>
    public static class UserService
    {
        private static readonly UserRepository repo = new();

        /// <summary>
        /// Realize the authentication for the user.
        /// </summary>
        /// <param name="userModel">User authentication information.</param>
        /// <returns>The bearer token to use this session.</returns>
        public static string Authenticate(UserModel userModel)
        {
            Entities.User user = repo.GetByLogin(userModel.Mail, UtilEncrypter.Encrypt(userModel.Mail + userModel.Password));
            return new UtilAuthenticator(user).GetAuthUser();
        }
    }
}
