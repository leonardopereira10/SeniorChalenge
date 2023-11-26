using SeniorChallenge.Utilities;

namespace SeniorChallenge.InputModels
{
    /// <summary>
    /// The user informations.
    /// </summary>
    public class UserModel
    {
        private string password;

        /// <summary>
        /// The email from user.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// The password from user (encrypted on "SET").
        /// </summary>
        public string Password
        {
            get => password;
            set => password = UtilEncrypter.Encrypt(value);
        }
    }
}
